using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Constans;

public class Soldier : MonoBehaviour
{
    [SerializeField] public SoldierSO soldierSO;
    [SerializeField] Animator anim;
    [SerializeField] GameObject areaTrigger;
    [SerializeField] float fireTime;
    [SerializeField] GameObject mergeVFX;
    [SerializeField] bool isTrigger = false;
    [SerializeField] bool isPlatform = false;
    GameObject obj;
    Vector3 difference;
    [SerializeField] List<GameObject> enemys;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;
    [SerializeField] public int id;
    [SerializeField] MeshRenderer areaMeshRenderer;
    float rotX;
    Vector3 soldierPos;
    Vector3 soldierNewPos;

    private void Start()
    {
        fireTime = soldierSO.baseFireTime;
        id = gameObject.GetInstanceID();
        soldierPos = transform.position;
        GetCompenent();
    }

    void GetCompenent()
    {
        areaMeshRenderer = areaTrigger.GetComponent<MeshRenderer>();
    }
    private void OnEnable()
    {
        EventManager.GameAddEnemyList += AddEnemyList;
        EventManager.GameRemoveEnemyList += RemoveEnemyList;
        EventManager.GameDeadEnemyList += DeadEnemyList;
    }

    private void OnDisable()
    {
        EventManager.GameAddEnemyList -= AddEnemyList;
        EventManager.GameRemoveEnemyList -= RemoveEnemyList;
        EventManager.GameDeadEnemyList -= DeadEnemyList;
    }

    private void Update()
    {
        if (enemys.Count > 0)
        {
            if (enemys[0] == null)
            {
                enemys.RemoveAt(0);
                enemy = null;
            }
            else
            {
                enemy = enemys[0];
                transform.LookAt(enemy.gameObject.transform);
                Shooting();
                AreaTriggerXRot();
            }

        }
        else
        {
            anim.SetTrigger("Idle");
        }
    }

    void Shooting()
    {
        fireTime -= Time.deltaTime;
        if (fireTime <= 0)
        {
            fireTime = soldierSO.baseFireTime;
            anim.SetTrigger("Attack");        
        }
    }


    void AreaTriggerXRot()
    {
        rotX = - transform.rotation.x;
        areaTrigger.transform.rotation = Quaternion.Euler(rotX, 0, 0);
    }

    public void ShotAnim()
    {
        if (enemy.GetComponent<Enemy>().health >0)
        {
            GameObject bull = Instantiate(bullet, bulletPos.position, Quaternion.identity);
            bull.GetComponent<Bullet>().damage = soldierSO.damage;
            bull.transform.SetParent(enemy.transform);
            bull.transform.DOLocalMove(new Vector3(0, transform.position.y, 0), .25f);
        }
    }

    private void OnMouseDown()
    {
        difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.position = new Vector3(transform.position.x, 0.61f, transform.position.z);
    }


    private void OnMouseDrag()
    {
         transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - difference);
         transform.position = new Vector3(transform.position.x + transform.position.x, 0.61f, transform.position.z + transform.position.z);
        //// areaMeshRenderer.enabled = false;

    }

    private void OnMouseUp()
    {
        if (isPlatform)
        {
            transform.position = soldierNewPos;
            soldierPos = transform.position;
            //StartCoroutine(AreaMeshCoroutine());
            if (isTrigger)
            {
                GameObject newSoldier = Instantiate(soldierSO.soldiers[soldierSO.soliderID], transform.position, Quaternion.identity);
                Instantiate(mergeVFX, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                Destroy(obj);
                Destroy(gameObject);
            }
            else
            {
                transform.position = soldierPos;
            }
        }      
        else
        {
            transform.position = soldierPos;
        }
    }

    IEnumerator AreaMeshCoroutine()
    {
       // Debug.Log("Area Mesh");
        areaMeshRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        areaMeshRenderer.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.tag)
        {
            isTrigger = true;
            obj = other.gameObject;

        }
        if (other.tag == Tags.Platform)
        {
            isPlatform = true;
            soldierNewPos = new Vector3( other.gameObject.transform.position.x, other.gameObject.transform.position.y+.65f, other.gameObject.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == other.tag)
        {
            isTrigger = false;
        }
        if (other.tag == Tags.Platform)
        {
            isPlatform = false;
        }
    }


    public void AddEnemyList(GameObject enemy , int id)
    {
        if (id == this.id)
        {
            enemys.Add(enemy);
        }

    }

    public void RemoveEnemyList(GameObject enemy , int id)
    {
        if (id == this.id)
        {
            enemys.Remove(enemy);
        }

    }

    public void DeadEnemyList(GameObject enemy)
    {
        enemys.Remove(enemy);
    }
}

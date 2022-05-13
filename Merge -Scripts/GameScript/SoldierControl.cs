using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using DG.Tweening;
using Enums;
public class SoldierControl : MonoBehaviour
{
    [Header("------------------------------------------")]
    [SerializeField] public AllySO allySO;
    [Header("------------------------------------------")]

    [SerializeField] Animator anim;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] SkinnedMeshRenderer defaultSkinnedMR;
   // [SerializeField] GameObject charWeapon;
    [SerializeField] private Collider _col;
    [SerializeField] GameObject area;
    [SerializeField] GameObject VFX;
    [Header("------------------------------------------")]

    [SerializeField] private GameObject _target;
    [SerializeField] public Transform targetHead;
    [Header("------------------------------------------")]

    [SerializeField] bool isPlay = false;
    [SerializeField] bool isEnemyContact = false;
    [SerializeField] bool isDead = false;
    [SerializeField] bool isVFX = false;
    [SerializeField] public bool isAddList = false;
    [SerializeField] bool isCatapultCannon = false;
    [Header("------------------------------------------")]
    [SerializeField] List<GameObject> enemys;
    [Header("------------------------------------------")]

    [SerializeField] int health;
    public int id;
    [Header("------------------------------------------")]

    [SerializeField] Transform attackPoint;
    [SerializeField] float range =.5f;
    [SerializeField] LayerMask layerMask;

    private void OnEnable()
    {
        EventManager.GameAddEnemyList += AddEnemyList;
        EventManager.GameRemoveEnemyList += RemoveEnemyList;
        EventManager.GameTriggerActiveted += TriggerActiveted;
    }

    private void OnDisable()
    {
        EventManager.GameAddEnemyList -= AddEnemyList;
        EventManager.GameRemoveEnemyList -= RemoveEnemyList;
        EventManager.GameTriggerActiveted -= TriggerActiveted;
    }

    private void Start()
    {
        GetValue();
        getCompenent();
        ScaleChange();
    }

    void GetValue()
    {
        health = allySO.baseHealh;
        id = GetInstanceID();
        
    }

    void getCompenent()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _col = gameObject.GetComponent<CapsuleCollider>();
        defaultSkinnedMR = gameObject.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    void ScaleChange()
    {
        if (allySO.soldierEnum == SoldierEnum.Ally)
        {
            if (allySO.levelID != 1)
            {
                transform.DOScale(new Vector3(transform.localScale.x + .2f, transform.localScale.y + .2f, transform.localScale.z + .2f), .5f);
            }
        }

    }

    private void Update()
    {
        if (isPlay)
        {
            if (!isDead)
            {
                if (enemys.Count > 0)
                {
                    FindClosestEnemy();
                }
                else
                {
                    _target = null;
                    anim.SetTrigger("Idle");
                }
            }

           
        }

        if (health <= 0 )
        {
            anim.SetTrigger("Dead");
        }
    }


    void FindClosestEnemy()
    {
        float distanceTOClosestEnemy = Mathf.Infinity;
        _target = null;
        foreach (GameObject currentEnemy in enemys)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceTOClosestEnemy)
            {
                distanceTOClosestEnemy = distanceToEnemy;
                _target = currentEnemy;
                MoveCharacter();
            }
        }

        Debug.DrawLine(this.transform.position, _target.transform.position,Color.green);
    }


    void MoveCharacter()
    {
        if (allySO.allyEnum == AllyEnum.Melee)
        {
            if (!isDead)
            {
                this.transform.LookAt(_target.transform);
                if (!isEnemyContact)
                {
                    anim.SetTrigger("Walk");
                    // _characterController.Move(_target.transform.position * allySO.speed * Time.deltaTime);
                    this.transform.position += transform.forward * Time.deltaTime * allySO.speed;
                }
                else
                {
                    anim.SetTrigger("Attack");
                   // MeleeAttack();
                }
            }
        }

        if (allySO.allyEnum == AllyEnum.Ranged)
        {
            if (!isDead)
            {
                this.transform.LookAt(_target.transform);
                anim.SetTrigger("Attack");
               // RangedAttack();
            }
        }      
    }

    public void RangedAttack()
    {
        if (isCatapultCannon)
        {
            GameObject _weapon = Instantiate(allySO.weapon, attackPoint.transform.position, Quaternion.Euler(-90, 0, 0));
            _weapon.transform.rotation = Quaternion.Euler(transform.forward);
            _weapon.transform.DOLocalJump(_target.GetComponent<SoldierControl>().targetHead.transform.position, 1, 1, .5f);
            EventManager.GamePlayCannonCatapultAttack(id);
            if (isVFX)
            {
                Instantiate(VFX, attackPoint.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            GameObject _weapon = Instantiate(allySO.weapon, attackPoint.transform.position, Quaternion.Euler(-90, 0, 0));
            _weapon.transform.rotation = Quaternion.Euler(transform.forward);
            _weapon.transform.DOLocalJump(_target.GetComponent<SoldierControl>().targetHead.transform.position, 1, 1, .5f);
        }
    }

    public void MeleeAttack()
    {
      //  Debug.Log("MeleeAttack" + transform.name);
        Collider[] hit = Physics.OverlapSphere(attackPoint.position, range, layerMask);
        if (isVFX)
        {
            Instantiate(VFX, attackPoint.position, Quaternion.Euler(30, 180, 0));
        }
       
        foreach (Collider enemy in hit)
        {
            // Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<SoldierControl>().TakeDamage(allySO.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, range);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        StartCoroutine(ChangeMaterialCoroutine());
        EventManager.GamePlayUpdateHealthBar(id, health);
    }

   public void CharDead()
    {
       // Debug.Log("Char Dead");
        isDead = true;
        EventManager.GamePlayDeleteHealthBar(id);
        Destroy(_col);
        Destroy(_characterController);
        EventManager.GamePlayRemoveEnemyList(gameObject);
        Collider[] cols = GetComponentsInChildren<Collider>();
        foreach (Collider childsCollider in cols)
        {
            Destroy(childsCollider);
        }
        if (allySO.soldierEnum == SoldierEnum.Enemy)
        {
            EventManager.GamePlayAddMoney();
            EventManager.GamePlayEnemyDecrease();
        }
        if (allySO.soldierEnum == SoldierEnum.Ally)
        {
            EventManager.GamePlayAllyDecrease();
        }
        EventManager.GamePlayCannonCatapultIdle(id);

    }

    public void AddEnemyList(int ID,GameObject obj)
    {
        if (ID == id)
        {
            enemys.Add(obj);
        }
    }

    public void RemoveEnemyList( GameObject obj)
    {
        enemys.Remove(obj);
        enemys.Remove(obj);
        isEnemyContact = false;
      //  Debug.Log(gameObject.name +"Remove List" + obj.name);
    }

    public void TriggerActiveted()
    {
        area.SetActive(true);
        _characterController.enabled = true;
        Destroy(area,.1f);
        StartCoroutine(BoolDelay());
    }

    IEnumerator BoolDelay()
    {
        yield return new WaitForSeconds(.11f);
        isEnemyContact = false;
        //health = allySO.baseHealh;
        //EventManager.GamePlayUpdateHealthBar(id, health);
        isPlay = true;

    }

    IEnumerator ChangeMaterialCoroutine()
    {
        defaultSkinnedMR.material = allySO.changeMat;
        yield return new WaitForSeconds(.3f);
        defaultSkinnedMR.material = allySO.mainMat;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isPlay)
        {
            if (allySO.soldierEnum == SoldierEnum.Ally)
            {
                if (other.tag == Tags.Enemy)
                {
                    isEnemyContact = true;
                }
                if (other.tag == Tags.EnemyWeapon)
                {
                    TakeDamage(other.gameObject.GetComponent<WeaponConrol>().allySO.damage);
                    other.gameObject.GetComponent<Collider>().enabled = false;
                    Destroy(other.gameObject, .1f);
                    Debug.LogWarning("Ally Attack");
                }
            }

            if (allySO.soldierEnum == SoldierEnum.Enemy)
            {
                if (other.tag == Tags.Ally)
                {
                    isEnemyContact = true;
                }
                if (other.tag == Tags.AllyWeapon)
                {
                    TakeDamage(other.gameObject.GetComponent<WeaponConrol>().allySO.damage);
                    other.gameObject.GetComponent<Collider>().enabled = false;
                    Destroy(other.gameObject, .1f);
                  //  Debug.Log("Attack");
                }
            }
        }      

    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlay)
        {
            if (allySO.soldierEnum == SoldierEnum.Ally)
            {
                if (other.tag == Tags.Enemy)
                {
                    // isEnemyContact = false;
                }
            }

            if (allySO.soldierEnum == SoldierEnum.Enemy)
            {
                if (other.tag == Tags.Ally)
                {
                    Debug.Log("Enemy Contact");
                    //isEnemyContact = false;
                }
            }
        }
       

    }


}

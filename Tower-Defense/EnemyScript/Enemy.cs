using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;
using Constans;

public class Enemy : MonoBehaviour
{
    //[SerializeField] EnemySO enemySO;
    [SerializeField] bool isIce;
    [SerializeField] Animator anim;
    [SerializeField] SplineFollower splineFollower;
    [SerializeField] public float health;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject charPrefab;
    [SerializeField] Material defaultCharMat;
    [SerializeField] Material changeCharMat;
    [SerializeField] Collider coll;
    [SerializeField] GameObject[] frags;
    [SerializeField] GameObject[] chars;

    private void Start()
    {
        charPrefab.GetComponent<SkinnedMeshRenderer>().material = defaultCharMat;
    }


    public void PathFollow(SplineComputer splineComputer)
    {
        splineFollower.spline = splineComputer;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(ChangeMaterialCoroutine());
        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator ChangeMaterialCoroutine()
    {
        charPrefab.GetComponent<SkinnedMeshRenderer>().material = changeCharMat;
        yield return new WaitForSeconds(.3f);
        charPrefab.GetComponent<SkinnedMeshRenderer>().material = defaultCharMat;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.MainCastle)
        {
            DieCastle();
            EventManager.GamePlayHealthSlider();
            EventManager.GamePlayIgloDefenseAnim();
        }
    }

    void Die()
    {
        EventManager.GamePlayDeadEnemyList(gameObject);
        anim.SetTrigger("Die");
        splineFollower.follow = false;
        coll.enabled = false;
        StartCoroutine(DieCoroutine());
       // StartCoroutine(IceCoroutine());
       
    }

    IEnumerator DieCoroutine()
    {
        if (isIce)
        {
            ice.transform.DOScale(Vector3.one, .1f);
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < 2; i++)
            {
                frags[i].SetActive(true);
                chars[i].SetActive(false);
            }
        }


        yield return new WaitForSeconds(3f);
        EventManager.GamePlayDeadEnemyCount();
        Destroy(gameObject);
    }


    void DieCastle()
    {
        EventManager.GamePlayDeadEnemyList(gameObject);
        coll.enabled = false;
        EventManager.GamePlayDeadEnemyCount();
        
        StartCoroutine(DieCastleCoroutine());
    }

    IEnumerator DieCastleCoroutine()
    {
        transform.DOScale(Vector3.one / 2, 0f);
        yield return new WaitForSeconds(1f);
        splineFollower.follow = false;
        anim.SetTrigger("Die");
        Destroy(gameObject);
    }

}

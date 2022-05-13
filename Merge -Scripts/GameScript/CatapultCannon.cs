using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultCannon : MonoBehaviour
{
    public Animator anim;
    public int id;

    private void Start()
    {
        id = transform.parent.gameObject.GetComponent<SoldierControl>().id;
    }


    private void OnEnable()
    {
        EventManager.GameCannonCatapultAttack += Attack;
        EventManager.GameCannonCatapultIdle += Idle;
    }

    private void OnDisable()
    {
        EventManager.GameCannonCatapultAttack -= Attack;
        EventManager.GameCannonCatapultIdle -= Idle;
    }

    public void Attack(int _id)
    {
        if (id == _id)
        {
            anim.SetTrigger("Attack");
        }
       
    }


    public void Idle(int _id)
    {
        if (id == _id)
        {
            anim.SetTrigger("Idle");
        }
    }
}

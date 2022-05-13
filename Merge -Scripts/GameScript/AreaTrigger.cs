using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using Enums;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] SoldierControl soldierControl;
    int id;

    private void Start()
    {
        GetValue();
    }


    void GetValue()
    {
        id = soldierControl.id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (soldierControl.allySO.soldierEnum == SoldierEnum.Ally)
        {
            if (other.tag == Tags.Enemy)
            {
                EventManager.GamePlayAddEnemyList(id, other.gameObject);
                
            }
        }

        if (soldierControl.allySO.soldierEnum == SoldierEnum.Enemy)
        {
            if (other.tag == Tags.Ally)
            {
                EventManager.GamePlayAddEnemyList(id, other.gameObject);
            }
        }


    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == Tags.Enemy)
    //    {
    //        EventManager.GamePlayRemoveEnemyList(id, other.gameObject);
    //    }
       
    //}
}

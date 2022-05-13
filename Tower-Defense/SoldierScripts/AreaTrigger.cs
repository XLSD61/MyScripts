using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] Soldier soldier;
    int id;
    private void Start()
    {
        id = soldier.id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Enemy)
        {
            EventManager.GamePlayAddEnemyList(other.gameObject , id);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Enemy)
        {
            EventManager.GamePlayRemoveEnemyList(other.gameObject , id);
        }
    }


    public void NullParent()
    {
        transform.SetParent(null);
    }
}

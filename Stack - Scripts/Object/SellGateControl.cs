using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using DG.Tweening;

public class SellGateControl : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] Transform endPos;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Doll)
        {
            //TriggerControl(pos);
            other.gameObject.GetComponent<DollController>().SellTrigger(pos,endPos);
        }
        
    }
}

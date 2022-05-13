using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using DG.Tweening;
public class HandController : MonoBehaviour
{
    //[SerializeField] Transform handCupcakePos;
    //[SerializeField] PlayerControl playerControl;
    //int order = 0;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == Tags.PO && order == 0)
    //    {
    //        other.transform.DOMove(handCupcakePos.transform.position, .5f);
    //        playerControl.HandCupcakeParent(other.gameObject);
    //        playerControl.AddCupcakeList(other.gameObject);
    //        other.gameObject.tag = Tags.PO;
    //        order++;
    //        Debug.Log("Ýlk Temas");
    //    }
    //    if (other.tag == Tags.PO && order !=0)
    //    {
    //        playerControl.SetCupcakeNewPos(2);
    //        other.transform.DOMove(new Vector3(gameObject.transform.position.x, playerControl.cupcakePos.position.y, playerControl.cupcakePos.position.z), .5f);
    //        playerControl.HandCupcakeParent(other.gameObject);
    //        playerControl.AddCupcakeList(other.gameObject);
    //        other.gameObject.tag = Tags.PO;
    //        order++;
    //        Debug.Log("Ýkinci Temas");
    //    }
    //}
}

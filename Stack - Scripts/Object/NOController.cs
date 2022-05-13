using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NOController : MonoBehaviour
{
    [SerializeField] public bool isContact;
    [SerializeField] Collider col;
    [SerializeField] GameObject ContackCupcake;
    [SerializeField] Animator anim;

    public void SetCol()
    {
        col.enabled = false;
    }

    public void SetNOAnimation()
    {
        ContackCupcake.SetActive(true);
        //gameObject.transform.DOLocalMoveX(- 15, 15.0f);
        anim.enabled = true;
        Debug.Log("Kaç kere girdi");
    }
}

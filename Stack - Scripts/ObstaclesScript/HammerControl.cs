using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Constans;

public class HammerControl : MonoBehaviour
{
    [SerializeField] Collider hamCollider;
    private void Start()
    {
        HammelAnimation();
    }

    void HammelAnimation()
    {
      //  transform.DORotate(new Vector3(transform.rotation.x,transform.rotation.y,-45),1f).OnComplete(() => transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 45), 1f).SetLoops(-1, LoopType.Yoyo));
        transform.DORotate(new Vector3(transform.rotation.x,transform.rotation.y,-60),1f)
           .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.HammerSet)
        {
            other.tag = Tags.Hammer;
        } 
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == Tags.Hammer)
        {
            other.tag = Tags.HammerSet;
        }
    }
}

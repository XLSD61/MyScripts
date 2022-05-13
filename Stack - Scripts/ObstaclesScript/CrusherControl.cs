using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrusherControl : MonoBehaviour
{
    private void Start()
    {
        CrusherAnimation();
    }

    void CrusherAnimation()
    {
        //  transform.DORotate(new Vector3(transform.rotation.x,transform.rotation.y,-45),1f).OnComplete(() => transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 45), 1f).SetLoops(-1, LoopType.Yoyo));
        transform.DOMoveY(4.5f, .75f)
           .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart);
    }
}

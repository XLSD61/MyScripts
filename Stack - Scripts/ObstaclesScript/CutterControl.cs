using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CutterControl : MonoBehaviour
{
    private void FixedUpdate()
    {
        CutterAnimation();
    }

    void CutterAnimation()
    {
        //  transform.DORotate(new Vector3(transform.rotation.x,transform.rotation.y,-45),1f).OnComplete(() => transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 45), 1f).SetLoops(-1, LoopType.Yoyo));
        //transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 259), 1f)
        //   .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
        transform.Rotate(0, 0, 1 * 7.5f);
    }
}

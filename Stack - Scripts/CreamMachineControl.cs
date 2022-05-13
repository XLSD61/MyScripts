using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreamMachineControl : MonoBehaviour
{

    private void Start()
    {
        //  transform.DOSpiral(1f, null, SpiralMode.ExpandThenContract, 1f, 10, 0, false).SetLoops(-1,LoopType.Restart).SetEase(Ease.InOutQuad);
        transform.DOMoveY(transform.position.y + 2f, 1f).OnComplete(() => transform.DOMoveY(transform.position.y - 2f, 1f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}

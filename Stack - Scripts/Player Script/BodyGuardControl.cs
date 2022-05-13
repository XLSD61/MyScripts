using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using DorukEvents;

public class BodyGuardControl : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject levelParent;

    private void OnEnable()
    {
        EventManager.GameStart += BodyGuardRun;
        EventManager.GameBodyGuardIdlePos += BodyGuardIdle;
    }
    private void OnDisable()
    {
        EventManager.GameStart -= BodyGuardRun;
        EventManager.GameBodyGuardIdlePos -= BodyGuardIdle;
    }
    public void BodyGuardRun(bool value)
    {
        anim.SetTrigger("Phone");
        // Debug.Log("BodyGuard Walk");
       // InvokeRepeating("BodyGuardWalkPhoneAnim", 3f, 5);
    }

    public void BodyGuardIdle()
    {
        anim.SetTrigger("Idle");
        transform.SetParent(levelParent.transform);
    }

    public void BodyGuardWalkPhoneAnim()
    {
        anim.SetTrigger("Slap");
        Debug.Log("Phone Anim Log");
        DOVirtual.DelayedCall(3f, () =>
        {
            anim.SetTrigger("Walk");
            Debug.Log("Walk Anim Log");

        });
        // anim.SetTrigger("Walk");
    }
}

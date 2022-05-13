using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Enums;

public class GirlController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] int id;
   

  //  public GirlAnim myGirlAnim;

    private void OnEnable()
    {
        EventManager.GameGirlAnim += GirlAnimChange;
    }
    private void OnDisable()
    {
        EventManager.GameGirlAnim -= GirlAnimChange;
    }

    public void GirlAnimChange(GirlAnim value, int id)
    {
        if (id == this.id)
        {

            if (value == GirlAnim.Idle)
            {
                GirlIdleAnim();
                //Debug.Log("Idle Anim");
            }

            if (value == GirlAnim.Walk)
            {
                GirlWalkAnim();
                //Debug.Log("Walk Anim");
            }

            if (value == GirlAnim.Turn)
            {
                GirlTurnAnim();
            }
            if (value == GirlAnim.Happy)
            {
                GirlHappyAnim();
            }
            if (value == GirlAnim.EndPos)
            {
                GirlEndPosAnim();
            }
            if (value == GirlAnim.Dance)
            {
                GirlEndDanceAnim();
            }
        }
       
    }

    public void GirlIdleAnim()
    {
        anim.SetTrigger("Idle");
    }
    public void GirlWalkAnim()
    {
        anim.SetTrigger("Walk");
    }

    public void GirlTurnAnim()
    {
        anim.SetTrigger("Turn");
    }

    public void GirlHappyAnim()
    {
        anim.SetTrigger("Happy");
    }

    public void GirlEndPosAnim()
    {
        anim.SetTrigger("EndPos");
    }
    public void GirlEndDanceAnim()
    {
        anim.SetTrigger("Dance");
    }
}

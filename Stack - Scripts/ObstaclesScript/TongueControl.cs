using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueControl : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject col;


    public void TongueAnim()
    {
        anim.enabled = true;
        col.SetActive(false);
    }
}

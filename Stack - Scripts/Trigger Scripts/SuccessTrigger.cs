using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class SuccessTrigger : MonoBehaviour
{
    bool isSuccess = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isSuccess)
        {
            if (other.tag == Tags.Doll)
            {
                GameManager.Instance.SuccessControl();
                isSuccess = true;
            }
        }
       
    }
}

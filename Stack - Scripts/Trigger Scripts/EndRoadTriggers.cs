using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class EndRoadTriggers : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;
    bool isLevelEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLevelEnd)
        {
            if (other.tag == Tags.Doll)
            {
                playerControl.isEndRoad = true;
                GameManager.Instance.GetCameraLevelEndPos();
                isLevelEnd = true;
            }
        }

        if (other.tag == Tags.Hand)
        {
            EventManager.GamePlayBodyGuardIdlePos();
            EventManager.GamePlayCameraParent(gameObject, true);
        }
       
    }
}

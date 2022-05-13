using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;

    [SerializeField] float negatifPos;
    [SerializeField] float pozitifPos;

    void Update()
    {
        if (!playerControl.isEndRoad)
        {
            transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, negatifPos, pozitifPos),
          transform.position.y, transform.position.z);
        }
      
    }
}

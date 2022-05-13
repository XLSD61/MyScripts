using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void Start()
    {
        SetDestroy();
    }

    void SetDestroy()
    {
        Destroy(gameObject, 0.4f);
    }
}

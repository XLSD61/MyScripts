using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] float delay;
    private void Start()
    {
        Destroy(gameObject, delay);
    }
}

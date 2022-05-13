using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReferenceHolder : MonoBehaviour
{
    [SerializeField] public ReferenceManager referenceManager;

    private void Start()
    {
        SetScript();
    }

   void SetScript()
    {
        referenceManager = FindObjectOfType<ReferenceManager>();
    }
}

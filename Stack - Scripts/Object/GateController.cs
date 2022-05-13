using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public enum GateType
    {
        Paper,
        Cake,
        Cream,
        Candy
    }

    public GateType gate;
}

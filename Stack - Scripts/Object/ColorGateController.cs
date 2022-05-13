using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class ColorGateController : MonoBehaviour
{
    public enum ColorGate
    {
        Blue,
        Red,
        Green
    }

    public ColorGate myColorGate;
    [SerializeField] Material mat;
    [SerializeField] ParticleSystem[] vfx;
    [SerializeField] Color32 colorBlue;
    [SerializeField] Color32 colorRed;
    [SerializeField] Color32 colorGreen;

    private void Start()
    {
        GateSwitch();
    }

    void GateSwitch()
    {
        Vibration.Vibrate(10);
        if (myColorGate == ColorGate.Blue)
        {
            GetComponent<Renderer>().material.color = colorBlue;
            for (int i = 0; i < vfx.Length; i++)
            {
                vfx[i].startColor = colorBlue;
                this.gameObject.tag = Tags.BlueColorGate;
            }
        }
        else if (myColorGate == ColorGate.Red)
        {
            GetComponent<Renderer>().material.color = colorRed;
            for (int i = 0; i < vfx.Length; i++)
            {
                vfx[i].startColor = colorRed;
                this.gameObject.tag = Tags.RedColorGate;
            }
        }
        else if (myColorGate == ColorGate.Green)
        {
            GetComponent<Renderer>().material.color = colorGreen;
            for (int i = 0; i < vfx.Length; i++)
            {
                vfx[i].startColor = colorGreen;
                this.gameObject.tag = Tags.GreenColorGate;
            }
        }
    }
}

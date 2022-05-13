using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IgloControl : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] Color col;

    private void Start()
    {
        mat.color = Color.white;
    }

    private void OnEnable()
    {
        EventManager.GameIgloDefenseAnim += �gloDefenseAnim;
    }
    private void OnDestroy()
    {
        EventManager.GameIgloDefenseAnim -= �gloDefenseAnim;
    }

    public void �gloDefenseAnim()
    {
        mat.DOColor(col, .15f).OnComplete(() => mat.DOColor(Color.white, .15f));
        transform.DOScale(Vector3.one * 1.1f, .15f).OnComplete(() => transform.DOScale(Vector3.one, .15f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using Enums;
using DG.Tweening;

public class Grid : MonoBehaviour
{
    [SerializeField] List<GameObject> areaAlly;
    [SerializeField] public List<GameObject> enemyAlly;

    [SerializeField] GameObject meleePrefab;
    [SerializeField] GameObject rangedPrefab;
    GameObject ally;
    [SerializeField] Transform allyHolder;
    [SerializeField] public float allyCount;
    [SerializeField] GameObject nodeHolder;

    private void OnEnable()
    {
        EventManager.GameAlignAlly += AlignAlly;
        EventManager.GameAllyCount += AllyCount;
        EventManager.GameallyDecrease += AllyDecrease;
    }
    private void OnDisable()
    {
        EventManager.GameAlignAlly -= AlignAlly;
        EventManager.GameAllyCount -= AllyCount;
        EventManager.GameallyDecrease -= AllyDecrease;
    }



    public void AlignAlly( AllyEnum value)
    {
        if (value == AllyEnum.Melee)
        {
            AlignMelee();
        }
        else if (value == AllyEnum.Ranged)
        {
            AlignRanged();
        }
    }

    void AlignMelee()
    {
        ally = Instantiate(meleePrefab, new Vector3(areaAlly[0].transform.position.x, .430f, areaAlly[0].transform.position.z), Quaternion.Euler(0, 0, 0));
        ally.transform.SetParent(allyHolder);
        areaAlly.RemoveAt(0);
    }

    void AlignRanged()
    {
        ally = Instantiate(rangedPrefab, new Vector3(areaAlly[0].transform.position.x, .430f, areaAlly[0].transform.position.z), Quaternion.Euler(0, 0, 0));
        ally.transform.SetParent(allyHolder);
        areaAlly.RemoveAt(0);
    }

    public void AllyCount()
    {
        allyCount = allyHolder.childCount;
        NodeScale();
    }

    public void AllyDecrease()
    {
        allyCount -= .5f;
        
        if (allyCount == 0)
        {
            EventManager.GamePlayFail(true);
        }
    }

     void NodeScale()
    {
        for (int i = 0; i < nodeHolder.transform.childCount; i++)
        {
            nodeHolder.transform.GetChild(i).transform.DOScale(Vector3.one,.2f);
        }
    }

    void AddArea(GameObject obj)
    {
        areaAlly.Add(obj);
    }

    void RemoveArea(GameObject obj)
    {
        areaAlly.Remove(obj);
    }
}

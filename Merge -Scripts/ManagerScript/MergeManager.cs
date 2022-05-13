using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class MergeManager : MonoBehaviour
{
    [SerializeField] MergeSO mergeSO;


    private void OnEnable()
    {
        EventManager.GameAllyMerge += Merge;
    }

    private void OnDisable()
    {
        EventManager.GameAllyMerge -= Merge;
    }



    public void Merge(AllyEnum allyEnum,int value, GameObject other, GameObject go, Transform _parent)
    {
        if (allyEnum == AllyEnum.Melee)
        {
            MergeMelee(value, other, go, _parent);
        }
        else if (allyEnum == AllyEnum.Ranged)
        {
            MergeRanged(value, other, go, _parent);
        }
    }

    void MergeMelee(int value, GameObject other, GameObject go ,Transform _parent)
    {
        Instantiate(mergeSO.allyMelee[value], other.transform.position, Quaternion.Euler(0, 0, 0),_parent);
        Instantiate(mergeSO.mergeVFX, other.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(go);
        Destroy(other);
    }


    void MergeRanged(int value, GameObject other, GameObject go, Transform _parent)
    {
        Instantiate(mergeSO.allyRanged[value], other.transform.position, Quaternion.Euler(0, 0, 0),_parent);
        Instantiate(mergeSO.mergeVFX, other.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(go);
        Destroy(other);
    }
}

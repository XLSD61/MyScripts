using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MergeSO", menuName = "MagnoliaGames / Manager / Merge")]
public class MergeSO : ScriptableObject
{
    public GameObject[] allyMelee;
    public GameObject[] allyRanged;
    public GameObject mergeVFX;
}

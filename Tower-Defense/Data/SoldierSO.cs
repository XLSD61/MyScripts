using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoldierSO", menuName = "MagnoliaGames/Soldier", order = 2)]
public class SoldierSO : ScriptableObject
{
    public int soliderID;
    public float damage;
    public float baseFireTime;

    public GameObject[] soldiers;
}

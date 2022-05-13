using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "Ally", menuName = "MagnoliaGames / Ally")]
public class AllySO : ScriptableObject
{
    public int levelID;
    public int baseHealh = 100;
    public int damage;
    public float speed = 1f;
    public Material mainMat;
    public Material changeMat;
    public GameObject weapon;
    public SoldierEnum soldierEnum;
    public AllyEnum allyEnum;

}

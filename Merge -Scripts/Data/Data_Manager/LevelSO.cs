using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "MagnoliaGames / Manager / Level")]
public class LevelSO : ScriptableObject
{
    public GameObject[] levels;
    public int saveLevelMod;
}

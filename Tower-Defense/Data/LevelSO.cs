using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MagnoliaGames/Level/LevelSO")]
public class LevelSO : ScriptableObject
{
    public GameObject[] levels;
    public int saveLevelMod;
}

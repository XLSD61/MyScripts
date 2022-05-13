using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "MagnoliaGames / Levels / LevelData")]
public class LevelDataSO : ScriptableObject
{
    public List<int> enemyMeleeRank;
    public List<int> enemyMeleeOrder;
    [Header ("------------------------------------------")]
    public List<int> enemyRangedRank;
    public List<int> enemyRangedOrder;
}

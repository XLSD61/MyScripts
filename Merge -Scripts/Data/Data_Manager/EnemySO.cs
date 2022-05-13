using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySO", menuName = "MagnoliaGames / Manager / Enemy")]
public class EnemySO : ScriptableObject
{
    public GameObject[] meleeEnemys;
    public GameObject[] rangedEnemys;
}

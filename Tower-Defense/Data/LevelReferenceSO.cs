using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelReference", menuName = "MagnoliaGames/Level", order = 3)]
public class LevelReferenceSO : ScriptableObject
{
    public RectTransform[] carts;
    public int baseEnemyCount;
}

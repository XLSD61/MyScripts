using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReferenceHolder : MonoBehaviour
{
    [SerializeField] public LevelReferenceSO levelReferenceSO;
    [HideInInspector] public int enemyCount;
    [SerializeField] public int deadEnemy;

    private void OnEnable()
    {
        EventManager.GameDeadEnemyCount += SuccsesControl;
    }
    private void OnDisable()
    {
        EventManager.GameDeadEnemyCount -= SuccsesControl;
    }

    private void Start()
    {
        enemyCount = levelReferenceSO.baseEnemyCount;
        EventManager.GamePlayEnemyCount(enemyCount);
        AlignCart();
    }

    void AlignCart()
    {
        for (int i = 0; i < levelReferenceSO.carts.Length; i++)
        {
            EventManager.GamePlayAlignCart(i,levelReferenceSO.carts[i]);

        }
    }

    public void SuccsesControl()
    {
        deadEnemy++;
        if (deadEnemy == levelReferenceSO.baseEnemyCount)
        {
            EventManager.GamePlaySuccess(true);
        }
    }
}

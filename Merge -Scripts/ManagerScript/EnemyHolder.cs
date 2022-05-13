using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    [SerializeField] EnemySO enemySO;
    [SerializeField] LevelReferenceHolder levelReferenceHolder;
    [SerializeField] Grid grid;
    [SerializeField] public float enemyCount;

    private void OnEnable()
    {
        EventManager.GameEnemyDecrease += EnemyDecrease;
    }

    private void OnDisable()
    {
        EventManager.GameEnemyDecrease -= EnemyDecrease;
    }

    private void Start()
    {
        AlignEnemyMelee();
        AlignEnemyRanged();
        enemyCount = transform.childCount;
    }



    void AlignEnemyMelee()
    {
        if (levelReferenceHolder.levelDataSO.enemyMeleeRank != null)
        {
            for (int i = 0; i < levelReferenceHolder.levelDataSO.enemyMeleeRank.Count; i++)
            {
                Instantiate(enemySO.meleeEnemys[levelReferenceHolder.levelDataSO.enemyMeleeRank[i]]
                    ,new Vector3(grid.enemyAlly[levelReferenceHolder.levelDataSO.enemyMeleeOrder[i]].transform.position.x,.435f, grid.enemyAlly[levelReferenceHolder.levelDataSO.enemyMeleeOrder[i]].transform.position.z)
                    , Quaternion.Euler(0,180,0)
                    ,transform);
            }
        }
    }

    void AlignEnemyRanged()
    {
        if (levelReferenceHolder.levelDataSO.enemyRangedRank != null)
        {
            for (int i = 0; i < levelReferenceHolder.levelDataSO.enemyRangedRank.Count; i++)
            {
                Instantiate(enemySO.rangedEnemys[levelReferenceHolder.levelDataSO.enemyRangedRank[i]]
                    ,new Vector3(grid.enemyAlly[levelReferenceHolder.levelDataSO.enemyRangedOrder[i]].transform.position.x,.435f, grid.enemyAlly[levelReferenceHolder.levelDataSO.enemyRangedOrder[i]].transform.position.z)
                    , Quaternion.Euler(0, 180, 0)
                    ,transform);
            }
        }
    }


    public void EnemyDecrease()
    {
        enemyCount -= .5f;
        if (enemyCount == 0)
        {
            EventManager.GamePlaySuccess(true);
        }
    }
}

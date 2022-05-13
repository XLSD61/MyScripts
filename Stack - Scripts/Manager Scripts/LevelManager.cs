using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DorukEvents;

public class LevelManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] LevelSO LevelSO;

    GameObject level;

    [SerializeField] public int refSuccessCount;
    [SerializeField] public Transform refStartPos;

    private void OnEnable()
    {
        EventManager.GameNextLevel += LevelSuccess;
        EventManager.GameLevelData += SetLevelData;
    }

    private void OnDisable()
    {
        EventManager.GameNextLevel -= LevelSuccess;
        EventManager.GameLevelData -= SetLevelData;


    }
    private void Start()
    {
       // GetLevelData();
        SetLevel();
        SetReferenceHolder();
    }

    void SetReferenceHolder()
    {
        //refSuccessCount = level.GetComponent<LevelReferanceHolder>().SuccessCount;
        //refStartPos = level.GetComponent<LevelReferanceHolder>().startPos;
    }
    void SetLevel()
    {
        level = Instantiate(LevelSO.levels[LevelSO.saveLevelMod]);
    }

    void GetLevelData()
    {
       // EventManager.GamePlayLevelData(LevelSO.saveLevelMod, LevelSO.levels.Length);
    }

    void SetLevelData(int levelNoValue)
    {
        LevelSO.saveLevelMod = levelNoValue % LevelSO.levels.Length;
    }
    public void LevelSuccess()
    {
        Destroy(level);
        EventManager.GamePlaySaveLevelPlus();
        //GetLevelData();
        SetLevel();
        SetReferenceHolder();
    }

    public void LevelRestart()
    {
        Destroy(level);
        SetLevel();
        SetReferenceHolder();
    }
}

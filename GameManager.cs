//using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DorukEvents;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
   //     SetBools();
        FPSLine();
        SetTime(1);
        Set3PartSDK();
    }

    private void OnEnable()
    {
        //EventManager.GameFail += SuccessControl;
    }

    private void OnDisable()
    {
        //EventManager.GameFail -= SuccessControl;

    }

    void FPSLine()
    {
       // Application.targetFrameRate = 60;
    }

    void Set3PartSDK()
    {
    //    GameAnalyticsSDK.GameAnalytics.Initialize();
    }
    void SetTime(float value)
    {
        Time.timeScale = value;
    }
    void GetPlayButton(bool value)
    {
        EventManager.GamePlayStart(value);
    }
    void GetSuccessPanel(bool value)
    {
        EventManager.GamePlaySuccess(value);
    }

    //public void StartGame()
    //{
    //    EventManager.GamePlayStart(false);
    //    SetTime(1);
    //    EventManager.GamePlayCamerePlayPos();
    //}

    public void GetCameraLevelEndPos()
    {
        EventManager.GamePlayCameraLevelEndPos();
    }

    public void NextLevel()
    {
        EventManager.GamePlayCameraLevelStartPos();
        EventManager.GamePlayNextLevel();
        GetSuccessPanel(false);
        GetPlayButton(true);
       // referenceManager.levelManager.LevelSuccess();
        SetTime(0);
    }

    public void RestartLevel()
    {
    }
}

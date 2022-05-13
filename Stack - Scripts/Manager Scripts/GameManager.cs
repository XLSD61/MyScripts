//using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
//using DorukEvents;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] ReferenceManager referenceManager;
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
        SetTime(0);
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
        Application.targetFrameRate = 60;
    }

    void Set3PartSDK()
    {
    //    GameAnalyticsSDK.GameAnalytics.Initialize();
        FB.Init();
    }
    void SetTime(float value)
    {
        Time.timeScale = value;
    }
    void GetPlayButton(bool value)
    {
        // referenceManager.uIManager.SetPlayButton(value);
        EventManager.GamePlayStart(value);
    }
    void GetSuccessPanel(bool value)
    {
        // EventManager.GamePlaySuccess();
        EventManager.GamePlaySuccess(value);
    }

    void GetFailPanel(bool value)
    {
        //referenceManager.uIManager.SetFailPanel(value);
    }

    public void StartGame()
    {
       // GetPlayButton(false);
        EventManager.GamePlayStart(false);
        SetTime(1);
    }

    public void GetCameraLevelEndPos()
    {
        //referenceManager.cameraManager.SetCameraLevelEndPos();
        EventManager.GamePlayCameraLevelEndPos();
    }

    public void SuccessControl()
    {
        EventManager.GamePlaySuccess(true);
        //GetSuccessPanel(true);
    }
    public void FailControl()
    {
        EventManager.GamePlayFail();
        StartCoroutine(FailCoroutine());
    }

    IEnumerator FailCoroutine()
    {
       // referenceManager.audioManager.SetFailSound();
        yield return new WaitForSeconds(.5f);
        GetFailPanel(true);
    }

    public void NextLevel()
    {
        EventManager.GamePlayCameraParent(transform.parent.transform.gameObject, false);
        EventManager.GamePlayCameraLevelStartPos();
        EventManager.GamePlayNextLevel();
        GetSuccessPanel(false);
        GetPlayButton(true);
       // referenceManager.levelManager.LevelSuccess();
        SetTime(0);
    }

    public void RestartLevel()
    {
        GetFailPanel(false);
      //  referenceManager.levelManager.LevelRestart();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;



    public class EventManager
    {
        //Game
        public delegate void onGamePlaySuccess(bool value);
        public static event onGamePlaySuccess GameSuccess;

        public static void GamePlaySuccess(bool value)
        {
            GameSuccess?.Invoke(value);
        }


        public delegate void onGamePlayFail();
        public static event onGamePlayFail GameFail;

        public static void GamePlayFail()
        {
            GameFail?.Invoke();
        }

        public delegate void onGamePlayStart(bool value);
        public static event onGamePlayStart GameStart;

        public static void GamePlayStart(bool value)
        {
            GameStart?.Invoke(value);
        }


        public delegate void onGameNextLevel();
        public static event onGameNextLevel GameNextLevel;

        public static void GamePlayNextLevel()
        {
            GameNextLevel?.Invoke();
        }

        //Camera

        public delegate void onGameCamereLevelStartPos();
        public static event onGameCamereLevelStartPos GameCameraLevelStartPos;

        public static void GamePlayCameraLevelStartPos()
        {
            GameCameraLevelStartPos?.Invoke();
        }

        public delegate void onGameCamereLevelEndPos();
        public static event onGameCamereLevelEndPos GameCameraLevelEndPos;

        public static void GamePlayCameraLevelEndPos()
        {
            GameCameraLevelEndPos?.Invoke();
        }

    public delegate void onGameCamereParent(GameObject parent, bool value);
    public static event onGameCamereParent GameCameraParent;

    public static void GamePlayCameraParent(GameObject parent, bool value)
    {
        GameCameraParent?.Invoke(parent, value);
    }

    //Save

    public delegate void onGameSaveLevelPlus();
        public static event onGameSaveLevelPlus GameSaveLevelPlus;

        public static void GamePlaySaveLevelPlus()
        {
            GameSaveLevelPlus?.Invoke();
        }

        public delegate void onGameLevelData(int levelMod);
        public static event onGameLevelData GameLevelData;

        public static void GamePlayLevelData(int levelMod)
        {
            GameLevelData?.Invoke( levelMod);
        }

        //Level Count
        public delegate void onGameLevelCount(int value);
        public static event onGameLevelCount GameLevelCount;

        public static void GamePlayLevelCount(int value)
        {
            GameLevelCount?.Invoke(value);
        }

        public delegate void onGameGirlAnim(GirlAnim value, int id);
        public static event onGameGirlAnim GameGirlAnim;

        public static void GamePlayGirlAnim(GirlAnim value ,int id)
        {
            GameGirlAnim?.Invoke(value,id);
        }

    public delegate void onGameBodyGuardIdlePos();
    public static event onGameBodyGuardIdlePos GameBodyGuardIdlePos;

    public static void GamePlayBodyGuardIdlePos()
    {
        GameBodyGuardIdlePos?.Invoke();
    }

}




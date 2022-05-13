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

    public delegate void onGameHealthSlider();
    public static event onGameHealthSlider GameHealthSlider;

    public static void GamePlayHealthSlider()
    {
        GameHealthSlider?.Invoke();
    }

    public delegate void onGameAlignCart(int k , RectTransform cart);
    public static event onGameAlignCart GameAlignCart;

    public static void GamePlayAlignCart(int k, RectTransform cart)
    {
        GameAlignCart?.Invoke(k, cart);
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
    public delegate void onGameCamerePlayPos();
    public static event onGameCamerePlayPos GameCamerePlayPos;

    public static void GamePlayCamerePlayPos()
    {
        GameCamerePlayPos?.Invoke();
    }

    public delegate void onGameCamereLevelEndPos();
        public static event onGameCamereLevelEndPos GameCameraLevelEndPos;

        public static void GamePlayCameraLevelEndPos()
        {
            GameCameraLevelEndPos?.Invoke();
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

        // Count
        public delegate void onGameLevelCount(int value);
        public static event onGameLevelCount GameLevelCount;

        public static void GamePlayLevelCount(int value)
        {
            GameLevelCount?.Invoke(value);
        }


    public delegate void onGameEnemyCount(int value);
    public static event onGameEnemyCount GameEnemyCount;

    public static void GamePlayEnemyCount(int value)
    {
        GameEnemyCount?.Invoke(value);
    }

    public delegate void onGameDeadEnemyCount();
    public static event onGameDeadEnemyCount GameDeadEnemyCount;

    public static void GamePlayDeadEnemyCount()
    {
        GameDeadEnemyCount?.Invoke();
    }


    public delegate void onGameAddEnemyList(GameObject enemy , int id);
    public static event onGameAddEnemyList GameAddEnemyList;

    public static void GamePlayAddEnemyList(GameObject enemy , int id)
    {
        GameAddEnemyList?.Invoke(enemy , id);
    }

    public delegate void onGameRemoveEnemyList(GameObject enemy , int id);
    public static event onGameRemoveEnemyList GameRemoveEnemyList;

    public static void GamePlayRemoveEnemyList(GameObject enemy , int id)
    {
        GameRemoveEnemyList?.Invoke(enemy , id);
    }

    public delegate void onGameDeadEnemyList(GameObject enemy);
    public static event onGameDeadEnemyList GameDeadEnemyList;

    public static void GamePlayDeadEnemyList(GameObject enemy)
    {
        GameDeadEnemyList?.Invoke(enemy);
    }

    public delegate void onGameIgloDefenseAnim();
    public static event onGameIgloDefenseAnim GameIgloDefenseAnim;

    public static void GamePlayIgloDefenseAnim()
    {
        GameIgloDefenseAnim?.Invoke();
    }


}




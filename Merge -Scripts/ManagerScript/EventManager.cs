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


        public delegate void onGamePlayFail(bool value);
        public static event onGamePlayFail GameFail;

        public static void GamePlayFail(bool value)
        {
            GameFail?.Invoke(value);
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



        public delegate void onGameAlignAlly(AllyEnum value);
        public static event onGameAlignAlly GameAlignAlly;

        public static void GamePlayAlignAlly(AllyEnum value)
        {
            GameAlignAlly?.Invoke(value);
        }


    public delegate void onGameAllyMerge(AllyEnum allyEnum, int value, GameObject other, GameObject go,Transform _parent);
    public static event onGameAllyMerge GameAllyMerge;

    public static void GamePlayAllyMerge(AllyEnum allyEnum, int value, GameObject other, GameObject go, Transform _parent )
    {
        GameAllyMerge?.Invoke(allyEnum,value,other,go, _parent);
    }

    public delegate void onGameAllyCount();
    public static event onGameAllyCount GameAllyCount;

    public static void GamePlayAllyCount()
    {
        GameAllyCount?.Invoke();
    }

    public delegate void onGameAddEnemyList(int ID, GameObject obj);
    public static event onGameAddEnemyList GameAddEnemyList;

    public static void GamePlayAddEnemyList(int ID, GameObject obj)
    {
        GameAddEnemyList?.Invoke(ID, obj);
    }

    public delegate void onGameRemoveEnemyList(GameObject obj);
    public static event onGameRemoveEnemyList GameRemoveEnemyList;

    public static void GamePlayRemoveEnemyList( GameObject obj)
    {
        GameRemoveEnemyList?.Invoke( obj);
    }

    public delegate void onGameTriggerActiveted();
    public static event onGameTriggerActiveted GameTriggerActiveted;

    public static void GamePlayTriggerActiveted()
    {
        GameTriggerActiveted?.Invoke();
    }


    public delegate void onGameUpdateHealthBar(int ID, int health);
    public static event onGameUpdateHealthBar GameUpdateHealthBar;

    public static void GamePlayUpdateHealthBar(int ID, int health)
    {
        GameUpdateHealthBar?.Invoke(ID, health);
    }

    public delegate void onGameDeleteHealthBar(int ID);
    public static event onGameDeleteHealthBar GameDeleteHealthBar;

    public static void GamePlayDeleteHealthBar(int ID)
    {
        GameDeleteHealthBar?.Invoke(ID);
    }

    public delegate void onGameAddMoney();
    public static event onGameAddMoney GameAddMoney;

    public static void GamePlayAddMoney()
    {
        GameAddMoney?.Invoke();
    }


    public delegate void onGameEnemyDecrease();
    public static event onGameEnemyDecrease GameEnemyDecrease;

    public static void GamePlayEnemyDecrease()
    {
        GameEnemyDecrease?.Invoke();
    }

    public delegate void onGameAllyDecrease();
    public static event onGameAllyDecrease GameallyDecrease;

    public static void GamePlayAllyDecrease()
    {
        GameallyDecrease?.Invoke();
    }


    //Cannon Catapult


    public delegate void onGameCannonCatapultAttack(int id);
    public static event onGameCannonCatapultAttack GameCannonCatapultAttack;

    public static void GamePlayCannonCatapultAttack(int id)
    {
        GameCannonCatapultAttack?.Invoke(id);
    }

    public delegate void onGameCannonCatapultIdle(int id);
    public static event onGameCannonCatapultIdle GameCannonCatapultIdle;

    public static void GamePlayCannonCatapultIdle(int id)
    {
        GameCannonCatapultIdle?.Invoke(id);
    }

}




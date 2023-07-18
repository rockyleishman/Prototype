using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public GameData GameDataObject;
    [SerializeField] public LevelConditions LevelConditionsObject;
    [SerializeField] public GameEvent PauseGameEvent;
    [SerializeField] public GameEvent UnpauseGameEvent;
    [SerializeField] public GameEvent LevelStartEvent;

    private void Start()
    {
        //pause game
        PauseGameEvent.TriggerEvent();

        //start level
        LevelStartEvent.TriggerEvent();
    }

    public void LevelStart()
    {
        //init game data
        GameDataObject.IsGravityFlipped = false;
        GameDataObject.LevelTimeRemaining = LevelConditionsObject.TimerStartingAmount;
        GameDataObject.LevelPackageCondition = LevelConditionsObject.PackageHP;

        //start game
        UnpauseGameEvent.TriggerEvent();
    }
}

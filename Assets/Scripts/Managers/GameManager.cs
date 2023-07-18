using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public GameData GameDataObject;
    [SerializeField] public LevelConditions LevelSettingsObject;
    [SerializeField] public GameEvent LevelStartEvent;

    private void Start()
    {
        //pause game
        Time.timeScale = 0.0f;

        //start level
        LevelStartEvent.TriggerEvent();
    }

    public void LevelStart()
    {
        //init game data
        GameDataObject.IsGravityFlipped = false;
        GameDataObject.LevelTimeRemaining = LevelSettingsObject.TimerStartingAmount;
        GameDataObject.LevelPackageCondition = LevelSettingsObject.PackageHP;

        //start time
        Time.timeScale = 1.0f;
    }
}

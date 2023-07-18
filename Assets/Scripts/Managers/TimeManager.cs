using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] public GameData GameDataObject;
    [SerializeField] public LevelConditions LevelSettingsObject;
    [SerializeField] public GameEvent LevelFailEvent;

    void Update()
    {
        //update time
        GameDataObject.LevelTimeRemaining -= Time.deltaTime;

        //check for loss conditions
        if (GameDataObject.LevelTimeRemaining <= 0.0f)
        {
            //trigger level failure
            LevelFailEvent.TriggerEvent();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventObject", menuName = "GameEvent", order = 0)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void TriggerEvent()
    {
        foreach (GameEventListener listener in _listeners)
        {
            listener.OnTriggered();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] GameData GameDataObject;

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        GameDataObject.IsGamePaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        GameDataObject.IsGamePaused = false;
    }
}

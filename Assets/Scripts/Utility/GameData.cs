using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataObject", menuName = "GameData", order = 0)]
public class GameData : ScriptableObject
{
    [SerializeField] public bool IsGamePaused = false;
    [SerializeField] public bool IsGravityFlipped = false;
    [SerializeField] public float LevelTimeRemaining = 0.0f;
    [SerializeField] public float LevelPackageCondition = 0.0f;
}

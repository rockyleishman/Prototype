using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConditionsObject", menuName = "LevelConditions", order = 0)]
public class LevelConditions : ScriptableObject
{
    [SerializeField] public float TimerStartingAmount = 60.0f;
    [SerializeField] public float PackageHP = 3.0f;
}

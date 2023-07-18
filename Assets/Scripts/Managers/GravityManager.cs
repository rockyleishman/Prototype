using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : Singleton<GravityManager>
{
    [SerializeField] public GameData GameDataObject;

    private void Start()
    {
        GameDataObject.IsGravityFlipped = false;
    }

    public void InvertGravity()
    {
        GameDataObject.IsGravityFlipped = true;
    }

    public void RevertGravity()
    {
        GameDataObject.IsGravityFlipped = false;
    }
}

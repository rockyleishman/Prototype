using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This code is just to set a delay between collecting all collectables and resetting the level.
public static class WaitCode
{ 
    public static void Wait (this MonoBehaviour mono, float delay, UnityAction action)
    { mono.StartCoroutine (ExacuteAction (delay, action)); }

    private static IEnumerator ExacuteAction (float delay, UnityAction action)
    {
       yield return new WaitForSecondsRealtime (delay);
        action.Invoke ();
        yield break;
    }
}

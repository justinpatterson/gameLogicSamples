using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseBehavior_BASE : MonoBehaviour
{
    public bool isPhaseActive = false;

    public virtual void StartPhase()
    {
        if (isPhaseActive) return;
        Debug.Log("Starting phase... " + this.GetType().Name);
        isPhaseActive = true;
        GameManager_BASE.onUpdateDelegateEvent += OnUpdate;
    }

    protected virtual void OnUpdate()
    {
        Debug.Log("BASE Behavior Update.");
    }

    public virtual void EndPhase()
    { 
        if(!isPhaseActive) return;
        Debug.Log("Ending phase... " + this.GetType().Name);
        GameManager_BASE.onUpdateDelegateEvent -= OnUpdate;
        isPhaseActive = false;
    }
}

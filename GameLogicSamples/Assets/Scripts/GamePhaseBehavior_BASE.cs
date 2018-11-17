using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseBehavior_BASE : MonoBehaviour
{
    public bool isPhaseActive = false;

    public void StartPhase()
    {
        Debug.Log("Starting phase... " + this.GetType().Name);
        isPhaseActive = true;
    }
    public void EndPhase()
    {
        Debug.Log("Ending phase... " + this.GetType().Name);
        isPhaseActive = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseBehavior_INIT : GamePhaseBehavior_BASE
{
    public override void StartPhase()
    {
        base.StartPhase();
    }

    protected override void OnUpdate()
    {
        Debug.Log("INIT Behavior Update.");
    }

    public override void EndPhase()
    {
        base.EndPhase();
    }
}

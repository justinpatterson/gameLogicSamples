using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_BASE : MonoBehaviour {

    public static GameManager_BASE instance = null;

    [SerializeField]
    GamePhases currentGamePhase = GamePhases.init;
    [SerializeField]
    List<GamePhaseInfo> gamePhaseInfos;

    Dictionary<GamePhases, GamePhaseBehavior_BASE> _gamePhaseDictionaryReference = new Dictionary<GamePhases, GamePhaseBehavior_BASE>();

    public delegate void OnUpdateDelegate();
    public static OnUpdateDelegate onUpdateDelegateEvent;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Debug.Log("Base awake has been called.");
        PopulateGamePhaseDictionary();

        InitGame();
    }

    protected virtual void InitGame()
    {
        Debug.Log("Game has been Initialized.");
        TriggerPhaseTransition(GamePhases.init);
    }

    void PopulateGamePhaseDictionary()
    {
        foreach (GamePhaseInfo gpi in gamePhaseInfos)
        {
            if (_gamePhaseDictionaryReference.ContainsKey(gpi.phaseCategory))
                Debug.Log("Duplicate entry for: " + gpi.phaseCategory.ToString());
            else
                _gamePhaseDictionaryReference.Add(gpi.phaseCategory, gpi.phaseBehavior);
        }
    }

    protected virtual void TriggerPhaseTransition(GamePhases nextGamePhase)
    {
        GamePhaseBehavior_BASE currentPhaseBehavior = _gamePhaseDictionaryReference[currentGamePhase];
        GamePhaseBehavior_BASE nextPhaseBehavior = _gamePhaseDictionaryReference[nextGamePhase];

        if (nextGamePhase != currentGamePhase || !currentPhaseBehavior.isPhaseActive)
        {
            currentPhaseBehavior.EndPhase();
            nextPhaseBehavior.StartPhase();
        }
    }

    private void Update()
    {
        if (onUpdateDelegateEvent != null) onUpdateDelegateEvent();
        if (Input.GetKeyDown(KeyCode.Space)) TriggerPhaseTransition(GamePhases.start);
    }

}


[System.Serializable]
public class GamePhaseInfo
{
    public GamePhases phaseCategory;
    public GamePhaseBehavior_BASE phaseBehavior;
}
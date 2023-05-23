using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : StaticInstances<AppManager>
{
    // Start is called before the first frame update
    [SerializeField] Canvas ToDo;
    [SerializeField] Canvas Timer;
    [SerializeField] Canvas CreateEvent;
    public AppState appState { get; private set; } = AppState.homeScreen;
    public static event Action<AppState> AppStateChanged;
    void Awake()
    {
        base.Awake();
        Timer.enabled = false;
        CreateEvent.enabled = false;
    }

    public void ChangeState(AppState newState)
    {
        appState = newState;
        switch (newState)
        {
            case AppState.homeScreen:
                break;
            case AppState.timer:
                //HandleTimer();
                break;
            case AppState.timerRunning:
                break;
            case AppState.yourProggress:
                break;
            case AppState.toDoEditing:
                break;
            default:
                break;
        }
        AppStateChanged.Invoke(newState);
    }

    public void OpenTimer()
    {
        DisableAllUI();
        Timer.enabled = true;
        
    }
    public void OpenToDo()
    {
        if (appState == AppState.timerRunning) return;
        DisableAllUI();
        ToDo.enabled = true;
    }
    public void OpenStats()
    {
        if (appState == AppState.timerRunning) return;
    }

    public void OpenCreateEvent()
    {
        DisableAllUI();
        CreateEvent.enabled = true;
    }
    private void DisableAllUI()
    {
        Timer.enabled = false;
        ToDo.enabled = false;
        CreateEvent.enabled = false;
    }
}

public enum AppState
{
    homeScreen = 0,
    timer=1,
    timerRunning=2,
    countingPause = 5,
    yourProggress=3,
    toDoEditing=4
}

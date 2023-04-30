using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : StaticInstances<AppManager>
{
    // Start is called before the first frame update
    [SerializeField] Canvas home;
    [SerializeField] Canvas timer;
    public AppState appState { get; private set; } = AppState.homeScreen;
    public static event Action<AppState> AppStateChanged;
    void Awake()
    {
        base.Awake();
    }

    public void ChangeState(AppState newState)
    {
        appState = newState;
        switch (newState)
        {
            case AppState.homeScreen:
                break;
            case AppState.timer:
                HandleTimer();
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

    private void HandleTimer()
    {
        home.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
    }
}

public enum AppState
{
    homeScreen = 0,
    timer=1,
    timerRunning=2,
    yourProggress=3,
    toDoEditing=4
}

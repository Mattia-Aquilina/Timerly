using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : VisualElement
{
    public new class UxmlFactory : UxmlFactory<MenuManager, UxmlTraits> { }
    public new class UxmlTraits : VisualElement.UxmlTraits { }

    private VisualElement ScreenCenter;
    public MenuManager()
    {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        AppManager.AppStateChanged += OnStateChanged;
    }

    public void OnGeometryChanged(GeometryChangedEvent evt)
    {
        ScreenCenter = this.Q("BottomBar");

        this.Q("ToDo")?.RegisterCallback<ClickEvent>(ev => OpenToDo());
        this.Q("Timer")?.RegisterCallback<ClickEvent>(ev => OpenTimer());
        this.Q("Stats")?.RegisterCallback<ClickEvent>(ev => OpenStats());
    }

    private void OnStateChanged(AppState appState)
    {
        
    }
    private void OpenToDo()
    {
        Debug.Log("ToDO pressed");
        AppManager.Instance.OpenToDo();
    }

    private void OpenTimer()
    {
        Debug.Log("timer pressed");
        AppManager.Instance.OpenTimer();
    }

    private void OpenStats()
    {
        Debug.Log("Stats pressed");
        AppManager.Instance.OpenStats();
    }
}

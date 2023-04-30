using System.Collections;
using System.Collections.Generic;
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
        ScreenCenter = this.Q("ScreenCenter");

        this.Q("ToDo")?.RegisterCallback<ClickEvent>(ev => OpenToDo());
        this.Q("Timer")?.RegisterCallback<ClickEvent>(ev => TimerState());
        this.Q("Progress")?.RegisterCallback<ClickEvent>(ev => ShowProgress());
    }

    private void OnStateChanged(AppState appState)
    {

    }
    private void OpenToDo()
    {

    }

    private void TimerState()
    {
        ScreenCenter.style.display = DisplayStyle.None;
        AppManager.Instance.ChangeState(AppState.timer);
    }

    private void ShowProgress()
    {

    }
}

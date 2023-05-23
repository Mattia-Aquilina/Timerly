using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    //Timer values
    public float TimerDuration = 0f;
    public float currentPauseCount = 0f;
    public Stack<float> pauseStack = new();
    [SerializeField] int MaxDuration = 120;
    [Range(1, 20)] int precision;

    //Graphic components
   [SerializeField] TextMeshProUGUI timerValue;
   [SerializeField] Image timerCircle;
   [SerializeField] Color pauseColor;
   [SerializeField] Color runningColor;

    //Timer state
    public TimerStates state = TimerStates.init;
    public int GetMaxDuration() => MaxDuration;
    public float LeftTimer;
    //variabile che indica lo stato del timer, false -> timer off true -> timer on
    private bool timerOn = false;

    void Awake()
    {
        timerCircle.fillAmount = 1;
        timerCircle.color = runningColor;
    }

    void Update()
    {
        if (state == TimerStates.init)
        {
            timerValue.text = TimerDuration + ":00";
            return;
        }

        if (state == TimerStates.running && LeftTimer > 0f)
        {
            LeftTimer -= Time.deltaTime;

            //Stampiamo a video
            float minutes = Mathf.FloorToInt(LeftTimer / 60);
            float seconds = Mathf.FloorToInt(LeftTimer % 60);
            timerValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            //aggiorniamo il valore del cerchio
            timerCircle.fillAmount = (float)Math.Round(LeftTimer / (TimerDuration * 60), precision);
            return;
        } 
        
        if(state == TimerStates.pause)
        {
            currentPauseCount += Time.deltaTime;
            //Stampiamo a video
            float minutes = Mathf.FloorToInt(currentPauseCount / 60);
            float seconds = Mathf.FloorToInt(currentPauseCount % 60);
            timerValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
        }
    }

   

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        Debug.Log("clicked");
        //Il timer è stato cliccato
        switch (state)
        {
            case TimerStates.init:
                InitTimer();
                break;
            case TimerStates.running:
                StopTimer();
                break;
            case TimerStates.pause:
                StartTimer();
                break;
            default:
                break;
        }

    }

    private void InitTimer()
    {
        //riempiamo la grafica a cerchio
        timerCircle.fillAmount = 1;
        //calcoliamo la durata del timer e impostiamo il valore corretto del testo
        LeftTimer = TimerDuration * 60;
        GetComponentInChildren<TimeSelector>().gameObject.SetActive(false);

        StartTimer();
    }

    /// <summary>
    /// Metodo che gestisce l'avvio del timer. Dunque prepara la grafica e successivamente avvia il timer
    /// </summary>

    private void StartTimer()
    {
        timerCircle.color = runningColor;
        AppManager.Instance.ChangeState(AppState.timerRunning);
        //riempiamo la grafica a cerchio
        //calcoliamo la durata del timer e impostiamo il valore corretto del testo
        timerValue.text = string.Format("{0:00}:{1:00}", TimerDuration * 60, 0);

        state = TimerStates.running;
    }

    private void StopTimer()
    {
        pauseStack.Push(currentPauseCount);
        currentPauseCount = 0;

        GetComponentInChildren<TimeSelector>().gameObject.SetActive(false);
        AppManager.Instance.ChangeState(AppState.countingPause);
        timerCircle.color = pauseColor;

        state = TimerStates.pause;
    }

}

public enum TimerStates
{
    init = 0,
    running = 1,
    pause = 2
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI timerValue;
    [SerializeField] Image timerCircle;
    [SerializeField] float TimerDuration = 25f;
    [SerializeField] [Range(1, 20)] int precision;

    public float LeftTimer;
    //variabile che indica lo stato del timer, false -> timer off true -> timer on
    private bool timerOn = false;

    void Awake()
    {
        AppManager.AppStateChanged += OnStateChange;
        timerCircle.fillAmount = 1;
    }

    void Update()
    {
        if (timerOn && LeftTimer > 0f)
        {
            LeftTimer -= Time.deltaTime;

            //Stampiamo a video
            float minutes = Mathf.FloorToInt(LeftTimer / 60);
            float seconds = Mathf.FloorToInt(LeftTimer % 60);
            timerValue.text = string.Format("{0:00}:{1:00}", minutes , seconds);

            //aggiorniamo il valore del cerchio
            timerCircle.fillAmount = (float) Math.Round(LeftTimer/(TimerDuration*60) , precision);
        }    
    }

    private void OnStateChange(AppState newState)
    {

    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        Debug.Log("clicked");
        //Il timer è stato cliccato
        if (!timerOn)
            StartTimer();
        else
            StopTimer();
    }

    /// <summary>
    /// Metodo che gestisce l'avvio del timer. Dunque prepara la grafica e successivamente avvia il timer
    /// </summary>
    private void StartTimer()
    {
        //riempiamo la grafica a cerchio
        timerCircle.fillAmount = 1;
        //calcoliamo la durata del timer e impostiamo il valore corretto del testo
        LeftTimer = TimerDuration*60;
        timerValue.text = string.Format("{0:00}:{1:00}", TimerDuration * 60, 0);
        timerOn = true;
    }

    private void StopTimer()
    {
        timerOn = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeSelector : MonoBehaviour, IDragHandler
{
    [SerializeField]float lastRotation = 0;
    [SerializeField] float currentRotation = 0f;
    [SerializeField] Timer timer;
    // Start is called before the first frame update
    void Awake()
    {
        transform.rotation = Quaternion.Euler(0, 0, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        
        var screen = new Vector2(Screen.width / 2, Screen.height / 2);
        var vector = eventData.position - screen;
        var yAxys = new Vector2(0, 1);
        var xAxys = new Vector2(1, 0);
        xAxys.Normalize();
        yAxys.Normalize();
        vector.Normalize();

        
        var rotation = (Mathf.Rad2Deg * Mathf.Atan2(vector.y, vector.x) - 90);
        float _rotation;
        if (vector.x >= 0)
            _rotation = Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(vector, yAxys));
        else
            _rotation = 360f - Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(vector, yAxys));


        currentRotation = _rotation;
        GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -_rotation);
        timer.TimerDuration = Mathf.RoundToInt(timer.GetMaxDuration() * (_rotation / 360f));
    }




}

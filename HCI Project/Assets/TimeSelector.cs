using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeSelector : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        var rotation = -(Mathf.Atan2(eventData.position.y, eventData.position.x));
        GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0 , rotation);
    }




}

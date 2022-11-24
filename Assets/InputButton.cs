using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Action MouseDown { get; set; }
    public Action MouseUp { get; set; }
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData){}
}

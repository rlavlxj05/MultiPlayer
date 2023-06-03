using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.Netcode;
using UnityEngine.Networking;
using TMPro;

public class Joystick2 : NetworkBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image background;
    public Image stick;
    private Vector2 inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, eventData.position, eventData.pressEventCamera, out inputVector))
        {
            inputVector.x = (inputVector.x / background.rectTransform.sizeDelta.x);
            inputVector.y = (inputVector.y / background.rectTransform.sizeDelta.y);

            if(inputVector.magnitude > 1.0f)
            {
                inputVector = inputVector.normalized;
            }
            //Debug.Log(inputVector.x+ ","+ inputVector.y);
            stick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (background.rectTransform.sizeDelta.x / 3), inputVector.y * (background.rectTransform.sizeDelta.y / 3));
        }
    }

    private void Start()
    {
        background = GetComponent<Image>();
        stick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        stick.rectTransform.anchoredPosition = Vector2.zero;

    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }

}

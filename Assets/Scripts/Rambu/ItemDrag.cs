using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public bool moving = false;
    private Image image;

    [SerializeField] private StartButton startButton;
    [SerializeField] private GameObject parentObject;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
        canvas = GameObject.Find("CanvasGame").GetComponent<Canvas>();
    }

    private void Update()
    {
        parentObject = this.transform.parent.gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (startButton.start == false)
        {
            image.raycastTarget = false;
            image.color = new Color(1, 1, 1, .6f);
            moving = true;
        }
        else if (startButton.start == true) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!parentObject.CompareTag("Untagged") && parentObject.GetComponent<RambuSlot>().inPlace == true)
        {
            return;
        }

        if (startButton.start == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            moving = true;
        }
        else return;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 1);
        image.raycastTarget = true;
        moving = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (startButton.start == true) return;
    }
}

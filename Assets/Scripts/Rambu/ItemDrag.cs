using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public bool moving = false;
    private Image image;

    public event EventHandler OnStopDragging;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        canvas = GameObject.Find("CanvasGame").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        image.color = new Color(1, 1, 1, .6f);
        moving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        moving = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnStopDragging?.Invoke(this, EventArgs.Empty);
        image.color = new Color(1, 1, 1, 1);
        image.raycastTarget = true;
        moving = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {   
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoRambu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject infoUI;

    private bool holding;
    private float downTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        holding = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        infoUI.GetComponent<RectTransform>().localPosition = new Vector2(1200, -1200);
        holding = false;
        downTime = 0;
    }


    void Update()
    {
        if (holding)
        {
            downTime += Time.deltaTime;
            if (downTime > 2)
            {
                infoUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            }
        }
    }
}

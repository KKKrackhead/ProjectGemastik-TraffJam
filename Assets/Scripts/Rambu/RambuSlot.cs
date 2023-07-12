using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RambuSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public bool inPlace;
    private StartButton startButton;
    [SerializeField] private GameObject childRambu;
    [SerializeField] private GameObject items;
    

    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
        items = GameObject.Find("Items");
    }

    private void Update()
    {
        if (inPlace)
        {
            childRambu = this.gameObject.transform.GetChild(0).gameObject;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && startButton.start == false)
        {
            if (inPlace == false)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.localPosition = new Vector2(0, 0);
                eventData.pointerDrag.transform.SetParent(this.gameObject.transform, false);

                inPlace = true;
            }
        }
        else if (startButton.start) return;
    }

    private void OnMouseDown()
    {
        childRambu.transform.SetParent(items.transform, false);
        inPlace = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RambuSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public bool inPlace;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(inPlace == false)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.localPosition = new Vector2(0, 0);
                eventData.pointerDrag.transform.SetParent(this.gameObject.transform, false);

                inPlace = true;
            }
        }
    }
}

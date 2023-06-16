using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPos : MonoBehaviour
{
    private ItemDrag itemDrag;
    private Vector2 normalPosition;
    [SerializeField] private RectTransform tr;
    [SerializeField] private GameObject[] slots;


    private void Start()
    {
        itemDrag = GetComponent<ItemDrag>();
        itemDrag.OnStopDragging += ItemDrag_OnStopDragging;

        tr = GetComponent<RectTransform>();
        normalPosition = new Vector2(tr.position.x, tr.position.y);
    }

    private void ItemDrag_OnStopDragging(object sender, System.EventArgs e)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<RambuSlot>().inPlace == false && itemDrag.moving == false)
            {
                tr.position = normalPosition;
            }
        }
    }
}

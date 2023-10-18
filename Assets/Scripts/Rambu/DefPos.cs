using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefPos : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private GameObject parentObject;
    private ItemDrag itemDrag;

    private Vector3 defPosition;
    private Vector3 newReturnPos;

    private void Start()
    {
        itemDrag = GetComponent<ItemDrag>();
        defPosition = transform.localPosition;
    }

    private void Update()
    {
        parentObject = this.transform.parent.gameObject;

        newReturnPos = transform.localPosition;
        if (parentObject.CompareTag("Untagged") && newReturnPos.y != -15 && itemDrag.moving == false)
        {
            transform.localPosition = defPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (parentObject.CompareTag("Untagged"))
        {
            transform.localPosition = defPosition;
        }
    }
}

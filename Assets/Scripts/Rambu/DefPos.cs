using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefPos : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private GameObject parentObject;
    private ItemDrag itemDrag;

    private Vector2 defPosition;



    private void Start()
    {
        itemDrag = GetComponent<ItemDrag>();
        defPosition = transform.localPosition;
    }

    private void Update()
    {
        parentObject = this.transform.parent.gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (parentObject.CompareTag("Untagged"))
        {
            transform.localPosition = defPosition;
        }
    }
}

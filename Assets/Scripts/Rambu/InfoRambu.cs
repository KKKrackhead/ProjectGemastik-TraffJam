using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoRambu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject infoUI;
    [SerializeField] private AudioSource pop;
    [SerializeField] private StartButton startButton;

    private bool holding;
    private float downTime;

    int temp;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (startButton.start == false) holding = true;
        else return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        infoUI.GetComponent<RectTransform>().localPosition = new Vector2(1200, -1200);
        holding = false;
        temp = 0;
        downTime = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        infoUI.GetComponent<RectTransform>().localPosition = new Vector2(1200, -1200);
        holding = false;
        temp = 0;
        downTime = 0;
    }


    void Update()
    {
        if (holding)
        {
            downTime += Time.deltaTime;
            if (downTime > 1.2f)
            {
                infoUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                temp++;
            }
        }

        if(temp == 1)
        {
            pop.Play();
        }
    }
}

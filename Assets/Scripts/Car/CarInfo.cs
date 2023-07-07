using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarInfo : MonoBehaviour
{
    [SerializeField] private GameObject info;
    [SerializeField] private StartButton startButton;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();

        info.SetActive(false);
    }

    private void OnMouseOver()
    {
        if(startButton.start == false) {
            info.SetActive(true);
        }
        
    }

    private void OnMouseExit()
    {
        info.SetActive(false);
    }
}

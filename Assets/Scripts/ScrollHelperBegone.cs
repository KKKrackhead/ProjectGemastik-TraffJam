using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHelperBegone : MonoBehaviour
{
    private StartButton startButton;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
    }

    private void Update()
    {
        if (this.gameObject.CompareTag("test"))
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 || Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (startButton.start)
        {
            this.gameObject.SetActive(false);
        }
    }
}

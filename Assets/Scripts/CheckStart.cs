using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStart : MonoBehaviour
{
    [SerializeField] private AudioSource rev;
    [SerializeField] private StartButton startButton;

    int temp = 0;
    bool donePlaying;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
    }
    private void Update()
    {
        if(startButton.start == true)
        {
            temp += 1;
        }

        if(temp == 1 && donePlaying == false)
        {
            rev.Play();
            donePlaying = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTooLong : MonoBehaviour
{
    [SerializeField] private GameObject retry;
    [SerializeField] private StartButton startButton;
    [SerializeField] private int timeLimit;

    private float time;
    private bool levelOn;

    private void Start()
    {
        retry.SetActive(false);
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();

        time = 0;
        levelOn = false;
    }

    private void Update()
    {
        if(startButton.start)
        {
            levelOn = true;
        }

        if (levelOn && time < timeLimit)
        {
            time += Time.deltaTime;
            if (time >= timeLimit)
            {
                retry.SetActive(true);
            }
        }
    }
}

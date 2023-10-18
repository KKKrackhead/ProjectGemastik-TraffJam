using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGoHome : MonoBehaviour
{
    [SerializeField] private GameObject successUI;
    [SerializeField] private LevelEndHandler levelEndHandler;
    [SerializeField] private StartButton startButton;

    [SerializeField] private int carsNeeded;
    [SerializeField] private int carsEntered;
    public bool shit;
    [SerializeField] private bool isWaitingForDumbass;

    private void Start()
    {
        successUI = GameObject.Find("SuccessUI");
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
    }

    private void Update()
    {
        if (startButton.start == true)
        {
            if (carsEntered == carsNeeded)
            {
                StartCoroutine(Finito());
            }

            if (carsNeeded - carsEntered == 1 && isWaitingForDumbass == false) shit = true;
            else if (carsNeeded - carsEntered == 1 && isWaitingForDumbass == true)
            {
                StartCoroutine(HahaNo());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") && collision.transform.parent.CompareTag("ObjCar"))
        {
            carsEntered++;
        }
    }

    private IEnumerator Finito()
    {
        levelEndHandler.levelDone = true;
 
        yield return new WaitForSecondsRealtime(1f);
        successUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }

    private IEnumerator HahaNo()
    {
        yield return new WaitForSecondsRealtime(1.6f);
        shit = true;
    }
}

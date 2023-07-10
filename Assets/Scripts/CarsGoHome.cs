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
            if(carsEntered == carsNeeded)
            {
                //level done
                StartCoroutine(Finito());
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
        yield return new WaitForSecondsRealtime(1.5f);
        successUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
}

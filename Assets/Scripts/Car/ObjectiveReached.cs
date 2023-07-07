using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReached : MonoBehaviour
{
    [SerializeField] private GameObject successUI;
    [SerializeField] private LevelEndHandler levelEndHandler;

    private void Start()
    {
        successUI = GameObject.Find("SuccessUI");
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objectives") && levelEndHandler.levelDone == false)
        {
            StartCoroutine(LevelDone());
        }
    }

    private IEnumerator LevelDone()
    {
        levelEndHandler.levelDone = true;
        GetComponent<CarCrash>().canDrive = false;
        yield return new WaitForSecondsRealtime(1.5f);
        successUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
}

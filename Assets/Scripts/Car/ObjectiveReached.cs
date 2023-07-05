using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReached : MonoBehaviour
{
    [SerializeField] private GameObject successUI;

    private void Start()
    {
        successUI = GameObject.Find("SuccessUI");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objectives"))
        {
            StartCoroutine(LevelDone());
        }
    }

    private IEnumerator LevelDone()
    {
        GetComponent<CarCrash>().canDrive = false;
        yield return new WaitForSecondsRealtime(1.5f);
        successUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
}

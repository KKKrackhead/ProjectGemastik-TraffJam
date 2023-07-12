using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour
{
    public bool start;

    void Start()
    {
        start = false;
    }

    public void StartLevel()
    {
        start = true;

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.01f);
        gameObject.SetActive(false);
    }
}
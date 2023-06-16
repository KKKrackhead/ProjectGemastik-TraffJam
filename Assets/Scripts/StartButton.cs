using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        yield return new WaitForSecondsRealtime(.2f);
        gameObject.SetActive(false);
    }
}

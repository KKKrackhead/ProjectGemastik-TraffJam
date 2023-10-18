using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    [SerializeField] private int t;
    [SerializeField] private FadeFromLevel fader;

    private void Start()
    {
        fader = GameObject.Find("FadeOut").GetComponent<FadeFromLevel>();
    }

    public void Retry()
    {
        StartCoroutine(hehe());
        Time.timeScale = 1;
    }

    private IEnumerator hehe()
    {
        fader.CallFade();
        yield return new WaitForSecondsRealtime(.4f);
        StartCoroutine(Huh());
    }

    private IEnumerator Huh()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene(t);
    }
}

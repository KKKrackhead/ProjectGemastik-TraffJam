using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    [SerializeField] private int t;

    public void Retry()
    {
        StartCoroutine(Huh());
    }

    private IEnumerator Huh()
    {
        yield return new WaitForSecondsRealtime(.1f);
        SceneManager.LoadScene(t);
    }
}

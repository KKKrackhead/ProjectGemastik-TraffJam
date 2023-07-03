using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    [SerializeField] private int t;

    public void Retry()
    {
        SceneManager.LoadScene(t);
    }
}

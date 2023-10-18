using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndHandler : MonoBehaviour
{
    public bool levelDone;
    public bool lastLevel;
    public bool adaCrossing;

    public int needed;
    public int arrived;

    private void Start()
    {
        levelDone = false;
    }

    private void Update()
    {
        if(arrived == needed)
        {
            levelDone = true;
        }
    }
}
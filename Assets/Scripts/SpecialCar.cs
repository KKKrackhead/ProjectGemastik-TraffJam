using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCar : MonoBehaviour
{
    [SerializeField] LevelEndHandler levelEndHandler;

    private void Start()
    {
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();
    }

    private void Update()
    {
        if(levelEndHandler.levelDone == true)
        {
            Destroy(this.gameObject);
        }
    }
}

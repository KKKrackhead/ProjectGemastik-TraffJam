using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarVal : MonoBehaviour
{
    public float tempSpeed;
    [SerializeField] public float speed;
    [SerializeField] private GameObject startButton;
    [SerializeField] private CarCrash carCrash;

    private void Start()
    {
        carCrash = GetComponent<CarCrash>();
        startButton = GameObject.Find("PlayButton");
        tempSpeed = speed;
        speed = 0;
    }

    private void Update()
    {
        if (startButton.GetComponent<StartButton>().start == true && carCrash.canDrive == true)
        {
            speed = tempSpeed;

            if (carCrash.canDrive == false) speed = 0;
        }
    }

}

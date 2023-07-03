using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CarVal carVal;
    [SerializeField] private GameObject startButton;
    [SerializeField] private CarCrash carCrash;
    [SerializeField] public float dir;
    public float carSpeed;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton");
        carCrash = GetComponent<CarCrash>();
    }

    private void Update()
    {
        
        if(startButton.GetComponent<StartButton>().start == true)
        {
            carSpeed = carVal.speed;
        }

        if(carCrash.canDrive == true)
        {

            switch (dir)
            {
                case 0: //east
                    rb.velocity = new Vector2(carSpeed, 0);
                    break;

                case 1: //west
                    rb.velocity = new Vector2(-carSpeed, 0);
                    break;

                case 2: //north
                    rb.velocity = new Vector2(0, carSpeed);
                    break;

                case 3: //south
                    rb.velocity = new Vector2(0, -carSpeed);
                    break;

                default:
                    break;
            }
        }
    }

    public void Red(float s)
    {
        StartCoroutine(StopCar(s));
    }

    public void SlowDown(float t)
    {
        StartCoroutine(ReduceSpeed(t));
        carVal.speed = t;
        carVal.tempSpeed = t;
    }

    private IEnumerator StopCar(float s)
    {
        carCrash.canDrive = false;
        float ts;
        ts = carSpeed;
        carSpeed = 0;
        yield return new WaitForSecondsRealtime(s);
        carCrash.canDrive = true;
        carSpeed = ts;
    }

    private IEnumerator ReduceSpeed(float t)
    {
        carCrash.canDrive = false;
        carVal.speed = t;
        yield return new WaitForSecondsRealtime(.2f);
        carCrash.canDrive = true;
    }
}
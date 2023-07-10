using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CarVal carVal;
    [SerializeField] private GameObject startButton;
    [SerializeField] private CarCrash carCrash;
    [SerializeField] private Transform moveTarget;

    public float carSpeed;

    private void Start()
    {
        startButton = GameObject.Find("PlayButton");
        carCrash = GetComponent<CarCrash>();

        moveTarget = this.transform.GetChild(1).transform;
    }

    private void Update()
    {
        
        if(startButton.GetComponent<StartButton>().start == true)
        {
            carSpeed = carVal.speed;
        }

        if(carCrash.canDrive == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, carSpeed * Time.deltaTime);
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
        yield return new WaitForSecondsRealtime(.1f);
        carCrash.canDrive = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuBelok : MonoBehaviour
{
    private float turn;
    private StartButton startButton;

    private void Awake()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();

        if (this.gameObject.CompareTag("Left")) turn = 1;
        else if (this.gameObject.CompareTag("Right")) turn = -1;
    }

    private void OnTriggerEnter2D(Collider2D car)
    {
        if (startButton.start)
        {
            if(car.CompareTag("Car") || car.CompareTag("ObjCar"))
                {
                    Debug.Log("haha");
                    car.transform.parent.transform.Rotate(car.transform.parent.transform.rotation.x, car.transform.parent.transform.rotation.y, 180 * turn * (Time.deltaTime * 10));
                }
        }
            
    }
}

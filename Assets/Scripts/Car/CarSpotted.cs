using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpotted : MonoBehaviour
{
    [SerializeField] private CarMove carMove;

    private void OnTriggerEnter2D(Collider2D otherCar)
    {
        if (otherCar.CompareTag("Car"))
        {
            if(otherCar.GetComponent<CarCrash>().canDrive == false)
            {
                carMove.Red(.2f);
            }
            else if (otherCar.GetComponent<CarCrash>().canDrive == true)
            {
                carMove.SlowDown(otherCar.GetComponent<CarMove>().carSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D otherCar)
    {
        carMove.SlowDown(otherCar.GetComponent<CarMove>().carSpeed);
    }
}

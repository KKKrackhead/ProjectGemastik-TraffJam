using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpotted : MonoBehaviour
{
    [SerializeField] private CarMove carMove;

    private void OnTriggerStay2D(Collider2D otherCar)
    {
        if (otherCar.CompareTag("Car") || otherCar.CompareTag("ObjCar"))
        {
            if (otherCar.transform.parent.GetComponent<CarCrash>().canDrive == false)
            {
                carMove.Red(10f);
            }
            else if (otherCar.transform.parent.GetComponent<CarCrash>().canDrive == true)
            {
                carMove.SlowDown(otherCar.transform.parent.GetComponent<CarMove>().carSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D otherCar)
    {
        if(otherCar.CompareTag("Car") || otherCar.CompareTag("ObjCar")){
            carMove.SlowDown(otherCar.transform.parent.GetComponent<CarMove>().carSpeed);
        }
    }
}

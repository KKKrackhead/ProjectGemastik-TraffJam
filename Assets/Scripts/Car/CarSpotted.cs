using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpotted : MonoBehaviour
{
    [SerializeField] private CarMove carMove;

    private void OnTriggerEnter2D(Collider2D otherCar)
    {
        if (otherCar.CompareTag("Car") || otherCar.CompareTag("ObjCar"))
        {
            if (otherCar.transform.parent.GetComponent<CarCrash>().canDrive == false)
            {
                carMove.Red(.5f);
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
            Debug.Log("Spot 2");
            carMove.SlowDown(otherCar.transform.parent.GetComponent<CarMove>().carSpeed);
        }
    }
}

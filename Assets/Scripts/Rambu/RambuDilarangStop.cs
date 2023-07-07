using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuDilarangStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.parent.CompareTag("Car") || other.transform.parent.CompareTag("ObjCar")){
            other.transform.parent.GetComponent<CarGoStop>().willStop = false;
            other.transform.parent.GetComponent<CarGoStop>().stopping = false;
            other.transform.parent.GetComponent<CarVal>().tempSpeed = 4;
        }
    }
}

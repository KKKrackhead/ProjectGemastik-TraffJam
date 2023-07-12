using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rambu50 : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other){
        if(other.transform.parent.CompareTag("Car") || other.transform.parent.CompareTag("ObjCar")){
            other.transform.parent.gameObject.GetComponent<CarVal>().tempSpeed = 5;       
        }
    }
}

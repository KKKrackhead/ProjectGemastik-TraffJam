using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rambu50 : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Car") || other.transform.parent.gameObject.CompareTag("Car") || other.transform.parent.CompareTag("ObjCar")){
            other.transform.parent.gameObject.GetComponent<CarVal>().tempSpeed = 4;   
            if(other.transform.parent.GetChild(1).gameObject.activeInHierarchy == false)
            {
                other.transform.parent.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rambu50 : MonoBehaviour
{
    //[SerializeField] private GameObject test;

    private void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Car") || other.CompareTag("ObjCar")){
            //test = other.transform.GetChild(1).gameObject; 
            other.transform.GetChild(1).gameObject.SetActive(false);
            other.gameObject.GetComponent<CarVal>().tempSpeed = 15;       
        }
    }
}

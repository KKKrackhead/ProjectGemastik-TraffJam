using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHaveNoIdea : MonoBehaviour
{
    [SerializeField] private GameObject bus;
    [SerializeField] private GameObject objective;
    [SerializeField] private CarsGoHome carsGoHome;


    void Update()
    {
        if (carsGoHome.shit == true)
        {
            bus.GetComponent<CarVal>().speed = 15;
            bus.GetComponent<CarVal>().tempSpeed = 15;
        }   
    }
}

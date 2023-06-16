using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D car)
    {
        if (car.CompareTag("Car"))
        {
            car.gameObject.GetComponent<CarMove>().Red(5);
        }
    }
}
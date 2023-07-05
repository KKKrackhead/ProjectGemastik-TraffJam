using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Car")))
        {
            if(this.CompareTag("RedLight")) other.gameObject.GetComponent<CarMove>().Red(3);
        }
    }
}
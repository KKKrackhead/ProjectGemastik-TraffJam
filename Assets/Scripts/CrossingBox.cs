using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingBox : MonoBehaviour
{
    [SerializeField] int crossed;
    [SerializeField] int needed;
    public bool allSafe;

    private void Update()
    {
        if(crossed == needed)
        {
            allSafe = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DumbassBox"))
        {
            crossed++;
        }
    }
}

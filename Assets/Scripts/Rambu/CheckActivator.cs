using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActivator : MonoBehaviour
{
    [SerializeField] GameObject east;
    [SerializeField] GameObject west;
    [SerializeField] GameObject north;
    [SerializeField] GameObject south;

    private void Start()
    {
        east.SetActive(false);
        west.SetActive(false);
        south.SetActive(false);
        north.SetActive(false);
    }
}

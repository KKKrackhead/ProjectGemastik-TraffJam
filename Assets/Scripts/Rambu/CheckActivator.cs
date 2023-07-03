using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckActivator : MonoBehaviour
{
    [SerializeField] GameObject east;
    [SerializeField] GameObject west;
    [SerializeField] GameObject north;
    [SerializeField] GameObject south;

    [SerializeField] GameObject parentObj;

    private void Start()
    {
        east.SetActive(false);
        west.SetActive(false);
        south.SetActive(false);
        north.SetActive(false);
    }

    private void Update()
    {
        parentObj = this.transform.parent.gameObject;

        if (parentObj.CompareTag("East")) east.SetActive(true);
        else if (parentObj.CompareTag("North")) north.SetActive(true);
        else if (parentObj.CompareTag("West")) west.SetActive(true);
        else if (parentObj.CompareTag("South")) south.SetActive(true);
    }
}

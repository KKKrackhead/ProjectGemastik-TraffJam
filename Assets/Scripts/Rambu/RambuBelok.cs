using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RambuBelok : MonoBehaviour
{
    public float turn;
    public float turnSpeed;

    private void Awake()
    {
        if (!gameObject.CompareTag("Untagged"))
        {
            if (this.gameObject.CompareTag("Left")) turn = 1;
            else if (this.gameObject.CompareTag("Right")) turn = -1;
            else if (this.gameObject.CompareTag("KelokLeft")) turn = 1;
            else if (this.gameObject.CompareTag("KelokRight")) turn = -1;
        }

        turnSpeed = 3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RambuBelok : MonoBehaviour
{
    public float turn;

    private void Awake()
    {
        if (this.gameObject.CompareTag("Left")) turn = 1;
        else if (this.gameObject.CompareTag("Right")) turn = -1;
    }
}

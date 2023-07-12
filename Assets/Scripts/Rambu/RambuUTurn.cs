using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuUTurn : MonoBehaviour
{
    public float turn;
    public float forcedAngle = 180;

    private void Awake()
    {
        if (this.gameObject.CompareTag("Left")) turn = 1;
        else if (this.gameObject.CompareTag("Right")) turn = -1;
    }
}

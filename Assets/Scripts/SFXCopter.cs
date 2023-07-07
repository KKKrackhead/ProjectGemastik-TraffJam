using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCopter : MonoBehaviour
{
    [SerializeField] int a;
    [SerializeField] int b; 

    private void Update()
    {
        float randAng = Random.Range(a, b);
        transform.Rotate(transform.rotation.x, transform.rotation.y, randAng, Space.Self);

        transform.Rotate(transform.rotation.x, transform.rotation.y, -randAng * 2, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent != null)
        {
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.transform.parent == null)
        {
            Destroy(collision.gameObject);
        }
    }
}

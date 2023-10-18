using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambuCrossing : MonoBehaviour
{
    [SerializeField] private CrossingBox crossingBox;


    private void Start()
    {
        crossingBox = GameObject.Find("Dumbass Box").GetComponent<CrossingBox>();
    }

    private void Update()
    {
        if(crossingBox.allSafe == true)
        {
            StartCoroutine(BeGone());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            collision.transform.parent.gameObject.GetComponent<CarCrash>().canDrive = false;

            if(crossingBox.allSafe == true)
            {
                collision.transform.parent.gameObject.GetComponent<CarCrash>().canDrive = true;
            }
        }
    }

    private IEnumerator BeGone()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(this);
    }
}

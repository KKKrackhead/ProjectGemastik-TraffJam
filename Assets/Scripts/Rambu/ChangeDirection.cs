using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D car)
    {
        if (car.CompareTag("Car"))
        {
            float turn = car.GetComponent<CarMove>().nextDir;
            switch (turn)
            {
                case 0:
                    break;

                case 1:
                    for (float i = 0; i <= 45; i += 1.5f)
                    {
                        car.transform.Rotate(0, 0, (transform.rotation.z + i) * Time.deltaTime, Space.Self);
                    }

                    if (car.GetComponent<CarMove>().dir == 0) car.GetComponent<CarMove>().dir = 2;
                    else if (car.GetComponent<CarMove>().dir == 1) car.GetComponent<CarMove>().dir = 3;
                    else if (car.GetComponent<CarMove>().dir == 2) car.GetComponent<CarMove>().dir = 0;
                    else if (car.GetComponent<CarMove>().dir == 3) car.GetComponent<CarMove>().dir = 1;

                    for (float j = 0; j <= 45; j += 1.5f)
                    {
                        car.transform.Rotate(0, 0, (transform.rotation.z + j) * Time.deltaTime, Space.Self);
                    }
                    break;

                case 2:
                    StartCoroutine(Wait());

                    for (float i = 0; i <= 45; i -= 1.5f)
                    {
                        car.transform.Rotate(0, 0, (transform.rotation.z + i) * Time.deltaTime, Space.Self);
                    }

                    if (car.GetComponent<CarMove>().dir == 0) car.GetComponent<CarMove>().dir = 2;
                    else if (car.GetComponent<CarMove>().dir == 1) car.GetComponent<CarMove>().dir = 3;
                    else if (car.GetComponent<CarMove>().dir == 2) car.GetComponent<CarMove>().dir = 0;
                    else if (car.GetComponent<CarMove>().dir == 3) car.GetComponent<CarMove>().dir = 1;

                    for (float j = 0; j <= 45; j -= 1.5f)
                    {
                        car.transform.Rotate(0, 0, (transform.rotation.z + j) * Time.deltaTime, Space.Self);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
    }
}

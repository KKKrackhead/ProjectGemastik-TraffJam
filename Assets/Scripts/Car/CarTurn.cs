using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurn : MonoBehaviour
{
    private bool turning;
    private float turn;
    private StartButton startButton;

    [SerializeField] private float turnSolo;

    [SerializeField] private CarVal carVal;
    
    [SerializeField] private float temp;
    [SerializeField] private float turnSpeed;

    [SerializeField] private float Angle; //90 belok, 180 U-Turn


    private void Start()
    {
        carVal = GetComponent<CarVal>();
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();

        temp = carVal.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(startButton.start){
            if (collision.transform.parent.CompareTag("Left") || collision.transform.parent.CompareTag("Right"))
            {
                turn = collision.transform.parent.GetComponent<RambuBelok>().turn;
                Angle = collision.transform.parent.GetComponent<RambuBelok>().forcedAngle;
                turnSolo = turn;
                StartCoroutine(GoTurn());
            }

            if (collision.transform.parent.CompareTag("TurnTurner"))
            {
                turnSolo = collision.transform.parent.gameObject.GetComponent<RambuCantTurn>().makeTurnTo;
            }

            if (turnSolo != 0 && collision.CompareTag("TurnPoint"))
            {
                turn = turnSolo;
                StartCoroutine(GoTurn());
            }
        }

    }

    private void Update()
    {
        if (turning && turnSolo != 0)
        {
            carVal.tempSpeed = turnSpeed;
            transform.Rotate(0, 0, Angle * Time.deltaTime * turn, Space.Self);
        }
    }

    private void ResetSpeed()
    {
        carVal.tempSpeed = temp; 
    }

    private IEnumerator GoTurn()
    {
        turning = true;
        yield return new WaitForSecondsRealtime(1);
        turning = false;
        ResetSpeed();
    }
}
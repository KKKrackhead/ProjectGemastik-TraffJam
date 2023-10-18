using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTurn : MonoBehaviour
{
    public bool turning;
    public bool grooving;
    private float turn;
    private StartButton startButton;

    Scene thisLevel;

    [SerializeField] private LevelEndHandler endHandler;

    [SerializeField] private float turnSolo;
    [SerializeField] private float groove;

    [SerializeField] private CarVal carVal;
    
    [SerializeField] private float tempWhileTurning;
    [SerializeField] private float turnSpeed;

    private void Start()
    {
        carVal = GetComponent<CarVal>();
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
        endHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();

        thisLevel = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(startButton.start){
            if (collision.transform.parent.CompareTag("Left") || collision.transform.parent.CompareTag("Right"))
            {
                turn = collision.transform.parent.GetComponent<RambuBelok>().turn;
                turnSpeed = collision.transform.parent.GetComponent<RambuBelok>().turnSpeed;
                turnSolo = turn;
                StartCoroutine(GoTurn());
            }
            else if (collision.CompareTag("Left") || collision.CompareTag("Right"))
            {
                turn = collision.GetComponent<RambuBelok>().turn;
                turnSolo = turn;
                StartCoroutine(GoTurn());
            }
            else if(collision.CompareTag("SpecialLeft") && this.gameObject.CompareTag("ObjCar"))
            {
                turn = collision.GetComponent<RambuBelok>().turn;
                turnSolo = turn;
                StartCoroutine(GoTurn());
            }
            else if(collision.transform.parent.CompareTag("KelokLeft") || collision.transform.parent.CompareTag("KelokRight"))
            {
                groove = collision.transform.parent.GetComponent<RambuBelok>().turn;
            }

            if(groove != 0 && collision.CompareTag("Kelok"))
            {
                StartCoroutine(GoGroove(groove));
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
        if (startButton.start)
        {
            tempWhileTurning = carVal.tempSpeed;
        }

        if (turning && turnSolo != 0)
        {
            carVal.tempSpeed = turnSpeed;
            transform.Rotate(0, 0, (90 * turn) * Time.deltaTime, Space.Self);
        }
        else if( grooving && groove != 0)
        {
            transform.Rotate(0, 0, (90 * groove) * Time.deltaTime, Space.Self);
        }

        if (endHandler.levelDone == true)
        {
            turning = false;
            grooving = false;
        }
    }

    private void ResetSpeed()
    {
        carVal.tempSpeed = tempWhileTurning; 
    }

    private IEnumerator GoTurn()
    {
        turning = true;
        yield return new WaitForSecondsRealtime(1);
        turning = false;
        ResetSpeed();
    }

    private IEnumerator GoGroove(float g)
    {
        grooving = true;
        groove = g;
        yield return new WaitForSecondsRealtime(.5f);
        groove = 0;
        yield return new WaitForSecondsRealtime(.85f);
        groove = -g;
        yield return new WaitForSecondsRealtime(1.1f);
        groove = 0;
        yield return new WaitForSecondsRealtime(1.4f);
        groove = g;
        yield return new WaitForSecondsRealtime(.7f);
        grooving = false;
    }
}
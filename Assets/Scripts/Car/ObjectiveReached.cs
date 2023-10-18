using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReached : MonoBehaviour
{
    [SerializeField] private GameObject successUI;
    [SerializeField] private LevelEndHandler levelEndHandler;
    [SerializeField] private AudioSource clap;
    [SerializeField] CarCrash carCrash;
    [SerializeField] CarVal carVal;

    public int type;
    
    private void Start()
    {
        successUI = GameObject.Find("SuccessUI");
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelEndHandler.lastLevel == false)
        {
            if (collision.CompareTag("Objectives") && levelEndHandler.levelDone == false)
            {
                StartCoroutine(LevelDone());
            }
        }
        else if (levelEndHandler.lastLevel == true)
        {
            if (type == 1 && collision.CompareTag("Hospital"))
            {
                levelEndHandler.arrived++;
                Bruh();
                Debug.Log(levelEndHandler.arrived);
            }
            else if (type == 2 && collision.CompareTag("Halte"))
            {
                levelEndHandler.arrived++;
                Bruh();
                Debug.Log(levelEndHandler.arrived);
            }
        }        
    }

    void Bruh()
    {
        carCrash.canDrive = false;
        carVal.tempSpeed = 0;
    }

    private void Update()
    {
        if(levelEndHandler.needed == levelEndHandler.arrived)
        {
            StartCoroutine(LevelDone());
        }
    }

    private IEnumerator LevelDone()
    {
        levelEndHandler.levelDone = true;
        GetComponent<CarCrash>().canDrive = false;
        yield return new WaitForSecondsRealtime(1f);
        successUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        clap.Play();
    }
}

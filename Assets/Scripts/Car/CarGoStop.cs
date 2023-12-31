using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGoStop : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] public bool willStop;

    public bool stopping;

    private void Start() {
        startButton = GameObject.Find("PlayButton");
    }

    private void Update()
    {
        if (startButton.GetComponent<StartButton>().start == true && willStop)
        {
            StartCoroutine(Stops());
        }
    }

    private IEnumerator Stops()
    {
        yield return new WaitForSecondsRealtime(.6f);
        stopping = true;
        if (willStop && stopping && GetComponent<CarVal>().tempSpeed > 0)
        {
            GetComponent<CarVal>().tempSpeed -= Time.deltaTime * 4;
            if(GetComponent<CarVal>().tempSpeed < 0 || GetComponent<CarVal>().speed < 0)
            {
                GetComponent<CarVal>().tempSpeed = 0;
                GetComponent<CarVal>().speed = 0;
            }
        }
    }
}

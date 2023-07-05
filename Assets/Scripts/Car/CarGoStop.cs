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
        yield return new WaitForSecondsRealtime(1);
        stopping = true;
        while (stopping && GetComponent<CarVal>().tempSpeed > 0)
        {
            GetComponent<CarVal>().tempSpeed -= Time.deltaTime;
        }
    }
}

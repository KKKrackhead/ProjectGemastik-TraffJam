using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhase : MonoBehaviour
{
    [SerializeField] private GameObject t1;
    [SerializeField] private GameObject t2;
    [SerializeField] private GameObject t3;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject finish;

    [SerializeField] private RambuSlot slot;
    [SerializeField] private LevelFadeStart fade;

    private void Start()
    {
        slot = GameObject.Find("_BaseSlot").GetComponent<RambuSlot>();
        fade = GameObject.Find("CanvasGame").GetComponent<LevelFadeStart>();

        t1.SetActive(true);
        t2.SetActive(false);
        t3.SetActive(false);
    }

    private void Update()
    {
        if(slot.tempPhase == 2)
        {
            StartCoroutine(Text2());
        }
        else if (slot.tempPhase == 3)
        {
            StartCoroutine(Text3());
        }

        if (info.GetComponent<RectTransform>().localPosition == new Vector3(0, 0, 0) && slot.tempPhase == 3)
        {
            fade.Fodder();
            slot.tempPhase = 4;
            StartCoroutine(FinishTuto());
        }
    }

    private IEnumerator FinishTuto()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(info.gameObject);
        finish.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
    }

    private IEnumerator Text2()
    { 
        yield return new WaitForSecondsRealtime(.9f);
        t1.SetActive(false);
        t2.SetActive(true);
        t3.SetActive(false);
    }

    private IEnumerator Text3()
    {
        yield return new WaitForSecondsRealtime(.9f);
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(true);
    }
}

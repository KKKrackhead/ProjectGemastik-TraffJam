using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFadeStart : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private RambuSlot slot;

    [SerializeField] private bool isTuto;

    private void Start()
    {
        StartCoroutine(FadeOut());

        if (isTuto)
        {
            slot = GameObject.Find("_BaseSlot").GetComponent<RambuSlot>();
            slot.OnTutorialPhase += Slot_OnTutorialPhase;
        } 
    }

    private void Slot_OnTutorialPhase(object sender, System.EventArgs e)
    {
        StartCoroutine(WaitABit());
    }

    public void Fodder()
    {
        StartCoroutine(WaitABit());
    }

    private IEnumerator WaitABit()
    {
        yield return new WaitForSecondsRealtime(.4f);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float elapsed = 0f;
        float duration = .8f;

        while (elapsed < duration)
        {
            float temp = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, temp);

            elapsed += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(.8f);
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f;
        float duration = .8f;

        while (elapsed < duration)
        {
            float temp = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, temp);

            elapsed += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(.8f);
        if (slot.tempPhase != 4) StartCoroutine(FadeOut());
    }
}

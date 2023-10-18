using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFromLevel : MonoBehaviour
{
    [SerializeField] private Image fadeScreen;

    public void CallFade()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f;
        float duration = .8f;

        while (elapsed < duration)
        {
            float temp = Mathf.Clamp01(elapsed / duration);
            fadeScreen.color = Color.Lerp(Color.clear, Color.white, temp);

            elapsed += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(.8f);
    }
}

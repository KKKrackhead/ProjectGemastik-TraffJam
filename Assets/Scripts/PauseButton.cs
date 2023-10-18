using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    private Image image;

    private void Start()
    {
        PauseUI = GameObject.Find("PauseUI");
        image = GameObject.Find("Pause").GetComponent<Image>();
    }

    public void OnPause()
    {
        image.raycastTarget = false;
        PauseUI.transform.localPosition = new Vector2(0, 0);
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        PauseUI.transform.localPosition = new Vector2(2000, -2000);
        Time.timeScale = 1;
        image.raycastTarget = true;
    }
}

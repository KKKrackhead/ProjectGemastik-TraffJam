using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    public void PopUp()
    {
        mainMenu.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }
}

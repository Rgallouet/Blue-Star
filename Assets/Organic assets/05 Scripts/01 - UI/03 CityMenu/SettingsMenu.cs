﻿using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {



    public CityGUI cityGUI;
    public Camera mainCamera;


    private Canvas SettingsMenuCanvas;

    // Use this for initialization
    void Start()
    {
        SettingsMenuCanvas = GetComponent<Canvas>();
        mainCamera.orthographicSize = 3;
        SettingsMenuCanvas.enabled = false;
    }

    public void ActivateMenu()
    {
        SettingsMenuCanvas.enabled = true;
    }

    public void DesactivateMenu()
    {
        SettingsMenuCanvas.enabled = false;
    }

    public void QuitGame() {
        Application.Quit();
    }


}

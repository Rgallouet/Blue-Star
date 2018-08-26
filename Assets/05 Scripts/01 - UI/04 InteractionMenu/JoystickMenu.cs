using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMenu : MonoBehaviour {


    private Canvas joystick;
    public WindowsCamera windowsCamera;



    // Use this for initialization
    void Start () {

        joystick = GetComponent<Canvas>();
        joystick.enabled = false;
    }

    public void ActivateJoystick()
    {
        windowsCamera.CharacterViewMode = true;
        joystick.enabled = true;
    }

    public void DesactivateJoystick()
    {
        windowsCamera.CharacterViewMode = false;
        joystick.enabled = false;
    }

}

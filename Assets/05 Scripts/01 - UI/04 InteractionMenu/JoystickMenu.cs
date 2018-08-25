using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMenu : MonoBehaviour {


    private Canvas joystick;


    // Use this for initialization
    void Start () {

        joystick = GetComponent<Canvas>();
        joystick.enabled = false;
    }

    public void ActivateJoystick()
    {
        joystick.enabled = true;
    }

    public void DesactivateJoystick()
    {
        joystick.enabled = false;
    }

}

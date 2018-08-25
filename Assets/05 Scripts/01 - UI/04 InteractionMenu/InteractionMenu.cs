using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionMenu : MonoBehaviour {

    public Text ObjectName;

    private Canvas objectInteractionMenu;


    // Use this for initialization
    void Start()
    {

        objectInteractionMenu = GetComponent<Canvas>();
        objectInteractionMenu.enabled = false;
        ObjectName = objectInteractionMenu.GetComponentsInChildren<Text>()[0];

    }


    public void ActivateMenu(GameObject gameObject)
    {
        objectInteractionMenu.enabled = true;
        ObjectName.text = gameObject.GetComponentsInChildren <GameObjectInformation>()[0].ObjectName;

    }

    public void DesactivateMenu()
    {
        objectInteractionMenu.enabled = false;
    }
}

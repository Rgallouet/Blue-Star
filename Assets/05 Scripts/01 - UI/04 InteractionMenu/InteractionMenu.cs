using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionMenu : MonoBehaviour {

    private Text ObjectName;
    private Canvas objectInteractionMenu;

    public CubeManager cubeManager;


    public Transform DigThroughButton;
    Transform digThrough;

    GameObject LastObjectSelected;
    public float LastObjectSelected_x;
    public float LastObjectSelected_z;

    // Use this for initialization
    void Start()
    {

        objectInteractionMenu = transform.parent.GetComponent<Canvas>();
        objectInteractionMenu.enabled = false;
        ObjectName = objectInteractionMenu.GetComponentsInChildren<Text>()[0];

    }


    public void ActivateMenu(GameObject gameObject)
    {
        
        objectInteractionMenu.enabled = true;
        LastObjectSelected = gameObject;
        LastObjectSelected_x = gameObject.transform.position.x;
        LastObjectSelected_z = gameObject.transform.position.z;

        ObjectName.text = gameObject.GetComponentsInChildren <GameObjectInformation>()[0].ObjectName;

    }

    public void DesactivateMenu()
    {
        objectInteractionMenu.enabled = false;
    }


    public void InstantiateDigThrough()
    {
        digThrough = Instantiate(DigThroughButton);
        digThrough.parent = transform;
        digThrough.GetComponentInChildren<Button>().onClick.AddListener(() => { UseDigThrough(); });
        Debug.Log("ahah");

    }

    public void ResetActionButtons() {

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void UseDigThrough() {

        GameObject.Destroy(LastObjectSelected);
        cubeManager.GenerateUndergroundElement(10, (int)Math.Floor(LastObjectSelected_x), (int)Math.Floor(LastObjectSelected_z));
        cubeManager.Map[(int)Math.Floor(LastObjectSelected_x)][(int)Math.Floor(LastObjectSelected_z)] = 10;
        cubeManager.UpdateTheVisibleArea();


    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionMenu : MonoBehaviour {

    private Text ObjectName;
    private Canvas objectInteractionMenu;

    public CubeManager cubeManager;


    public Transform InteractionButton;
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
        transform.position = new Vector3(Input.mousePosition.x+150, Input.mousePosition.y, 0);
        transform.parent.GetComponentsInChildren<Text>()[0].transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y+50, 0);

    }

    public void DesactivateMenu()
    {
        objectInteractionMenu.enabled = false;
    }


    public void InstantiateDigThrough()
    {
        digThrough = Instantiate(InteractionButton);
        digThrough.GetComponentInChildren<Text>().text = "Dig Throught!";
        digThrough.parent = transform;
        digThrough.GetComponentInChildren<Button>().onClick.AddListener(() => { UseDigThrough(); });

    }

    public void InstantiatePaving()
    {
        digThrough = Instantiate(InteractionButton);
        digThrough.GetComponentInChildren<Text>().text = "Pave the ground";
        digThrough.parent = transform;
        digThrough.GetComponentInChildren<Button>().onClick.AddListener(() => { UsePaving(); });

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
        cubeManager.saveAndLoad.UpdateCityData(10, (int)Math.Floor(LastObjectSelected_x)+1, (int)Math.Floor(LastObjectSelected_z)+1);

    }

    public void UsePaving()
    {

        GameObject.Destroy(LastObjectSelected);
        cubeManager.GenerateUndergroundElement(11, (int)Math.Floor(LastObjectSelected_x), (int)Math.Floor(LastObjectSelected_z));
        cubeManager.Map[(int)Math.Floor(LastObjectSelected_x)][(int)Math.Floor(LastObjectSelected_z)] = 11;
        cubeManager.UpdateTheVisibleArea();
        cubeManager.saveAndLoad.UpdateCityData(11, (int)Math.Floor(LastObjectSelected_x)+1, (int)Math.Floor(LastObjectSelected_z)+1);

    }

}

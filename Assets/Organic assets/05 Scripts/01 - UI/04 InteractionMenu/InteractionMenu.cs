using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionMenu : MonoBehaviour
{


    private Text ObjectName;
    private Canvas objectselectionMenu;

    public CubeManager cubeManager;


    public Transform InteractionButton;
    Transform digThrough;

    GameObject LastObjectSelected;
    public float LastObjectSelected_x;
    public float LastObjectSelected_y;
    public float LastObjectSelected_z;

    // Use this for initialization
    void Start()
    {

        objectselectionMenu = transform.parent.GetComponent<Canvas>();
        objectselectionMenu.enabled = false;
        ObjectName = objectselectionMenu.GetComponentsInChildren<Text>()[0];

    }


    public void ActivateMenu(GameObject gameObject)
    {
        
        objectselectionMenu.enabled = true;
        LastObjectSelected = gameObject;
        LastObjectSelected_x = gameObject.transform.position.x;
        LastObjectSelected_y = gameObject.transform.position.y;
        LastObjectSelected_z = gameObject.transform.position.z;

        ObjectName.text = gameObject.GetComponentsInChildren <GameObjectInformation>()[0].ObjectName;
        transform.position = new Vector3(Input.mousePosition.x+150, Input.mousePosition.y, 0);
        transform.parent.GetComponentsInChildren<Text>()[0].transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y+50, 0);

    }

    public void DesactivateMenu()
    {
        objectselectionMenu.enabled = false;
    }


    public void InstantiateDigThrough()
    {
        digThrough = Instantiate(InteractionButton);
        digThrough.GetComponentInChildren<Text>().text = "Dig Throught!";
        digThrough.parent = transform;
        digThrough.GetComponentInChildren<Button>().onClick.AddListener(() => { AchieveActionTile("DigThrough"); });

    }

    public void InstantiatePaving()
    {
        digThrough = Instantiate(InteractionButton);
        digThrough.GetComponentInChildren<Text>().text = "Pave the ground";
        digThrough.parent = transform;
        digThrough.GetComponentInChildren<Button>().onClick.AddListener(() => { AchieveActionTile("Paving"); });

    }

    public void ResetActionButtons() {

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void AchieveActionTile(string action) {

        // Deciding what needs to be changed - with default being ground
        int tileAsset=13;
        int visibility=1;

        switch (action)
        {
            case "DigThrough":
                tileAsset = 13;
                visibility = 1;
                break;

            case "Paving":
                tileAsset = 21;
                visibility = 1;
                break;

        }
            
        // defining where to change the tile
        int x = (int)Math.Floor(LastObjectSelected_x);
        int y = (int)Math.Floor(LastObjectSelected_y);


        // updating the data warehouse
        cubeManager.saveAndLoad.UpdateCityData(tileAsset, visibility, x, y);

        // Creating the tile with tile id 13 (ground 0) and visibility 1
        cubeManager.ChangeTile(x, y, tileAsset, visibility);

        // refreshing visible area
        cubeManager.UpdateTheVisibleArea();

    }


}

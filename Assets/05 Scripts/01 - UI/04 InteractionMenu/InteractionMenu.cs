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
    public float LastObjectSelected_y;
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
        LastObjectSelected_y = gameObject.transform.position.y;
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

        // defining tile to use
        string tileAsset = "Ground_1";
        int visibility = 1;

        // updating the data warehouse
        cubeManager.saveAndLoad.UpdateCityData(tileAsset, visibility, (int)Math.Floor(LastObjectSelected_x)+1, (int)Math.Floor(LastObjectSelected_z)+1);

        // updating the tile
        cubeManager.tileMapGround.SetTile(new Vector3Int((int)Math.Floor(LastObjectSelected_x), (int)Math.Floor(LastObjectSelected_y), (int)Math.Floor(LastObjectSelected_z)), tileAsset);
   
        // refreshing visible area
        cubeManager.UpdateTheVisibleArea();

    }

    public void UsePaving()
    {

        // defining tile to use
        string tileAsset = "Paved_1";
        int visibility = 1;

        // updating the data warehouse
        cubeManager.saveAndLoad.UpdateCityData(tileAsset, visibility, (int)Math.Floor(LastObjectSelected_x) + 1, (int)Math.Floor(LastObjectSelected_z) + 1);

        // updating the tile
        cubeManager.tileMapGround.SetTile(new Vector3Int((int)Math.Floor(LastObjectSelected_x), (int)Math.Floor(LastObjectSelected_y), (int)Math.Floor(LastObjectSelected_z)), tileAsset);

        // refreshing visible area
        cubeManager.UpdateTheVisibleArea();

    }

}

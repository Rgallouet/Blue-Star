using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ExplorationMenu : MonoBehaviour
{

    public CubeManager cubeManager; 
    public WindowsCamera windowsCamera;

    // Managing sub Menus
    public Canvas explorationMenuCanvas;
    public Canvas selectionMenuCanvas;
    public bool explorationMenuOpened;
    public bool selectionMenuOpened;

    // Tile Selection information
    public string selectionTileName;
    public string selectionTileType;
    public string selectionTileDescription;
    public int selectionTileCanBeUsed;
    public int selectionTileVisibility;
    public int selectionTileId;

    // if there is a unit of building
    public string selectionEntityName;
    public string selectionEntityType;
    public string selectionEntityDescription;

    // position of selection
    public int selectionX = -1;
    public int selectionY = -1;

    //UI components to update
    public Text tileNameTextInUI;
    public Text tileDescriptionTextInUI;
    public Transform actionButtonContainer;
    Transform newButton;

    //UI assets to load
    public Sprite[] actionIcons;
    public Transform InteractionButton;

    private System.Random rnd;



    void Start()
    {
        rnd = new System.Random(); 
        DesactivateMenu();
        

    }

    public void DesactivateMenu()
    {
        DesactivateSubMenu("exploration");
        DesactivateSubMenu("selection");
    }

    public void DesactivateSubMenu(string subMenu)
    {
        //Debug.Log("Desactivating sub menu " + subMenu);

        switch (subMenu)
        {
            case "exploration": 
                explorationMenuCanvas.enabled = false;
                explorationMenuOpened = false;
                break;

            case "selection": 
                selectionMenuCanvas.enabled = false;
                selectionMenuOpened = false;
                break;

        }
    }
    public void ActivateSubMenu(string subMenu)
    {

        //Debug.Log("Activating sub menu " + subMenu);

        switch (subMenu) 
        {
            case "exploration": 
                explorationMenuCanvas.enabled = true;
                explorationMenuOpened = true;
                break;

            case "selection": 
                selectionMenuCanvas.enabled = true;
                selectionMenuOpened = true;
                break;

        }
        
        
    }

    public void Select(int x, int y)
    {
        if (selectionX != -1) cubeManager.tileMapOverlay.SetTile(new Vector3Int(selectionX, selectionY, 0), null);
        if (selectionMenuOpened == false) ActivateSubMenu("selection");

        ArrayList TileInformation = cubeManager.saveAndLoad.dataBaseManager.getArrayData("select TileName, TileType, TileDescription, CanBeUSed, Visibility, TileId from VIEW_TileSpriteCodeDetailed as a inner join (select TileSpriteId, Visibility from ACCOUNT_CityMap where X=" + x + " and y=" + y + ") as b on a.TileSpriteId=b.TileSpriteId");

        selectionTileName = (string)((ArrayList)TileInformation[1])[0];
        selectionTileType = (string)((ArrayList)TileInformation[1])[1];
        selectionTileDescription = (string)((ArrayList)TileInformation[1])[2];

        selectionTileCanBeUsed = (int)((ArrayList)TileInformation[1])[3];
        selectionTileVisibility = (int)((ArrayList)TileInformation[1])[4];
        selectionTileId = (int)((ArrayList)TileInformation[1])[5];

        selectionX = x;
        selectionY = y;

        if (selectionTileVisibility <= 4) 
        {
            // defaulting to ground selection effect
            int TileID = 69;

            switch (selectionTileType)
            {
                case "Ground":
                    TileID = 69;
                    break;

                case "Wall":
                    TileID = 70;
                    break;

                case "Resource":
                    TileID = 70;
                    break;

            }

            TileChangeData tileChangeData = new()
            {
                position = new Vector3Int(x, y, 0),
                tile = cubeManager.tiles[TileID],
                color = new Color(1, 1, 1, 1),
                transform = Matrix4x4.Translate(new Vector3(0, 0.01f * cubeManager.tileOffsetOnYbycm[TileID], 0))
            };

            cubeManager.tileMapOverlay.SetTile(tileChangeData, true);

            // Add here the identification of a unit on top of the tile


            UpdateTileDetailsinUI();

            if (explorationMenuOpened == true) ActionButtonUpdate();


        }



    }

    public void Deselect()
    {

        if (selectionX!=-1) cubeManager.tileMapOverlay.SetTile(new Vector3Int(selectionX, selectionY, 0), null);

        selectionX = -1;
        selectionY = -1;
        
        selectionTileName = "No selection";
        selectionTileType = "Void";
        selectionTileDescription = "You have not selected anything yet";
        
        selectionTileCanBeUsed = 0;
        selectionTileVisibility =4;
        selectionTileId = 0;

        selectionEntityName ="";
        selectionEntityType="";
        selectionEntityDescription="";
        
        UpdateTileDetailsinUI();

        if (selectionMenuOpened == true) DesactivateSubMenu("selection");

    }


    public void ActionButtonUpdate() {

        // Reset everything
        ResetActionButtons();

        // If character exist and is nearby
        if (windowsCamera.characterMoving != null 
            &&
            Mathf.Abs(selectionX - windowsCamera.characterMoving.GetComponent<PlayerController>().rigidBody_x)<=1.5f
            &&
            Mathf.Abs(selectionY - windowsCamera.characterMoving.GetComponent<PlayerController>().rigidBody_y) <= 1.5f)
        {
            ArrayList tileAction = cubeManager.saveAndLoad.dataBaseManager.getArrayData("select * from VIEW_TileSpriteActionList where TileIdSelected=" + selectionTileId );

            if (tileAction.Count >= 1)
            {
                for (int i = 1; i < tileAction.Count; i++)
                {
                    InstantiateActionButton((string)((ArrayList)tileAction[i])[1], (string)((ArrayList)tileAction[i])[9]);

                }
            }

            //if (selectionTileCanBeUsed== 1)
            // to redo with the new view
            //{ InstantiateActionButton("Use"); }

        }


    }

    public void UpdateTileDetailsinUI()
    {

        tileNameTextInUI.text = selectionTileName + " (" + selectionTileType + " at [" + selectionX + "," + selectionY + "])";
        tileDescriptionTextInUI.text = selectionTileDescription;
    }




    public void InstantiateActionButton(string actionType, string tileName)
    {
        newButton = Instantiate(InteractionButton, actionButtonContainer);

        switch (actionType)
        {
            case "Break":
                newButton.GetComponentInChildren<Text>().text = "Let's break it down and retrieve materials!";
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[0];
                // to redo this part with the new view
                //newButton.GetComponentsInChildren<Text>()[0].text = ;

                newButton.GetComponent<Button>().onClick.AddListener(() => { AchieveActionTile("Break"); });
                break;

            case "Build":
                newButton.GetComponentInChildren<Text>().text = "I should have the resources to build: "+ tileName;
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[1];
                newButton.GetComponent<Button>().onClick.AddListener(() => { AchieveActionTile("Build"); });
                break;

            case "Use":
                newButton.GetComponentInChildren<Text>().text = "Maybe I can use this";
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[2];
                newButton.GetComponent<Button>().onClick.AddListener(() => { AchieveActionTile("Use"); });
                break;

        }


    }

    public void ResetActionButtons()
    {

        foreach (Transform child in actionButtonContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void AchieveActionTile(string actionType)
    {

        // Deciding what needs to be changed - with default being ground
        int tileAsset = 13;
        int visibility = 1;

        switch (actionType)
        {
            case "Break":
                tileAsset = rnd.Next(14,22);
                visibility = 1;
                break;

            case "Build":
                tileAsset = rnd.Next(36, 44);
                visibility = 1;
                break;

        }

        windowsCamera.characterMoving.GetComponent<PlayerController>().actionRequested = true;

        // updating the data warehouse
        cubeManager.saveAndLoad.UpdateCityData(tileAsset, visibility, selectionX, selectionY);

        // Creating the tile with tile id 13 (ground 0) and visibility 1
        cubeManager.ChangeTile(selectionX, selectionY, tileAsset, visibility);

        // refreshing visible area
        cubeManager.UpdateTheVisibleArea();

        //Resetting action buttons
        Select(selectionX, selectionY);

    }

















}

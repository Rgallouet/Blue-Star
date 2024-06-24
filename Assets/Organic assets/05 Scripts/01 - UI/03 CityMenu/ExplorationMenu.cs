using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;
using Unity.Mathematics;

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
    public int selectionTileId;
    public string selectionTileName;
    public string selectionTileDescription;
    public int selectionTileCanBeUsed;
    public int selectionTileVisibility;
    public int selectionTileCanBeWalkedOn;

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

        ArrayList TileInformation = cubeManager.saveAndLoad.dataBaseManager.getArrayData("select TileId, TileName, TileDescription, Visibility, CanBeWalkedOn from VIEW_TileSpriteCodeDetailed as a inner join (select TileSpriteId, Visibility from ACCOUNT_CityMap where X=" + x + " and y=" + y + ") as b on a.TileSpriteId=b.TileSpriteId");

        selectionTileId = (int)((ArrayList)TileInformation[1])[0];
        selectionTileName = (string)((ArrayList)TileInformation[1])[1];
        selectionTileDescription = (string)((ArrayList)TileInformation[1])[2];
        selectionTileVisibility = (int)((ArrayList)TileInformation[1])[3];
        selectionTileCanBeWalkedOn = (int)((ArrayList)TileInformation[1])[4];

        selectionX = x;
        selectionY = y;

        //If can be selected
        if (selectionTileVisibility <= 4) 
        {
            //Positioning a selection tile visible on the position of the selection
            TileChangeData tileChangeData = new()
            {
                position = new Vector3Int(x, y, 0),
                tile = cubeManager.tiles[70-selectionTileCanBeWalkedOn],
                color = new Color(1, 1, 1, 1),
                transform = Matrix4x4.Translate(new Vector3(0, -0.25f, 0))
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
            ArrayList tileAction = cubeManager.saveAndLoad.dataBaseManager.getArrayDataWithoutHeader("select * from VIEW_TileSpriteActionList where TileIdSelected=" + selectionTileId );

            foreach (ArrayList action in tileAction)
            {
                InstantiateActionButton(action);
            }


        }


    }

    public void UpdateTileDetailsinUI()
    {
        tileNameTextInUI.text = selectionTileName + " [" + selectionX + "," + selectionY + "]";
        tileDescriptionTextInUI.text = selectionTileDescription;
    }




    public void InstantiateActionButton(ArrayList actionItem)
    {
        newButton = Instantiate(InteractionButton, actionButtonContainer);

        Debug.Log("the tile from "+ (int)actionItem[0]);
        Debug.Log("the tile to " + (int)actionItem[1]);

        //Adding an action on the button
        newButton.GetComponent<Button>().onClick.AddListener(() => { AchieveActionTile((int)actionItem[0], (int)actionItem[1]); });

        // updating the description of the action
        newButton.GetComponentsInChildren<Text>()[0].text = (string)actionItem[4];

        //updating the sin level requirements
        newButton.GetComponentsInChildren<Text>()[1].text = (string)actionItem[5];

        // updating the first resource info with quality level colours
        newButton.GetComponentsInChildren<Text>()[2].text = (string)actionItem[6];
        newButton.GetComponentsInChildren<Text>()[5].text = (string)actionItem[7];

        // updating the second resource info with quality level colours
        if ((string) actionItem[7]!=" ")
        {
            newButton.GetComponentsInChildren<Text>()[3].text = (string)actionItem[8];
            newButton.GetComponentsInChildren<Text>()[6].text = (string)actionItem[9];
        }

        // updating the third resource info with quality level colours
        if ((string)actionItem[9] != " ")
        {
            newButton.GetComponentsInChildren<Text>()[4].text = (string)actionItem[10];
            newButton.GetComponentsInChildren<Text>()[7].text = (string)actionItem[11];

        }

        // Updating the icon
        switch ((string)actionItem[2])
        {
            case "Break":
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[0];
                break;
        
            case "Build":
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[1];
                break;
        
            case "Use":
                newButton.GetComponentsInChildren<Image>()[1].sprite = actionIcons[2];
                break;
        
        }


        //Disabling the button if the conditions are not met
        if ( (Int64)actionItem[3]==0) 
        {
            newButton.GetComponent<Button>().interactable = false;

            foreach (Text textObject in newButton.GetComponentsInChildren<Text>())
            {
                textObject.color = new Color32(255,255,255,100);

            }


        }


    }

    public void ResetActionButtons()
    {

        foreach (Transform child in actionButtonContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void AchieveActionTile(int tileIdSelected, int tileIdAfterAction)
    {
        //Consumming or gaining resources
        //Debug.Log("Checking tile ID used : " + tileIdSelected+" and "+ tileIdAfterAction);
        ArrayList actionRessources = cubeManager.saveAndLoad.dataBaseManager.getArrayDataWithoutHeader("select * from VIEW_TileSpriteActionRessourceCost where TileIdSelected=" + tileIdSelected + " and TileIdAfterAction=" + tileIdAfterAction);

        

        foreach (ArrayList ressourceCost in actionRessources)
        {
            //Debug.Log("Changing ressource " + ressourceCost[2].GetType() + " with quantity " + ressourceCost[3].GetType());
            cubeManager.saveAndLoad.dataBaseManager.RunQuery("UPDATE ACCOUNT_Ressources SET Quantity = Quantity + ("+ (Int64)ressourceCost[3] + ") WHERE RessourceID = "+ (int)ressourceCost[2]);
        }


        // Finding the range of sprites that needs to be used
        ArrayList tileRange = (ArrayList)(cubeManager.saveAndLoad.dataBaseManager.getArrayDataWithoutHeader("select min(tileSpriteId) as min, max(tileSpriteId) as max from REF_TileSpriteCode where TileId=" + tileIdAfterAction))[0];
        
        //Debug.Log("Finding the object " + tileRange.GetType()+", the min " + tileRange[0].GetType() + " and max " + tileRange[1].GetType());

        //Debug.Log("The tile ID to create is " + tileIdAfterAction + " and I need to take a random sprite between " + (Int64)tileRange[0] + " and " + (Int64)tileRange[1]);

        int tileAsset = rnd.Next( (int)(Int64)tileRange[0], (int)(Int64)tileRange[1] );
        int visibility = 1;

        // Triggering the animation of an action
        windowsCamera.characterMoving.GetComponent<PlayerController>().actionRequested = true;

        // updating the data warehouse
        cubeManager.saveAndLoad.UpdateCityData(tileAsset, visibility, selectionX, selectionY);

        // Creating the tile
        cubeManager.ChangeTile(selectionX, selectionY, tileAsset, visibility);

        // refreshing visible area
        cubeManager.UpdateTheVisibleArea();

        //Resetting action buttons
        Select(selectionX, selectionY);

    }

















}

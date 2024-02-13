using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class SelectionBox : MonoBehaviour {

    public JoystickMenu leftJoystick;
    public WindowsCamera windowsCamera;
    public InteractionMenu interactionMenu;
    public CubeManager cubeManager;

    // Selection information
    public string selectionTileName;
    public string selectionTileType;
    public string selectionTileDescription;

    // if there is a unit of building
    public string selectionEntityName;
    public string selectionEntityType;
    public string selectionEntityDescription;

    // position of selection
    public int selectionX = -1;
    public int selectionY = -1;


    public void Select(int x, int y)
    {

        ArrayList TileInformation = cubeManager.saveAndLoad.dataBaseManager.getArrayData("select TileName, TileType, TileDescription, Visibility from VIEW_TileSpriteCodeDetailed as a inner join (select TileSpriteId, Visibility from CityMap where X=" + x + " and y=" + y + ") as b on a.TileSpriteId=b.TileSpriteId");

        selectionTileName = (string)((ArrayList)TileInformation[1])[0];
        selectionTileType = (string)((ArrayList)TileInformation[1])[1];
        selectionTileDescription = (string)((ArrayList)TileInformation[1])[2];

        selectionX = x;
        selectionY = y;

        Debug.Log("Selected " + selectionTileName + " which is a " + selectionTileType);

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


        //ActionButtonUpdate(SelectedObject, windowsCamera.characterSelected);

    }

    public void Deselect()
    {
        if (selectionX!=-1) cubeManager.tileMapOverlay.SetTile(new Vector3Int(selectionX, selectionY, 0), null);

        selectionX = -1;
        selectionY = -1;

        selectionTileName = "";
        selectionTileType = "";
        selectionTileDescription = "";

        selectionEntityName="";
        selectionEntityType="";
        selectionEntityDescription="";
    }


    public void ActionButtonUpdate(GameObject SelectedObject, GameObject Character) {

        // Reset everything
        interactionMenu.ResetActionButtons();

        // If character exist and is nearby
        if ( Character != null 
            &&
            Mathf.Abs(SelectedObject.transform.position.x- Character.transform.position.x)<=1.5f
            &&
            Mathf.Abs(SelectedObject.transform.position.z - Character.transform.position.z) <= 1.5f)
        {

            if (SelectedObject.GetComponentInChildren<GameObjectInformation>().CanBeDigged <= Character.GetComponentInChildren<GameObjectInformation>().baseCharacter.DiggingLevel)
            { interactionMenu.InstantiateDigThrough(); }

            if (SelectedObject.GetComponentInChildren<GameObjectInformation>().CanBeBuilt <= Character.GetComponentInChildren<GameObjectInformation>().baseCharacter.BuildingLevel)
            { interactionMenu.InstantiatePaving(); }

        }


    }


}

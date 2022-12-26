using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CubeManager : MonoBehaviour {

    public SaveAndLoad saveAndLoad;
    public CityGUI cityGUI;

    public Transform PlayerPrefab;
    public Transform playerInstantiated;

    // TileMaps to interact with
    public Tilemap tileMapGround;
    public Tilemap tileMapWall;
    public Tilemap tileMapEdge;

    // Repository of tile assets
    public Tile[] tiles;

    // references on tiles
    private string[] tileName;
    private string[] tileType;
    private string[] tileDescription;
    private int[] tileOffsetOnYbycm;
    private int[] fallingEdgeTileSpriteId;

    //Temporary objects

    public int[,] TileMap;
    public int[,] VisibilityMap;

    private int[,] Visible;
    private int[,] NewVisible;


    // Generation offsetting
    readonly float xOffset = 0.5f;
    readonly float yOffset = 0.5f;
    readonly float zOffset = 0f;
    readonly int xStartingPoint = 100;
    readonly int yStartingPoint = 100;

    //Max visible dimensions
    public int MaxVisibleSizeOnX;
    public int MaxVisibleSizeOnY;
    public int MinVisibleSizeOnX;
    public int MinVisibleSizeOnY;

    //Generation vectors
    Quaternion Setup = Quaternion.identity;

    // Current cube
    Transform Cube;




    public void GenerateMap() {

        // Getting the references on tile assets
        (tileName, tileType, tileDescription, tileOffsetOnYbycm, fallingEdgeTileSpriteId) = saveAndLoad.LoadTileReferences();

        // Generate or Load the map information
        (TileMap, VisibilityMap) = GettingTheMap();
        
        // Calculate what should be visible
        Visible = CalculateTheVisibleArea(VisibilityMap);

        //Generating the tiles
        for (int x = 0 ; x < TileMap.GetLength(0); x++)
        {
            for (int y = 0; y < TileMap.GetLength(1); y++)
            {
                //Debug.Log("Should I generate tile at x=" + x + ", y=" + y + ", with tile ID=" + TileMap[x, y] + ", and visibility=" + Visible[x, y]+"?");
                if (Visible[x,y] != 4)
                {
                    ChangeTile(x, y, TileMap[x, y], Visible[x, y]);
                    //Debug.Log("Creating a ground at x=" + x + " and y=" + y + "with tile nammed " + tiles[TileMap[x, y]].name);
                }
            }
        }

        // Generating the hero
        playerInstantiated = Instantiate(PlayerPrefab, new Vector3(xOffset + xStartingPoint*0.25f - yStartingPoint*0.25f, yOffset + xStartingPoint * 0.25f + yStartingPoint * 0.25f, zOffset), Quaternion.Euler(0, 0, 0) );
        playerInstantiated.GetComponentInChildren<GameObjectInformation>().baseCharacter = saveAndLoad.LoadCharacterFromDataBase((long)1);


    }




    public (int[,] TileMap, int[,] VisibilityMap) GettingTheMap()
    {
        // hardcoding for now
        string MapName = "Undercity";

        // if there is no map saved, then we create one
        if (cityGUI.account.CurrentCityTier == 0)
        {
            Debug.Log(MapName + " - Starting from scratch and generating a new map");

            System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

            // Selecting a terrain tier (default 1) and updating the database
            cityGUI.account.CurrentCityTier = 1;
            saveAndLoad.SaveAccountDetails(cityGUI.account);

            // Generating a base random map with zone ID
            saveAndLoad.dataBaseManager.RunQuery(
           "DELETE FROM TEMPORARY_CityMap;" +
           "INSERT INTO TEMPORARY_CityMap Select * from VIEW_NewCityMap;" +
           "DELETE FROM CityMap;" +
           "INSERT INTO CityMap Select * from VIEW_NewCityMapWithTiles;" +
           "DELETE FROM TEMPORARY_CityMap;");


            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            Debug.Log(MapName + " - Time to create and save the map : " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

        }
        // otherwise we load one
        else
        {
            Debug.Log(MapName + " - Loading the map saved in database");
            
        }

        return saveAndLoad.LoadPlayerCityFromDataBase();

    }

    public int[,] CalculateTheVisibleArea(int[,] VisibilityMap) {

        // Creating a matrix the size of the map
        int[,] MapArray = new int[VisibilityMap.GetLength(0), VisibilityMap.GetLength(1)];

        // Defaulting the matrix to invisible
        for (int x = 0; x < VisibilityMap.GetLength(0); x++)
        {
            for (int y = 0; y < VisibilityMap.GetLength(1); y++)
            {
                MapArray[x, y] = 4;
            }
        }

        //Assigning the visibility of the starting point at 1
        MapArray[xStartingPoint, yStartingPoint] = 1;

        // Initialising the visible dimensions
        MaxVisibleSizeOnX= xStartingPoint;
        MaxVisibleSizeOnY= yStartingPoint;
        MinVisibleSizeOnX= xStartingPoint;
        MinVisibleSizeOnY= yStartingPoint;

        //Starting the To Do List from the character starting point to find visible tiles
        ArrayList ToDoList = new()
        {
            //First element should be starting point
            new int[] { xStartingPoint, yStartingPoint }
        };

        //Starting the a list for generating edges too
        ArrayList edgeCheckingList = new()
        {
            //First element should be starting point
            new int[] { xStartingPoint, yStartingPoint }
        };


        // Counting how many ground cells so far
        int visibleTilesToDisplay = 1;

        // Finishing all the to do spaces to reveal the map
        while (ToDoList.Count > 0 && visibleTilesToDisplay < 100000) 
        {

            int x_center = ((int[])ToDoList[0])[0];
            int y_center = ((int[])ToDoList[0])[1];

            // Remove the current item from the list
            ToDoList.RemoveAt(0);

            //Checking the x-1 cell has not already been assigned or is out of bounds
            if (x_center - 1 >= 0 && MapArray[x_center - 1, y_center]==4)
            {
                // refreshing the min X
                if (MinVisibleSizeOnX > x_center - 1) MinVisibleSizeOnX = x_center - 1;

                // Checking if the cell at x-1 is a wall or a ground
                if (VisibilityMap[x_center - 1, y_center] == 2)
                {
                    //Assigning for now as a wall
                    MapArray[x_center - 1, y_center] = 2;

                    //Keep in mind the tile to check later if it needs an edge
                    edgeCheckingList.Add(new int[] { x_center - 1, y_center });

                }
                //if not a wall, keep on looping on visible
                else 
                {
                    // assigning it as ground
                    MapArray[x_center - 1, y_center] = 1;

                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center - 1, y_center });
                    visibleTilesToDisplay++;
                }
            }

            //Checking the x+1 cell has not already been assigned or is out of bounds
            if (x_center + 1 <= VisibilityMap.GetLength(0) && MapArray[x_center + 1, y_center]==4)
            {
                // refreshing the max X
                if (MaxVisibleSizeOnX < x_center + 1) MaxVisibleSizeOnX = x_center + 1;

                // Checking if the cell at x-1 is a wall or a ground
                if (VisibilityMap[x_center + 1, y_center] == 2)
                {
                    //Assigning for now as a wall
                    MapArray[x_center + 1, y_center] = 2;

                    //Keep in mind the tile to check later if it needs an edge
                    edgeCheckingList.Add(new int[] { x_center + 1, y_center });

                }
                //if not a wall, keep on looping on visible
                else
                {
                    // assigning it as ground
                    MapArray[x_center + 1, y_center] = 1;

                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center + 1, y_center });
                    visibleTilesToDisplay++;
                }
            }

            //Checking the y-1 cell has not already been assigned or is out of bounds
            if (y_center - 1 >= 0 && MapArray[x_center, y_center - 1]==4)
            {
                // refreshing the min Y
                if (MinVisibleSizeOnY > y_center - 1) MinVisibleSizeOnY = y_center - 1;

                // Checking if the cell at x-1 is a wall or a ground
                if (VisibilityMap[x_center, y_center - 1] == 2)
                {
                    //Assigning for now as a wall
                    MapArray[x_center, y_center - 1] = 2;

                    //Keep in mind the tile to check later if it needs an edge
                    edgeCheckingList.Add(new int[] { x_center, y_center - 1 });

                }
                //if not a wall, keep on looping on visible
                else
                {
                    // assigning it as ground
                    MapArray[x_center, y_center - 1] = 1;

                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center, y_center - 1 });
                    visibleTilesToDisplay++;
                }
            }

            //Checking the y+1 cell has not already been assigned or is out of bounds
            if (y_center + 1 <= VisibilityMap.GetLength(1) && MapArray[x_center, y_center + 1]==4)
            {
                // refreshing the max Y
                if (MaxVisibleSizeOnY < y_center + 1) MaxVisibleSizeOnY = y_center + 1;

                // Checking if the cell at x-1 is a wall or a ground
                if (VisibilityMap[x_center, y_center + 1] == 2)
                {
                    //Assigning for now as a wall
                    MapArray[x_center , y_center + 1] = 2;

                    //Keep in mind the tile to check later if it needs an edge
                    edgeCheckingList.Add(new int[] { x_center , y_center + 1 });

                }
                //if not a wall, keep on looping on visible
                else
                {
                    // assigning it as ground
                    MapArray[x_center , y_center + 1] = 1;

                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center , y_center + 1 });
                    visibleTilesToDisplay++;
                }
            }

        }

        Debug.Log("To display: "+ visibleTilesToDisplay + " ground tiles are visibles along with their surroundings.");

        int edgesToDisplay = 0;

        while (edgeCheckingList.Count > 0)
        {
            // center at the element
            int x_center = ((int[])edgeCheckingList[0])[0];
            int y_center = ((int[])edgeCheckingList[0])[1];

            // Remove the current item from the list
            edgeCheckingList.RemoveAt(0);

            //Checking if either x-1 or y-1 are fully invisible
            if (MapArray[x_center - 1, y_center]==4 || MapArray[x_center, y_center-1] == 4)
            {
                // if yes; then the tile at the center needs edges
                MapArray[x_center, y_center] = 3;
                edgesToDisplay++;
            }
        }

        Debug.Log("To display: " + edgesToDisplay + " edges on the border of the map.");

        return MapArray;
    }

    public void UpdateTheVisibleArea() {

        //Getting latest map details
        (TileMap, VisibilityMap) = GettingTheMap();

        //Getting latest Visible grid
        NewVisible = CalculateTheVisibleArea(VisibilityMap);

        // Checking if any tile has updated its visibility status
        for (int x = 0; x < TileMap.GetLength(0); x++)
        {
            for (int y = 0; y < TileMap.GetLength(1); y++)
            {
                if (Visible[x,y] == 4 && NewVisible[x,y] != 4)
                {
                    ChangeTile(x, y, TileMap[x, y], NewVisible[x, y]);
                }
            }
        }

        Visible = NewVisible;

    }


    public void ChangeTile(int x, int y, int tileSpriteId, int visibility) 
    {
        // Creating some different colour shades randomly
        System.Random rnd = new();
        float randomColorModifierRed = 1f- 0.005f * rnd.Next(10);
        float randomColorModifierGreen = 1f - 0.005f * rnd.Next(10);
        float randomColorModifierBlue = 1f - 0.005f * rnd.Next(10);

        //Debug.Log("Blue color will be "+ randomColorModifierBlue+ " and red "+ randomColorModifierRed);

        TileChangeData tileChangeData = new()
        {
            position = new Vector3Int(x, y, 0),
            tile = tiles[tileSpriteId],
            color = new Color(randomColorModifierRed, randomColorModifierGreen, randomColorModifierBlue, 1),
            transform = Matrix4x4.Translate(new Vector3(0, 0.01f * tileOffsetOnYbycm[tileSpriteId], 0))
        };

        if (visibility == 1)
        {
            tileMapGround.SetTile(tileChangeData, true);
        }

        if (visibility == 2)
        {
            tileMapWall.SetTile(tileChangeData, true);

        }

        if (visibility == 3)
        {
            tileMapWall.SetTile(tileChangeData, true);

            //Debug.Log("tile id to be displayed as edge: " + fallingEdgeTileSpriteId[tileSpriteId]);
            TileChangeData tileChangeDataEdge = new()
            {
                position = new Vector3Int(x, y, 0),
                tile = tiles[fallingEdgeTileSpriteId[tileSpriteId]],
                color = new Color(randomColorModifierRed, randomColorModifierGreen, randomColorModifierBlue, 1),
                transform = Matrix4x4.Translate(new Vector3(0, 0.01f * tileOffsetOnYbycm[fallingEdgeTileSpriteId[tileSpriteId]], 0))
            };

            tileMapEdge.SetTile(tileChangeDataEdge, true);
        }

        

    }





}

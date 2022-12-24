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

    // Repository of tile assets
    public Tile[] tiles;

    // references on tiles
    private string[] tileName;
    private string[] tileType;
    private string[] tileDescription;
    private int[] tileOffsetOnYbycm;

    //Temporary objects

    public int[,] TileMap;
    public int[,] VisibilityMap;

    private int[,] Visible;
    private int[,] NewVisible;


    // Generation offsetting
    readonly float xOffset = 0.5f;
    readonly float yOffset = 0.5f;
    readonly float zOffset = 0.75f;
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
        (tileName, tileType, tileDescription, tileOffsetOnYbycm) = saveAndLoad.LoadTileReferences();

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

                if (Visible[x,y] == 1)
                {
                    ChangeTile(x, y, TileMap[x, y], tileMapGround);
                    //Debug.Log("Creating a ground at x=" + x + " and y=" + y + "with tile nammed " + tiles[TileMap[x, y]].name);
                }

                if (Visible[x, y] == 2)
                {
                    ChangeTile(x, y, TileMap[x, y], tileMapWall); 
                    //Debug.Log("Creating a wall at x=" + x + " and y=" + y + "with tile nammed " + tiles[TileMap[x, y]].name);
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

        // Creating a matrix the  size of the map
        int[,] MapArray = new int[VisibilityMap.GetLength(0), VisibilityMap.GetLength(1)];

        // Defulting the matrix to invisible

        for (int x = 0; x < VisibilityMap.GetLength(0); x++)
        {
            for (int y = 0; y < VisibilityMap.GetLength(1); y++)
            {
                MapArray[x, y] = 3;
            }
        }

        //Assigning the visibility of the starting point at 1
        MapArray[xStartingPoint, yStartingPoint] = 1;

        // Initialising the visible dimensions
        MaxVisibleSizeOnX= xStartingPoint;
        MaxVisibleSizeOnY= yStartingPoint;
        MinVisibleSizeOnX= xStartingPoint;
        MinVisibleSizeOnY= yStartingPoint;

    //Starting the To Do List from the character starting point
    ArrayList ToDoList = new()
        {
            //First element should be starting point
            new int[] { xStartingPoint, yStartingPoint }
        };

        // Counting how many ground cells so far
        int failsafe = 1;

        // Finishing all the to do spaces to reveal the map
        while (ToDoList.Count > 0 && failsafe < 100000) 
        {

            int x_center = ((int[])ToDoList[0])[0];
            int y_center = ((int[])ToDoList[0])[1];

            // Remove the current item from the list
            ToDoList.RemoveAt(0);

            //Checking the x-1 cell
            if (x_center - 1 >= 0 && MapArray[x_center - 1, y_center]==3)
            {
                // Making it visible
                MapArray[x_center - 1, y_center] = VisibilityMap[x_center - 1, y_center];

                // refreshing the min X
                if (MinVisibleSizeOnX > x_center - 1) MinVisibleSizeOnX = x_center - 1;

                // Assigning a new step if it's a ground
                if (VisibilityMap[x_center - 1, y_center] == 1)
                {
                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center - 1, y_center });
                    failsafe++;
                }
            }


            //Checking the x+1 cell
            if (x_center + 1 <= VisibilityMap.GetLength(0) && MapArray[x_center + 1, y_center]==3)
            {
                // Making it visible
                MapArray[x_center + 1, y_center] = VisibilityMap[x_center + 1, y_center];

                // refreshing the min X
                if (MaxVisibleSizeOnX < x_center + 1) MaxVisibleSizeOnX = x_center + 1;

                // Assigning a new step if it's a ground
                if (MapArray[x_center + 1, y_center] == 1)
                {
                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center + 1, y_center });
                    failsafe++;
                }
            }

            //Checking the y-1 cell
            if (y_center - 1 >= 0 && MapArray[x_center, y_center - 1]==3)
            {
                // Making it visible
                MapArray[x_center, y_center-1] = VisibilityMap[x_center, y_center-1];

                // refreshing the min X
                if (MinVisibleSizeOnY > y_center -1) MinVisibleSizeOnY = y_center - 1;

                // Assigning a new step if it's a ground
                if (MapArray[x_center, y_center-1] == 1)
                {
                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center, y_center-1 });
                    failsafe++;
                }
            }


            //Checking the y+1 cell
            if (y_center + 1 <= VisibilityMap.GetLength(1) && MapArray[x_center, y_center + 1]==3)
            {
                // Making it visible
                MapArray[x_center, y_center +1 ] = VisibilityMap[x_center, y_center+1];

                // refreshing the min X
                if (MaxVisibleSizeOnY < y_center + 1) MaxVisibleSizeOnY = y_center + 1;

                // Assigning a new step if it's a ground
                if (MapArray[x_center, y_center + 1] == 1)
                {
                    //in addition; if it is a ground, then we can add it to the to-do list
                    ToDoList.Add(new int[] { x_center, y_center +1});
                    failsafe++;
                }
            }



        }

        Debug.Log("To display: "+ failsafe+ " ground tiles are visibles along with their surroundings.");

        return MapArray;
    }

    public void UpdateTheVisibleArea() {

        //Getting latest map details
        (TileMap, VisibilityMap) = GettingTheMap();

        //Getting latest Visible grid
        NewVisible = CalculateTheVisibleArea(VisibilityMap);

        for (int x = 0; x < TileMap.GetLength(0); x++)
        {
            for (int y = 0; y < TileMap.GetLength(1); y++)
            {
                if (Visible[x,y] == 3 && NewVisible[x,y] == 1)
                {
                    ChangeTile(x, y, TileMap[x, y], tileMapGround);
                }

                if (Visible[x, y] == 3 && NewVisible[x, y] == 2)
                {
                    ChangeTile(x, y, TileMap[x, y], tileMapWall);

                }

            }
        }

        Visible = NewVisible;

    }


    public void ChangeTile(int x, int y, int tileSpriteId, Tilemap tilemap) 
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

        tilemap.SetTile(tileChangeData,true);

    }





}

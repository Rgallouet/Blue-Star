using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CubeManager : MonoBehaviour {

    public SaveAndLoad saveAndLoad;
    public CityGUI cityGUI;
    public Transform PlayerPrefab;
    public Transform playerInstantiated;

    public Tilemap tileMapGround;
    public Tilemap tileMapWall;


    // Density function 
    public int AdditiveFactor= 50;
    public int MultiplicativeFactor = 1;
    public int MaximumExcess = 150;

    //Temporary objects
    public int MapSizeOnX;
    public int MapSizeOnZ;

    public string[,] TileMap;
    public int[,] VisibilityMap;

    private int[,] Visible;
    private int[,] NewVisible;


    // Generation offsetting
    float xOffset = 0.5f;
    float yOffset = 0.75f;
    float zOffset = 0.5f;
    readonly int xStartingPoint = 100;
    int zStartingPoint = 100;


    //Generation vectors
    Quaternion Setup = Quaternion.identity;

    // Current cube
    Transform Cube;




    public void GenerateMap() {

        (TileMap, VisibilityMap) = GettingTheMap();
        
        Visible = CalculateTheVisibleArea(VisibilityMap);

        
        //Generating the Cubes
        for (int x = 0 ; x <= MapSizeOnX; x++)
        {
            for (int z = 0; z <= MapSizeOnZ; z++)
            {
                if (Visible[x,z] == 1)
                {
                    tileMapGround.SetTile(new Vector3Int(x,0,z), TileMap[x,z]);
                }

                if (Visible[x, z] == 2)
                {
                    tileMapWall.SetTile(new Vector3Int(x, 0, z), TileMap[x, z]);
                }
            }
        }

        // Generating the hero
        playerInstantiated = Instantiate(PlayerPrefab, new Vector3(xOffset + xStartingPoint, yOffset, zOffset + zStartingPoint), Quaternion.Euler(0, 0, 0) );
        playerInstantiated.GetComponentInChildren<GameObjectInformation>().baseCharacter = saveAndLoad.LoadCharacterFromDataBase((long)1);


    }




    public (string[,] TileMap, int[,] VisibilityMap) GettingTheMap()
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

        int[,] MapArray = new int[VisibilityMap.GetLength(0), VisibilityMap.GetLength(1)];

        //Starting the To Do List from the character starting point
        ArrayList ToDoList = new();
        ToDoList.Add(new int[] { xStartingPoint, zStartingPoint });


        // Finishing all the to do spaces to reveal the map
        int failsafe = 0;
        while (ToDoList.Count > 0 && failsafe < 100000) {

            failsafe++;
            int x_center = ((int[])ToDoList[0])[0];
            int z_center = ((int[])ToDoList[0])[1];

            // Allocate the visibility to the tile
            MapArray[x_center, z_center] = VisibilityMap[x_center, z_center];
            ToDoList.RemoveAt(0);

            // if the tile is a ground, add all surrounding tiles without visibility to the backlog
            if (MapArray[x_center, z_center]==1)
            {
                for (int x = x_center - 1; x < x_center + 2; x++)
                {
                    for (int z = z_center - 1; z < z_center + 2; z++)
                    {
                        if ((z != z_center || x != x_center) && (MapArray[x, z] != 1) && (MapArray[x, z] != 2))
                        {
                            ToDoList.Add(new int[] { x, z });
                        }
                    }
                }


            }

            // setting all remaining tiles to invisible

            for (int x = 0; x <= VisibilityMap.GetLength(0); x++)
            {
                for (int z = 0; z <= VisibilityMap.GetLength(1); z++)
                {
                    if ( (MapArray[x, z] != 1) && (MapArray[x, z] != 2) )
                    {
                        MapArray[x, z] = 3;
                    }
                }
            }
        }

        return MapArray;
    }

    public void UpdateTheVisibleArea() {

        //Getting latest map details
        (TileMap, VisibilityMap) = GettingTheMap();

        //Getting latest Visible grid
        NewVisible = CalculateTheVisibleArea(VisibilityMap);

        for (int x = 0; x < MapSizeOnX; x++)
        {
            for (int z = 0; z < MapSizeOnZ; z++)
            {
                if (Visible[x,z] == 3 && NewVisible[x,z] == 1)
                {
                    tileMapGround.SetTile(new Vector3Int(x, 0, z), TileMap[x, z]);
                    
                }

                if (Visible[x, z] == 3 && NewVisible[x, z] == 2)
                {

                    tileMapWall.SetTile(new Vector3Int(x, 0, z), TileMap[x, z]);

                }

            }
        }

        Visible = NewVisible;

    }


}

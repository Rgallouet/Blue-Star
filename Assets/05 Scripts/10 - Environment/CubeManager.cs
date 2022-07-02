using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CubeManager : MonoBehaviour {

    public SaveAndLoad saveAndLoad;
    public CityGUI cityGUI;
    public Transform PlayerPrefab;
    public Transform playerInstantiated;
    public int MapSizeOnX;
    public int MapSizeOnZ;

    public Transform[] CubePrefabs;
    public int[] Probability;
    public int[] MaxSpriteLimite;

    // Density function 
    public int AdditiveFactor= 50;
    public int MultiplicativeFactor = 1;
    public int MaximumExcess = 150;

    // Variety of Cubes
    private int NumberofPrefabs = 21;
    private int ObsidianPrefabRefence = 0;
    private int StartPrefabRefence = 11;
    private int EarthCubePrefabRefence = 4;

    public int[,] map;
    public int[,] sprite;
    private int[,] Visible;
    private int[,] NewVisible;



    // Generation offsetting
    float xOffset = 0.5f;
    float yOffset = 0.75f;
    float zOffset = 0.5f;

    //Generation vectors
    Quaternion Setup = Quaternion.identity;
    Vector3 cubePosition;

    // Current cube
    Transform Cube;


    void Start() {

        
    }



    public void GettingTheMap() {

        if (cityGUI.Player.UnderCityExist==0)
        {
            Debug.Log("NewGame!");
            map = CalculateTheMap();
            sprite = CalculateTheSprite();

            saveAndLoad.SavePlayerCityInDataBase(map, sprite);

        }
        else
        {
            Debug.Log("LoadGame!");
            (map, sprite) = saveAndLoad.LoadPlayerCityFromDataBase();
        }


    }




    public void GenerateRandomUnderground() {

        System.Diagnostics.Stopwatch timerMacro = System.Diagnostics.Stopwatch.StartNew();

        GettingTheMap();
        
        Visible = CalculateTheVisibleArea(map);

        
        //Generating the Cubes
        for (int x = 0; x < MapSizeOnX; x++)
        {
            for (int z = 0; z < MapSizeOnZ; z++)
            {
                if (Visible[x,z] != 3)
                {
                    GenerateUndergroundElement(map[x,z],sprite[x,z], x, z);
                }
                
            }
        }

        // Generating the hero
        playerInstantiated = Instantiate(PlayerPrefab, new Vector3(xOffset + (MapSizeOnX/2) +5, 15f, zOffset + (MapSizeOnZ / 2) + 5), Quaternion.Euler(0, 0, 0));
        playerInstantiated.GetComponentsInChildren<GameObjectInformation>()[0].basePlayer = saveAndLoad.LoadPlayerChoicesFromDataBase();

        timerMacro.Stop();
        TimeSpan timespan = timerMacro.Elapsed;

        Debug.Log("Time total de la creation de la carte : " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

    }

    int[,] CalculateTheMap()
    {
        var random = new System.Random();
        System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
        

        int[] localProbability = new int[NumberofPrefabs];

        int[,] MapArray = new int[MapSizeOnX,MapSizeOnZ];
   
        int diceRoll = 0;
        int cumulative = 0;

        
        //Starting Ground
        for (int x = 0; x < MapSizeOnX; x++)
        {
            for (int z = 0; z < MapSizeOnZ; z++)
            {
                // the Strict Borders
                if (x == 0 || x == MapSizeOnX - 1 || z == 0 || z == MapSizeOnZ - 1)  { MapArray[x,z] = ObsidianPrefabRefence; }
                // the starting ground
                else if (x > (MapSizeOnX / 2) + 3 && x < (MapSizeOnX / 2) + 7 && z > (MapSizeOnZ / 2) + 3 && z < (MapSizeOnZ / 2) + 7)  { MapArray[x,z] = StartPrefabRefence; }
                // the rest
                else {
                    for (int i=0; i< NumberofPrefabs; i++) localProbability[i] = Probability[i];
                
                    localProbability[MapArray[x - 1,z]] = Math.Min(localProbability[MapArray[x - 1,z]] + AdditiveFactor + MultiplicativeFactor* Probability[MapArray[x - 1,z]], Probability[MapArray[x - 1,z]]+ MaximumExcess);
                    localProbability[MapArray[x,z-1]] = Math.Min(localProbability[MapArray[x,z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x,z - 1]], Probability[MapArray[x,z - 1]] + MaximumExcess);
                    localProbability[MapArray[x - 1,z-1]] = Math.Min(localProbability[MapArray[x - 1,z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x - 1,z - 1]], Probability[MapArray[x - 1,z - 1]] + MaximumExcess);
                    localProbability[MapArray[x + 1,z - 1]] = Math.Min(localProbability[MapArray[x + 1,z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x + 1,z - 1]], Probability[MapArray[x + 1,z - 1]] + MaximumExcess);

                    int HowMuchDistributionChange = (localProbability[MapArray[x - 1,z]] + localProbability[MapArray[x,z - 1]] + localProbability[MapArray[x - 1,z - 1]] + localProbability[MapArray[x + 1,z - 1]]) - (Probability[MapArray[x - 1,z]] + Probability[MapArray[x,z - 1]] + Probability[MapArray[x - 1,z - 1]] + Probability[MapArray[x + 1,z - 1]]);

                    localProbability[EarthCubePrefabRefence] = localProbability[EarthCubePrefabRefence] - HowMuchDistributionChange;

                    // Debug.Log("How much did the distribution change: " + HowMuchDistributionChange);
                    // for (int i = 0; i < NumberofPrefabs; i++) Debug.Log ("Prefab "+ i +" - Local prob: "+ localProbability[i] +" , Absolu prob: " + Probability[i]) ;


                    diceRoll = random.Next(0, 1000);

                    //Debug.Log("Dice Roll: " + diceRoll + " et la proba obsidienne: " + localProbability[0] + " et le resultat final: " + i);
                    //Debug.Log("Dice Roll by hundred: " + diceRoll / 100);

                    cumulative = 0;

                    for (int i = 0; i < NumberofPrefabs; i++)
                    {
                        cumulative += localProbability[i];
                        if (diceRoll < cumulative)
                        {
                            MapArray[x,z] = i;
                            
                            break;
                        }
                    }
               }
            }
        }

        timer.Stop();
        TimeSpan timespan = timer.Elapsed;

        Debug.Log("Time de la creation de la carte : "+ String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

        return MapArray;


    }
    
    int[,] CalculateTheSprite()
    {

        int[,] MapArray = new int[MapSizeOnX, MapSizeOnZ];

        //Starting Ground
        for (int x = 0; x < MapSizeOnX; x++)
        {
            for (int z = 0; z < MapSizeOnZ; z++)
            {
                
                MapArray[x,z] = UnityEngine.Random.Range(0, MaxSpriteLimite[map[x,z]] -1);

            }
        }
        return MapArray;


    }

    int[,] CalculateTheVisibleArea(int[,] Map) {

        int[,] MapArray = new int[MapSizeOnX,MapSizeOnZ];

        // initialize starting zone
        for (int x = (MapSizeOnX / 2) + 4; x < (MapSizeOnX / 2) + 7; x++)
        {
            for (int z = (MapSizeOnZ / 2) + 4; z < (MapSizeOnZ / 2) + 7; z++)
            {
                MapArray[x,z] = 1;
            }
        }

        //Starting the To Do List
        ArrayList ToDoList = new ArrayList();

        // Getting the first "to do" for getting the empty spaces connected to each other at the start zone

        for (int x = (MapSizeOnX / 2) + 3; x < (MapSizeOnX / 2) + 8; x++)
        {
            for (int z = (MapSizeOnZ / 2) + 3; z < (MapSizeOnZ / 2) + 8; z++)
            {
                if ( (x== (MapSizeOnX / 2) + 3 || x == (MapSizeOnX / 2) + 7 || z == (MapSizeOnZ / 2) + 3 || z == (MapSizeOnZ / 2) + 7) && ( Map[x,z] > 9 && Map[x,z] < 20 ) ) ToDoList.Add(new int[] {x,z});
            }
        }


        // Finishing all the to do spaces to analyse
        int failsafe = 0;
        while (ToDoList.Count > 0 && failsafe < 10000) {

            failsafe = failsafe + 1;
            int x_center = ((int[])ToDoList[0])[0];
            int z_center = ((int[])ToDoList[0])[1];

            MapArray[x_center,z_center] = 1;
            ToDoList.RemoveAt(0);

            for (int x = x_center-1; x < x_center+2; x++)
            {
                for (int z = z_center-1; z < z_center+2; z++)
                {
                    if ( (z!=z_center || x!=x_center) && Map[x,z] > 9 && Map[x,z] < 20 && MapArray[x,z]!=1) {
                        ToDoList.Add(new int[] { x, z });
                    }
                }
            }
            
        }

        bool ShouldIbeSeen = false;
        // Finding all the "transition" state between visible area and invisible area
        for (int x_center = 0; x_center < MapSizeOnX; x_center++)
        {
            for (int z_center = 0; z_center < MapSizeOnZ; z_center++)
            {
                if (MapArray[x_center,z_center] != 1) {

                    ShouldIbeSeen = false;

                    for (int x = Mathf.Max(0, x_center - 1); x < Mathf.Min(MapSizeOnX, x_center + 2); x++)
                    {
                        for (int z = Mathf.Max(0, z_center - 1); z < Mathf.Min(MapSizeOnZ, z_center + 2); z++)
                        {
                            if ((z != z_center || x != x_center) && MapArray[x,z] == 1)  ShouldIbeSeen = true;
                        }
                    }

                    if (ShouldIbeSeen == true) MapArray[x_center,z_center] = 2; else MapArray[x_center,z_center] = 3;

                 }

            }
        }

        return MapArray;
    }

    public void UpdateTheVisibleArea() {

        NewVisible = CalculateTheVisibleArea(map);

        for (int x = 0; x < MapSizeOnX; x++)
        {
            for (int z = 0; z < MapSizeOnZ; z++)
            {
                if (Visible[x,z] == 3 && NewVisible[x,z] != 3 )
                {
                    GenerateUndergroundElement(map[x,z], sprite[x,z], x, z);
                }

            }
        }

        Visible = NewVisible;

    }

    public void GenerateUndergroundElement(int CubeReference,int SpriteRef,int x, int z)
    {

        if (CubeReference > 9)
        {
            Setup = Quaternion.Euler(0, 0, 0);
            cubePosition = new Vector3(xOffset + x, 0, zOffset + z);
        }
        else
        {
            Setup = Quaternion.Euler(0, 0, 0);
            cubePosition = new Vector3(xOffset + x, yOffset, zOffset + z);
        }

        Cube = Instantiate(CubePrefabs[CubeReference], cubePosition, Setup);
        Cube.name = "Pos_" + x + "_" + z;
        Cube.GetComponentsInChildren<SpriteSwitcher>()[0].UpdateSprite(SpriteRef);

    }

}

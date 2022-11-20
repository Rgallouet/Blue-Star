using System;
using System.Collections;
using UnityEngine;

public class CubeManager : MonoBehaviour {

    public SaveAndLoad saveAndLoad;
    public CityGUI cityGUI;
    public Transform PlayerPrefab;
    public Transform playerInstantiated;


    public ZoneConstructionDetail zoneConstructionDetail;
    public TileCode tileCode;

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



    public void GettingTheMap(string MapName) {

        zoneConstructionDetail = cityGUI.saveAndLoad.LoadMapDimension(MapName);
        tileCode = cityGUI.saveAndLoad.LoadTileReferences();

        if (cityGUI.account.CurrentCityRegion == 0)
        {
            Debug.Log(MapName+" - Starting from scratch and generating a new map");

            System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

            // generating the maps by zone
            int[,] mapEasy = CalculateTheMap(zoneConstructionDetail, 0);
            int[,] mapMedium = CalculateTheMap(zoneConstructionDetail, 1);
            int[,] mapHard = CalculateTheMap(zoneConstructionDetail, 2);

            // merging the maps together
            for (int x = 0; x <= 2*zoneConstructionDetail.MapSizeOnX[2]; x++)
            {
                for (int z = 0; z <= 2*zoneConstructionDetail.MapSizeOnZ[2]; z++)
                {
                    map[x, z] = mapEasy[x, z] + mapMedium[x, z] + mapHard[x, z];

                }
            }


            //Debug.Log(MapName + " - Successfully generated a new map");

            sprite = CalculateTheSprite();
            //Debug.Log(MapName + " - Successfully generated the randomised sprites for the map");

            saveAndLoad.SavePlayerCityInDataBase(map, sprite);
            //Debug.Log(MapName + " - Successfully saved the map");

            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            Debug.Log(MapName + " - Time to create and save the map : " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

        }
        else
        {
            Debug.Log(MapName + " - Loading the map saved in database");
            (zoneConstructionDetail.MapSizeOnX[2], zoneConstructionDetail.MapSizeOnZ[2], map, sprite) = saveAndLoad.LoadPlayerCityFromDataBase();
        }


    }

    public void GenerateRandomUnderground(string MapName) {

        GettingTheMap(MapName);
        
        Visible = CalculateTheVisibleArea(map);

        
        //Generating the Cubes
        for (int x = 0 ; x <= 2*zoneConstructionDetail.MapSizeOnX[2]; x++)
        {
            for (int z = 0; z <= 2*zoneConstructionDetail.MapSizeOnZ[2]; z++)
            {
                if (Visible[x,z] != 3)
                {
                    GenerateUndergroundElement(map[x,z],sprite[x,z], x - zoneConstructionDetail.MapSizeOnX[2], z- zoneConstructionDetail.MapSizeOnZ[2]);
                }
                
            }
        }

        // Generating the hero
        playerInstantiated = Instantiate(PlayerPrefab, new Vector3(xOffset + zoneConstructionDetail.MapSizeOnX[2], yOffset, zOffset + zoneConstructionDetail.MapSizeOnZ[2]), Quaternion.Euler(0, 0, 0) );
        playerInstantiated.GetComponentInChildren<GameObjectInformation>().baseCharacter = saveAndLoad.LoadCharacterFromDataBase((long)1);



 

    }

    public int[,] CalculateTheMap(ZoneConstructionDetail zoneConstructionDetail, int ZoneID)
    {


        var random = new System.Random();
        
        int[] localProbability = new int[NumberofPrefabs];

        int[,] MapArray = new int[2*zoneConstructionDetail.MapSizeOnX[2]+1, 2*zoneConstructionDetail.MapSizeOnZ[2]+1];
   
        int diceRoll = 0;
        int cumulative = 0;

        //Debug.Log("Calculate The Map - prepared for looping on through "+MapSizeOnX+" in X and "+ MapSizeOnZ + " in Z");
        
        //Starting Ground
        for (int x = -zoneConstructionDetail.MapSizeOnX[2]; x <= zoneConstructionDetail.MapSizeOnX[2]; x++)
        {
            for (int z = -zoneConstructionDetail.MapSizeOnZ[2]; z <= zoneConstructionDetail.MapSizeOnZ[2]; z++)
            {

                // Skipping if not in the good zone by equal to zero, for sum in the future
                if ( (Math.Abs(x) < zoneConstructionDetail.MinMapSizeOnX[ZoneID] && Math.Abs(z) < zoneConstructionDetail.MinMapSizeOnZ[ZoneID]) 
                    ||
                     (Math.Abs(x) >= zoneConstructionDetail.MapSizeOnX[ZoneID])
                    ||
                     (Math.Abs(z) >= zoneConstructionDetail.MapSizeOnZ[ZoneID])
                    )
                {
                    MapArray[x+ zoneConstructionDetail.MapSizeOnX[2], z+ zoneConstructionDetail.MapSizeOnZ[2]] = 0;

                }
                else
                {

                    //Debug.Log("Calculate The Map - Looping on X="+x+" and Z="+z);

                    // the Strict Borders
                    if (x == -zoneConstructionDetail.MapSizeOnX[2] || x == zoneConstructionDetail.MapSizeOnX[2] || z == -zoneConstructionDetail.MapSizeOnZ[2] || z == zoneConstructionDetail.MapSizeOnZ[2]) { MapArray[x, z] = ObsidianPrefabRefence; }
                    // the starting ground
                    else if (Math.Abs(x) <= 3 && Math.Abs(z) <= 3) { MapArray[x, z] = StartPrefabRefence; }
                    // the rest
                    else
                    {
                        for (int i = 0; i < NumberofPrefabs; i++) localProbability[i] = Probability[i];

                        localProbability[MapArray[x - 1, z]] = Math.Min(localProbability[MapArray[x - 1, z]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x - 1, z]], Probability[MapArray[x - 1, z]] + MaximumExcess);
                        localProbability[MapArray[x, z - 1]] = Math.Min(localProbability[MapArray[x, z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x, z - 1]], Probability[MapArray[x, z - 1]] + MaximumExcess);
                        localProbability[MapArray[x - 1, z - 1]] = Math.Min(localProbability[MapArray[x - 1, z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x - 1, z - 1]], Probability[MapArray[x - 1, z - 1]] + MaximumExcess);
                        localProbability[MapArray[x + 1, z - 1]] = Math.Min(localProbability[MapArray[x + 1, z - 1]] + AdditiveFactor + MultiplicativeFactor * Probability[MapArray[x + 1, z - 1]], Probability[MapArray[x + 1, z - 1]] + MaximumExcess);

                        int HowMuchDistributionChange = (localProbability[MapArray[x - 1, z]] + localProbability[MapArray[x, z - 1]] + localProbability[MapArray[x - 1, z - 1]] + localProbability[MapArray[x + 1, z - 1]]) - (Probability[MapArray[x - 1, z]] + Probability[MapArray[x, z - 1]] + Probability[MapArray[x - 1, z - 1]] + Probability[MapArray[x + 1, z - 1]]);

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
                                MapArray[x, z] = i;

                                break;
                            }
                        }

                    }
                

               }
            }
        }

        return MapArray;


    }
    
    public int[,] CalculateTheSprite()
    {

        int[,] MapArray = new int[2*zoneConstructionDetail.MapSizeOnX[2]+1, 2*zoneConstructionDetail.MapSizeOnZ[2]+1];

        //Starting Ground
        for (int x = 0; x <= 2*zoneConstructionDetail.MapSizeOnX[2]; x++)
        {
            for (int z = 0; z <= 2*zoneConstructionDetail.MapSizeOnZ[2]; z++)
            {
                
                MapArray[x,z] = UnityEngine.Random.Range(0, MaxSpriteLimite[map[x,z]] -1);

            }
        }
        return MapArray;


    }

    public int[,] CalculateTheVisibleArea(int[,] Map) {

        int[,] MapArray = new int[2*zoneConstructionDetail.MapSizeOnX[2]+1, 2*zoneConstructionDetail.MapSizeOnZ[2]+1];

        // initialize starting zone
        for (int x = zoneConstructionDetail.MapSizeOnX[2]-3; x <= zoneConstructionDetail.MapSizeOnX[2] + 3; x++)
        {
            for (int z = zoneConstructionDetail.MapSizeOnZ[2] - 3; z <= zoneConstructionDetail.MapSizeOnZ[2] + 3; z++)
            {
                MapArray[x,z] = 1;
            }
        }

        //Starting the To Do List
        ArrayList ToDoList = new();

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

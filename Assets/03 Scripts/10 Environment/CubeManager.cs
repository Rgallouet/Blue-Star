using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeManager : MonoBehaviour {
    public Transform PlayerPrefab;
    public int MapSize;
    public int AggregationFactor;

    public Transform[] CubePrefabs;
    public int[] Probability;

    private int NumberofPrefabs = 21;

    private int ObsidianPrefabRefence = 0;
    private int StartPrefabRefence = 11;
    private int EarthCubePrefabRefence = 4;
    private int OutOfSightPrefabRefence = 19;


    void Start() {


    }


    public void GenerateRandomUnderground() {

        int[][] Map = CalculateTheMap();
        int[][] Visible = CalculateTheVisibleArea(Map);

        Object Cube;

        float xOffset = 0.5f;
        float yOffset = 0f;
        float zOffset = 0.5f;
        float yOffsetOutOfSight = 0.4f;
        Quaternion Setup = Quaternion.identity;

        //Generating the Cubes
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {

                Setup = Quaternion.Euler(-90, 90 * Random.Range(0, 4), 0);
                Cube = Instantiate(CubePrefabs[Map[x][z]], new Vector3(xOffset + x, yOffset, zOffset + z), Setup); 
                Cube.name= "Pos_" + x +"_"+ z;
                if (Visible[x][z] == 3) Instantiate(CubePrefabs[OutOfSightPrefabRefence], new Vector3(xOffset + x, yOffsetOutOfSight, zOffset + z), Setup);
            }
        }





        Instantiate(PlayerPrefab, new Vector3(xOffset + (MapSize/2) +5, 15f, zOffset + (MapSize / 2) + 5), Quaternion.Euler(0, 0, 0));

    }




    int[][] CalculateTheMap()
    {

        int[] localProbability = new int[NumberofPrefabs];

        int[][] MapArray = new int[MapSize][];
        for (int i = 0; i < MapSize; i++) MapArray[i] = new int[MapSize];


        int diceRoll = 0;
        int cumulative = 0;

        
        //Starting Ground
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                // the Strict Borders
                if (x == 0 || x == MapSize - 1 || z == 0 || z == MapSize - 1)  { MapArray[x][z] = ObsidianPrefabRefence; }
                // the starting ground
                else if (x > (MapSize / 2) + 3 && x < (MapSize / 2) + 7 && z > (MapSize / 2) + 3 && z < (MapSize / 2) + 7)  { MapArray[x][z] = StartPrefabRefence; }
                // the rest
                else {
                    for (int i=0; i< NumberofPrefabs; i++) localProbability[i] = Probability[i];
                
                    localProbability[MapArray[x - 1][z]] += AggregationFactor;

                    localProbability[MapArray[x][z-1]] += AggregationFactor;
                    localProbability[MapArray[x - 1][z-1]] += AggregationFactor;
                    localProbability[MapArray[x + 1][z - 1]] += AggregationFactor;

                    localProbability[EarthCubePrefabRefence] -= 4*AggregationFactor;

                    diceRoll = Random.Range(0, 1000);
                    cumulative = 0;

                    for (int i = 0; i < NumberofPrefabs; i++)
                    {
                        cumulative += localProbability[i];
                        if (diceRoll < cumulative)
                        {
                            MapArray[x][z] = i;
                            break;
                        }
                    }
               }
            }
        }
        return MapArray;


    }

    int[][] CalculateTheVisibleArea(int[][] Map) {

        int[][] MapArray = new int[MapSize][];
        for (int i = 0; i < MapSize; i++) MapArray[i] = new int[MapSize];

        // initialize starting zone
        for (int x = (MapSize / 2) + 4; x < (MapSize / 2) + 7; x++)
        {
            for (int z = (MapSize / 2) + 4; z < (MapSize / 2) + 7; z++)
            {
                MapArray[x][z] = 1;
            }
        }

        //Starting the To Do List
        ArrayList ToDoList = new ArrayList();

        // Getting the first "to do" for getting the empty spaces connected to each other at the start zone

        for (int x = (MapSize / 2) + 3; x < (MapSize / 2) + 8; x++)
        {
            for (int z = (MapSize / 2) + 3; z < (MapSize / 2) + 8; z++)
            {
                if ( (x== (MapSize / 2) + 3 || x == (MapSize / 2) + 7 || z == (MapSize / 2) + 3 || z == (MapSize / 2) + 7) && ( Map[x][z] > 9 && Map[x][z] < 20 ) ) ToDoList.Add(new int[] {x,z});
            }
        }


        // Finishing all the to do spaces to analyse
        int failsafe = 0;
        while (ToDoList.Count > 0 && failsafe < 10000) {

            failsafe = failsafe + 1;
            int x_center = ((int[])ToDoList[0])[0];
            int z_center = ((int[])ToDoList[0])[1];

            MapArray[x_center][z_center] = 1;
            ToDoList.RemoveAt(0);

            for (int x = x_center-1; x < x_center+2; x++)
            {
                for (int z = z_center-1; z < z_center+2; z++)
                {
                    if ( (z!=z_center || x!=x_center) && Map[x][z] > 9 && Map[x][z] < 20 && MapArray[x][z]!=1) {
                        ToDoList.Add(new int[] { x, z });
                    }
                }
            }
            
        }

        bool ShouldIbeSeen = false;
        // Finding all the "transition" state between visible area and invisible area
        for (int x_center = 0; x_center < MapSize; x_center++)
        {
            for (int z_center = 0; z_center < MapSize; z_center++)
            {
                if (MapArray[x_center][z_center] != 1) {

                    ShouldIbeSeen = false;

                    for (int x = Mathf.Max(0, x_center - 1); x < Mathf.Min(MapSize, x_center + 2); x++)
                    {
                        for (int z = Mathf.Max(0, z_center - 1); z < Mathf.Min(MapSize, z_center + 2); z++)
                        {
                            if ((z != z_center || x != x_center) && MapArray[x][z] == 1)  ShouldIbeSeen = true;
                        }
                    }

                    if (ShouldIbeSeen == true) MapArray[x_center][z_center] = 2; else MapArray[x_center][z_center] = 3;

                 }

            }
        }

        return MapArray;
    }


}

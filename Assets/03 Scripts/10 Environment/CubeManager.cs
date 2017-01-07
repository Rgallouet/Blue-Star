using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeManager : MonoBehaviour {

    public Transform[] CubePrefabs;
    public int MapSize;
    public int AggregationFactor;
    public int[] Probability;

    //private string[] CubeChosen = { "Obsidian", "Gold", "Rock", "Empty", "SolidEarth", "Earth" };
    private int[] CubeReference = { 0, 1, 2, 3, 4, 5 };
    private int[] InverseCubeReference = { 0, 1, 2, 3, 4, 5 };

    private int NumberofPrefabs = 6;
    private int ObsidianPrefabRefence = 0;
    private int StartPrefabRefence = 3;

    void Start() {


    }


    public void GenerateRandomUnderground() {

        int[][] LowerLevel = CalculateTheLowerMap();
        int[][] HigherLevel = CalculateTheHigherMap();
        
        float xOffset = 0.5f;
        float yOffsetLow = 0.416f;
        float yOffsetHigh = 2* yOffsetLow;
        float zOffsetHigh = 0.5f;
        Quaternion Setup = Quaternion.identity;

        //Generating the Cubes
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                Setup = Quaternion.Euler(90, 90 * Random.Range(0, 4), 0);
                Instantiate(CubePrefabs[LowerLevel[x][z]], new Vector3(xOffset + x, yOffsetLow, 0.5f + z), Setup);

                Setup = Quaternion.Euler(90, 90 * Random.Range(0, 4), 0);
                if (!(HigherLevel[x][z]==3)) Instantiate(CubePrefabs[HigherLevel[x][z]], new Vector3(xOffset + x, yOffsetHigh, zOffsetHigh + z), Setup);

            }
        }
        

    }


   int[][] CalculateTheLowerMap() {


        int[][] MapArray = new int[MapSize][];
        for (int i = 0; i < MapSize; i++) MapArray[i] = new int[MapSize];


        //Starting Ground
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                // the Strict Borders
                if (x > (MapSize / 2) + 3 && x < (MapSize / 2) + 7 && z > (MapSize / 2) + 3 && z < (MapSize / 2) + 7)
                {
                    MapArray[x][z] = 2;
                }
                else {

                    MapArray[x][z] = 5;
                }
            }
        }

        return MapArray;

    }

    


    int[][] CalculateTheHigherMap()
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
                
                    localProbability[InverseCubeReference[MapArray[x - 1][z]]] += AggregationFactor;

                    localProbability[InverseCubeReference[MapArray[x][z-1]]] += AggregationFactor;
                    localProbability[InverseCubeReference[MapArray[x - 1][z-1]]] += AggregationFactor;
                    localProbability[InverseCubeReference[MapArray[x + 1][z - 1]]] += AggregationFactor;

                    localProbability[InverseCubeReference[5]] -= 4*AggregationFactor;

                    diceRoll = Random.Range(0, 1000);
                    cumulative = 0;

                    for (int i = 0; i < NumberofPrefabs; i++)
                    {
                        cumulative += localProbability[i];
                        if (diceRoll < cumulative)
                        {
                            MapArray[x][z] = CubeReference[i];
                            break;
                        }
                    }
               }
            }
        }
        return MapArray;


    }


}

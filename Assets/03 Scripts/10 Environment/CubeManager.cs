using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeManager : MonoBehaviour {

    public Transform[] CubePrefabs;
    public int MapSize;
    public int AggregationFactor;
    public int[] Probability;

    //private string[] CubeChosen = { "Obsidian", "Gold", "Empty", "Rock", "Earth" };
    private int[] CubeReference = { 3, 2, 4, 1, 0 };
    private int[] InverseCubeReference = { 4, 3, 1, 0, 2 };

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
                if (HigherLevel[x][z] < 4) Instantiate(CubePrefabs[HigherLevel[x][z]], new Vector3(xOffset + x, yOffsetHigh, zOffsetHigh + z), Setup);

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
                    MapArray[x][z] = 1;
                }
                else {

                    MapArray[x][z] = 0;
                }
            }
        }

        return MapArray;

    }

    


    int[][] CalculateTheHigherMap()
    {

        int[] localProbability = new int[5];

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
                if (x == 0 || x == MapSize - 1 || z == 0 || z == MapSize - 1)  { MapArray[x][z] = 3; }
                // the starting ground
                else if (x > (MapSize / 2) + 3 && x < (MapSize / 2) + 7 && z > (MapSize / 2) + 3 && z < (MapSize / 2) + 7)  { MapArray[x][z] = 4; }
                // the rest
                else {
                    for (int i=0; i<5; i++) localProbability[i] = Probability[i];
                
                    localProbability[InverseCubeReference[MapArray[x - 1][z]]] += AggregationFactor;
                    localProbability[InverseCubeReference[MapArray[x][z-1]]] += AggregationFactor;
                    localProbability[InverseCubeReference[MapArray[x - 1][z-1]]] += AggregationFactor;
                    localProbability[InverseCubeReference[0]] -= 3*AggregationFactor;
                    diceRoll = Random.Range(0, 1000);
                    cumulative = 0;

                    for (int i = 0; i < 5; i++)
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

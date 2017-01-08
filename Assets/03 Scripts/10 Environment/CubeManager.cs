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

    void Start() {


    }


    public void GenerateRandomUnderground() {

        int[][] Map = CalculateTheMap();
        
        float xOffset = 0.5f;
        float yOffset = 0f;
        float zOffset = 0.5f;
        Quaternion Setup = Quaternion.identity;

        //Generating the Cubes
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {

                Setup = Quaternion.Euler(-90, 90 * Random.Range(0, 4), 0);
                Instantiate(CubePrefabs[Map[x][z]], new Vector3(xOffset + x, yOffset, zOffset + z), Setup);

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


}

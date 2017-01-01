using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {

    public CubeManager cubeManager;
    private Vector2 worldStartPoint;

    void Start () {

        cubeManager.GenerateRandomUnderground();
    }


    void Update()
    {

    }


}

using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {

    public SaveAndLoad saveAndLoad;
    public CubeManager cubeManager;
    private Vector2 worldStartPoint;
    public BasePlayer Player=new BasePlayer();

    void Start () {

        Player = saveAndLoad.LoadPlayerChoicesFromDataBase(GameInformation.Slot);

        cubeManager.GenerateRandomUnderground();


    }



}

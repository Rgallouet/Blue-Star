using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {

    public SaveAndLoadCharacter saveAndLoadCharacter;
    public CubeManager cubeManager;
    private Vector2 worldStartPoint;
    public BasePlayer Player=new BasePlayer();

    void Start () {

        Player = saveAndLoadCharacter.LoadPlayerChoicesFromDataBase(GameInformation.Slot);

        cubeManager.GenerateRandomUnderground();


    }



}

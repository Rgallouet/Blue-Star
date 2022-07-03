using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {


    public DataBaseManager dataBaseManager;
    public SaveAndLoad saveAndLoad;
    public CubeManager cubeManager;
    private Vector2 worldStartPoint;
    public BaseCharacter baseCharacter=new();
    public BaseAccount account = new();

    void Start () {

        account = saveAndLoad.LoadAccountDetails();
        baseCharacter = saveAndLoad.LoadCharacterFromDataBase(1);

        cubeManager.GenerateRandomUnderground();


    }



}

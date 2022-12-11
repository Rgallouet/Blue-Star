using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {


    public DataBaseManager dataBaseManager;
    public SaveAndLoad saveAndLoad;
    public CubeManager cubeManager;
    private Vector2 worldStartPoint;
    public BaseCharacter baseCharacter=new();
    public BaseAccount account;

    void Start () {

        saveAndLoad.LoadAccountDetails(account);
        baseCharacter = saveAndLoad.LoadCharacterFromDataBase((long)1);
        cubeManager.GenerateMap();


    }



}

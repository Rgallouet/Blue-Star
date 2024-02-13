using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInformation : MonoBehaviour {


    public enum ObjectCategory { Character, Wall, Ground };


    public string ObjectName;
    public ObjectCategory objectCategory;
    public int CanBeDigged;
    public int CanBeBuilt;


    // Possible object categories
    public BaseCharacter baseCharacter;



}

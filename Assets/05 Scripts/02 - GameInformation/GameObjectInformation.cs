using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInformation : MonoBehaviour {

    public enum ObjectCategory { Player, Character, Wall, Ground };


    public string ObjectName;
    public ObjectCategory objectCategory;
    public bool CanBeDigged;

}

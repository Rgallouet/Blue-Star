﻿using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

    public static GameInformation instance = null;
	public BasePlayer basePlayer;


	void Start(){
        

		//Check if instance already exists : if not, set instance to this
		if (instance == null) instance = this;

		//If instance already exists and it's not this:
		else if (instance != this) Destroy(gameObject);    


		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

        basePlayer = new BasePlayer();
    }
    
	

	
	// Equipment
	public static BaseEquipment EquipmentOne	{ get; set;}
	public static BasePlayer 	BasePlayer		{ get; set;}




}

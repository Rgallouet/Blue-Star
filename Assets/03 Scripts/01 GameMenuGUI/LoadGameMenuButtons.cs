﻿using UnityEngine;
using System.Collections;

public class LoadGameMenuButtons : MonoBehaviour {

	public static Canvas LoadGameMenu;


	void Awake(){
		LoadGameMenu = GetComponent<Canvas>();
		LoadGameMenu.enabled = false;
	}



	public void LoadPosition00(){
		if (PlayerPrefs.GetString ("00_Player") != null) 		{GameInformation.BasePlayer=(BasePlayer)PPSerialization.Load("00_Player");}
		if (PlayerPrefs.GetString ("00_EquipmentOne") != null) 	{GameInformation.EquipmentOne=(BaseEquipment)PPSerialization.Load("00_EquipmentOne");}
		MenuGUI.MenuGoNext ();
	}
	
	public void LoadPosition01(){
		if (PlayerPrefs.GetString ("01_Player") != null) 		{GameInformation.BasePlayer=(BasePlayer)PPSerialization.Load("01_Player");}
		if (PlayerPrefs.GetString ("01_EquipmentOne") != null) 	{GameInformation.EquipmentOne=(BaseEquipment)PPSerialization.Load("01_EquipmentOne");}
		MenuGUI.MenuGoNext ();
	}
	
	public void LoadPosition02(){
		if (PlayerPrefs.GetString ("02_Player") != null) 		{GameInformation.BasePlayer=(BasePlayer)PPSerialization.Load("02_Player");}
		if (PlayerPrefs.GetString ("02_EquipmentOne") != null) 	{GameInformation.EquipmentOne=(BaseEquipment)PPSerialization.Load("02_EquipmentOne");}
		MenuGUI.MenuGoNext ();
	}

	public void BackToGameMenuFromLoadScreen(){
		MenuGUI.MenuGoBack ();
	}


}
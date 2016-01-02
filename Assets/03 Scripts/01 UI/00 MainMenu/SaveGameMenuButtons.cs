using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveGameMenuButtons : MonoBehaviour {
	
	public static Canvas SaveGameMenu;
	
	
	void Awake(){
		SaveGameMenu = GetComponent<Canvas>();
		SaveGameMenu.enabled = false;
	}
	
	

	public void SaveChar(int position){

		switch (position) {
		case 0:
			PlayerPrefs.SetString ("Pos01", GameInformation.BasePlayer.PlayerFirstName);
			PPSerialization.Save ("00_Player", GameInformation.BasePlayer);
			if (GameInformation.EquipmentOne != null) {PPSerialization.Save ("00_EquipmentOne", GameInformation.EquipmentOne);}
			MenuGUI.MenuGoNext (0);
		break;
		case 1:
			PlayerPrefs.SetString ("Pos02", GameInformation.BasePlayer.PlayerFirstName);
			PPSerialization.Save ("01_Player", GameInformation.BasePlayer);
			if (GameInformation.EquipmentOne != null) {PPSerialization.Save ("01_EquipmentOne", GameInformation.EquipmentOne);}
			MenuGUI.MenuGoNext (0);
		break;		
		case 2:
			PlayerPrefs.SetString ("Pos03", GameInformation.BasePlayer.PlayerFirstName);
			PPSerialization.Save ("02_Player", GameInformation.BasePlayer);
			if (GameInformation.EquipmentOne != null) {PPSerialization.Save ("02_EquipmentOne", GameInformation.EquipmentOne);}
			MenuGUI.MenuGoNext (0);
		break;
		}



	}
	

	public void BackToCreationMenuFromSaveScreen(){
		MenuGUI.MenuGoBack (0);
	}
	

	public static void GetSaveNames() {


		if (!(PlayerPrefs.GetString ("Pos01") == "")) {SaveGameMenu.GetComponentsInChildren<Text> () [1].text = PlayerPrefs.GetString ("Pos01");}
		if (!(PlayerPrefs.GetString ("Pos02") == "")) {SaveGameMenu.GetComponentsInChildren<Text> () [2].text = PlayerPrefs.GetString ("Pos02");}
		if (!(PlayerPrefs.GetString ("Pos03") == "")) {SaveGameMenu.GetComponentsInChildren<Text> () [3].text = PlayerPrefs.GetString ("Pos03");}

	}


}

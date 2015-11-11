using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGameMenuButtons : MonoBehaviour {

	public static Canvas LoadGameMenu;


	void Awake(){
		LoadGameMenu = GetComponent<Canvas>();
		LoadGameMenu.enabled = false;
	}



	public void LoadChar(int position){

		switch (position) {
		case 0:
			if (PlayerPrefs.GetString ("00_Player") != null) {
				GameInformation.basePlayer = (BasePlayer)PPSerialization.Load ("00_Player");
			}
			if (PlayerPrefs.GetString ("00_EquipmentOne") != null) {
				GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load ("00_EquipmentOne");
			}
			MenuGUI.MenuGoNext ();
			break;
		case 1:
			if (PlayerPrefs.GetString ("01_Player") != null) {
				GameInformation.basePlayer = (BasePlayer)PPSerialization.Load ("01_Player");
			}
			if (PlayerPrefs.GetString ("01_EquipmentOne") != null) {
				GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load ("01_EquipmentOne");
			}
			MenuGUI.MenuGoNext ();
			break;		
		case 2:
			if (PlayerPrefs.GetString ("02_Player") != null) {
				GameInformation.basePlayer = (BasePlayer)PPSerialization.Load ("02_Player");
			}
			if (PlayerPrefs.GetString ("02_EquipmentOne") != null) {
				GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load ("02_EquipmentOne");
			}
			MenuGUI.MenuGoNext ();
			break;
		}
	}

	public void BackToGameMenuFromLoadScreen(){
		MenuGUI.MenuGoBack ();
	}

	public static void GetLoadNames() {

		if (!(PlayerPrefs.GetString ("Pos01") == "")) {LoadGameMenu.GetComponentsInChildren<Text> () [1].text = PlayerPrefs.GetString ("Pos01");}
		if (!(PlayerPrefs.GetString ("Pos02") == "")) {LoadGameMenu.GetComponentsInChildren<Text> () [2].text = PlayerPrefs.GetString ("Pos02");}
		if (!(PlayerPrefs.GetString ("Pos03") == "")) {LoadGameMenu.GetComponentsInChildren<Text> () [3].text = PlayerPrefs.GetString ("Pos03");}
		
	}





}

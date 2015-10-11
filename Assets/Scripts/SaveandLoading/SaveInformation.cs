using UnityEngine;
using System.Collections;

public class SaveInformation {

	public static void SaveAllInformation(){
		PlayerPrefs.SetInt ("PLAYERLEVEL", GameInformation.PlayerLevel);
		PlayerPrefs.SetString ("PLAYERFIRSTNAME", GameInformation.PlayerFirstName);
		PlayerPrefs.SetInt ("HP", GameInformation.HP);
		PlayerPrefs.SetInt ("AP", GameInformation.AP);


		if (GameInformation.EquipmentOne != null) {
			PPSerialization.Save ("EquipmentOne", GameInformation.EquipmentOne);
		}

		Debug.Log ("Data saved");
	
	}

}

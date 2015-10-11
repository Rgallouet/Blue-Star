using UnityEngine;
using System.Collections;

public class SaveInformation {

	public static void SaveAllInformation(){


		if (GameInformation.EquipmentOne != null) {
			PPSerialization.Save ("EquipmentOne", GameInformation.EquipmentOne);
		}

		Debug.Log ("Data saved");
	
	}

}

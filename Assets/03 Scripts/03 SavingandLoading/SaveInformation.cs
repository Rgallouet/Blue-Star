using UnityEngine;
using System.Collections;

public class SaveInformation {

	public static void SaveAllInformation(int Save_position){

		if (Save_position==0) {
			PPSerialization.Save ("00_Player", GameInformation.basePlayer);
			
			if (GameInformation.EquipmentOne != null) {
				PPSerialization.Save ("00_EquipmentOne", GameInformation.EquipmentOne);
			}


		}

		if (Save_position==1) {
			PPSerialization.Save ("01_Player", GameInformation.basePlayer);
			
			if (GameInformation.EquipmentOne != null) {
				PPSerialization.Save ("01_EquipmentOne", GameInformation.EquipmentOne);
			}
			
			
		}

		if (Save_position==2) {
			PPSerialization.Save ("02_Player", GameInformation.basePlayer);
			
			if (GameInformation.EquipmentOne != null) {
				PPSerialization.Save ("02_EquipmentOne", GameInformation.EquipmentOne);
			}
			
			
		}




		Debug.Log ("Data saved");
	
	}

}

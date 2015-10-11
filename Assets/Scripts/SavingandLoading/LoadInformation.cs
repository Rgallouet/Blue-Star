using UnityEngine;
using System.Collections;

public class LoadInformation  {
			
		public static void LoadAllInformation(){



		if (PlayerPrefs.GetString ("EquipmentOne") != null) {
			GameInformation.EquipmentOne=(BaseEquipment)PPSerialization.Load("EquipmentOne");
		}



		}
		

}

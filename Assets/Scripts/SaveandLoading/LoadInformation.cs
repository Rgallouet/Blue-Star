using UnityEngine;
using System.Collections;

public class LoadInformation  {
			
		public static void LoadAllInformation(){
		GameInformation.PlayerLevel=	PlayerPrefs.GetInt ("PLAYERLEVEL");
		GameInformation.PlayerFirstName=PlayerPrefs.GetString ("PLAYERFIRSTNAME");
		GameInformation.HP=				PlayerPrefs.GetInt ("HP");
		GameInformation.AP=				PlayerPrefs.GetInt ("AP");


		if (PlayerPrefs.GetString ("EquipmentOne") != null) {
			GameInformation.EquipmentOne=(BaseEquipment)PPSerialization.Load("EquipmentOne");
		}



		}
		

}

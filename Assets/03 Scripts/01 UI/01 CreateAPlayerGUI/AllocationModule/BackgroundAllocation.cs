using UnityEngine;
using System.Collections;

public class BackgroundAllocation {

	

	private string[] genderSelectionNames = new string[] {"Male","Female","Bigender","Pangender","Agender","Other"};



	public void StoreLastInfo(string PlayerFirstName,string PlayerLastName,string PlayerBio, int genderSelection ){

		GameInformation.BasePlayer.PlayerFirstName = 				PlayerFirstName;
		GameInformation.BasePlayer.PlayerLastName = 				PlayerLastName;
		GameInformation.BasePlayer.PlayerBio = 						PlayerBio;
		GameInformation.BasePlayer.PlayerGender=					genderSelectionNames[genderSelection-1];
		
	}


}

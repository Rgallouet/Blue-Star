using UnityEngine;
using System.Collections;

public class BackgroundAllocation {

	

	private string[] genderSelectionNames = new string[] {"Male","Female","Bigender","Pangender","Agender","Other"};



	public void StoreLastInfo(string PlayerFirstName,string PlayerLastName,string PlayerBio, int genderSelection ){

		GameInformation.basePlayer.PlayerFirstName = 				PlayerFirstName;
		GameInformation.basePlayer.PlayerLastName = 				PlayerLastName;
		GameInformation.basePlayer.PlayerBio = 						PlayerBio;
		GameInformation.basePlayer.PlayerGender=					genderSelectionNames[genderSelection-1];
		
	}


}

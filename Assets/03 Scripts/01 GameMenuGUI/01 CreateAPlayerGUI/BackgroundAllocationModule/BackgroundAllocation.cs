using UnityEngine;
using System.Collections;

public class BackgroundAllocation {


	private string PlayerFirstName = "Demonic first name"; 		//
	private string PlayerLastName="Demonic last name"; 			//
	private string PlayerBio="Demonic history"; 				//
	private int genderSelection;

	private string[] genderSelectionNames = new string[] {"Male","Female","Bigender","Pangender","Agender","Other"};

	
	public void DisplayFinalSetup(){
		//name
		PlayerFirstName = GUI.TextArea (new Rect (100, 100, 150, 35), PlayerFirstName, 18);
		PlayerLastName = GUI.TextArea (new Rect (260, 100, 150, 35), PlayerLastName, 18);
		//gender
		genderSelection=GUI.SelectionGrid(new Rect(100,260,310,150),genderSelection,genderSelectionNames,1);
		//Description
		PlayerBio = GUI.TextArea (new Rect (100, 150, 310, 100), PlayerBio, 50);
	}

	public void StoreLastInfo(){

		GameInformation.basePlayer.PlayerFirstName = 				PlayerFirstName;
		GameInformation.basePlayer.PlayerLastName = 				PlayerLastName;
		GameInformation.basePlayer.PlayerBio = 					PlayerBio;
		GameInformation.basePlayer.PlayerGender=					genderSelectionNames[genderSelection];
		
	}


}

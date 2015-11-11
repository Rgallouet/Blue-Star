using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundSelectionButtons : MonoBehaviour {

	public static Canvas BackgroundSelection;

	public static GridLayoutGroup[] ChoiceDisplay = new GridLayoutGroup[3]; 

	public static string PlayerFirstName;
	public static string PlayerLastName;
	public static string PlayerBio;
	public static int genderSelection=0;

	void Start () {
		
		BackgroundSelection = GetComponent<Canvas>();

		for (int i=0;i<3;i++) {
			ChoiceDisplay[i]=BackgroundSelection.GetComponentsInChildren<GridLayoutGroup>()[i];
		}


		BackgroundSelection.enabled = false;
		
	}

	public static bool TestDetails () {
		PlayerFirstName = ChoiceDisplay [0].GetComponentsInChildren<Text> () [2].text;
		PlayerLastName = ChoiceDisplay [0].GetComponentsInChildren<Text> () [5].text;
		PlayerBio=ChoiceDisplay [1].GetComponentsInChildren<Text> () [2].text;
		
		for (int i=0; i<6; i++) {
			if (ChoiceDisplay [2].GetComponentsInChildren<Toggle> () [i].isOn==true) {genderSelection=i+1;}
		}

		if( !(PlayerFirstName=="") && !(PlayerLastName=="") && !(PlayerBio=="") && !(genderSelection==0) ) {return true;} else {return false; }
	}
	

	public static void SendDetails (){
		MenuGUI.CallSendDetails(PlayerFirstName,PlayerLastName,PlayerBio,genderSelection);

}
}
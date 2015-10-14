using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public static CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,CLASSSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();



	

	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MENU;
	}


	void OnGUI () {

		if (currentState == CreateAPlayerStates.MENU) {}
		if (currentState == CreateAPlayerStates.LOAD) {}

		if (currentState == CreateAPlayerStates.CLASSSELECTION) {
			displayFunctions.DisplayMainItems ();
			displayFunctions.DisplayClassSelections();
		}
		if (currentState == CreateAPlayerStates.STATALLOCATION) {
			displayFunctions.DisplayMainItems ();
			displayFunctions.DisplayStatAllocation();
		}		
		if (currentState == CreateAPlayerStates.FINALSETUP) {
			displayFunctions.DisplayMainItems ();
			displayFunctions.DisplayFinalSetup();
		}	

		if (currentState == CreateAPlayerStates.SAVE) {}

		if (currentState == CreateAPlayerStates.PLAY) {
			displayFunctions.DisplayMainItems ();
			displayFunctions.DisplayFinalSetup();
		}	
	}


}

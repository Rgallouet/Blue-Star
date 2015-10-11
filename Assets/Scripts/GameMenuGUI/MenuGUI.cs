using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {


	public enum CreateAPlayerStates{MENU,LOAD,CLASSSELECTION,STATALLOCATION,FINALSETUP}

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();
	private DisplayGameMenu displayGameMenu = new DisplayGameMenu ();


	public static CreateAPlayerStates currentState;

	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MENU;
	}





	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case(CreateAPlayerStates.MENU):
			break;		
		case(CreateAPlayerStates.LOAD):
			break;
		case(CreateAPlayerStates.CLASSSELECTION):
			break;
		case(CreateAPlayerStates.STATALLOCATION):
			break;
		case(CreateAPlayerStates.FINALSETUP):
			break;

		}
	}


	void OnGUI () {

		if (currentState == CreateAPlayerStates.MENU) {
			displayGameMenu.DisplayMenuSelection ();
		}
		if (currentState == CreateAPlayerStates.LOAD) {
		
		}

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
	}


}

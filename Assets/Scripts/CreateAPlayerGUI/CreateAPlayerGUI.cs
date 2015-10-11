using UnityEngine;
using System.Collections;

public class CreateAPlayerGUI : MonoBehaviour {


	public enum CreateAPlayerStates{CLASSSELECTION,STATALLOCATION,FINALSETUP}

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();
	public static CreateAPlayerStates currentState;

	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.CLASSSELECTION;

	}





	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case(CreateAPlayerStates.CLASSSELECTION):
			break;
		case(CreateAPlayerStates.STATALLOCATION):
			break;
		case(CreateAPlayerStates.FINALSETUP):
			break;

		}
	}


	void OnGUI () {

		displayFunctions.DisplayMainItems ();

		if (currentState == CreateAPlayerStates.CLASSSELECTION) {
			displayFunctions.DisplayClassSelections();
		}
		if (currentState == CreateAPlayerStates.STATALLOCATION) {
			displayFunctions.DisplayStatAllocation();
		}		
		if (currentState == CreateAPlayerStates.FINALSETUP) {
			displayFunctions.DisplayFinalSetup();
		}	
	}


}

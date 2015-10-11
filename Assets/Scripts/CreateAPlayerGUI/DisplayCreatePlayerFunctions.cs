using UnityEngine;
using System.Collections;
using System.Linq;

public class DisplayCreatePlayerFunctions {

	private int classSelection;
	private string[] classSelectionNames = new string[] {"Butcher","Lord","Class3","Class4","Class5","Class6"};

	private HistoryAllocation historyAllocation = new HistoryAllocation();
	private StatAllocation statAllocation = new StatAllocation();
	private BackgroundAllocation backgroundAllocation = new BackgroundAllocation();





	// Main steps
	public void DisplayClassSelections(){
		//A list of toggle buttons and each button will be a class
		classSelection=GUI.SelectionGrid(new Rect(100,100,100,300),classSelection,classSelectionNames,1);
		GUI.Label (new Rect (Screen.width-400, 100, 300, 300), FindClassDescription (classSelection));
	}


	public void DisplayStatAllocation(){
		//a list of stats with plus and minus buttons
		statAllocation.DisplayStatAllocationModule();
		}

	public void DisplayFinalSetup(){
		// name, history and gender
		backgroundAllocation.DisplayFinalSetup();
	}




	// Main interface
	public void DisplayMainItems(){

		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;

		GUI.Label (new Rect (100, 20, (Screen.width)-200, 50), "Tell me more about yourself, my sweet devious child?");

		if(GUI.RepeatButton(new Rect((Screen.width/2)-100,(Screen.height)-120,50,50),"<<")){
			//turn transform tagged as player to the left
			player.Rotate(Vector3.up);
		}
		if(GUI.RepeatButton(new Rect((Screen.width/2)+50,(Screen.height)-120,50,50),">>")){
			//turn transform tagged as player to the right
			player.Rotate(Vector3.down);
		}

		if (!(MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP)) {
			// If not in final setup, then show next button
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height) - 120, 50, 50), "Next")) {
				
				if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.CLASSSELECTION) {
					Debug.Log ("avant display");
					Debug.Log (GameInformation.basePlayer.PlayerFirstName);

					historyAllocation.ChooseClass(classSelection);
					MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
					
				} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION) {
					// to be changed by loops (all stats)
					statAllocation.StoreStatAllocation();
					MenuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;
				}
				
				
			}	
		} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height) - 120, 50, 50), "Finish")) {
				// Final Save
				backgroundAllocation.StoreLastInfo();
				Debug.Log ("Make Final Save");
			}
				
		}

			if (GUI.Button(new Rect ((Screen.width / 2) - 25, (Screen.height) - 60, 50, 50), "Back")) {
				
			if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION) {
				MenuGUI.currentState = MenuGUI.CreateAPlayerStates.CLASSSELECTION;
				statAllocation.didRunOnce=false;	
			} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP) {
				MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
				}
				
				
			}	



	}








	public string FindClassDescription(int classSelection){
		
		if (classSelection == 0) {
			BaseClass tempClass = new ButcherClass();
			return tempClass.ClassDescription;
			
		} else if (classSelection == 1) {
			BaseClass tempClass = new LordClass();
			return tempClass.ClassDescription;
		}
		return "When daddy asks, I'd better reply quickly...";
		
	}








	// Selecting the class and creating the character




}

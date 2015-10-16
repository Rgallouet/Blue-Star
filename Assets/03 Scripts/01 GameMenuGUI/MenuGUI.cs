using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public static CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,CLASSSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();

	private static HistoryAllocation historyAllocation = new HistoryAllocation();
	private static StatAllocation statAllocation= new StatAllocation();
	private static BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

	private static int classSelection;


	

	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MENU;
	}



	public static void MenuGoBack(){
		if (currentState == CreateAPlayerStates.STATALLOCATION) {
			//Go back to ClassSelection
			currentState = CreateAPlayerStates.CLASSSELECTION;
			//Reset the "get base stat" function
			statAllocation.didRunOnce=false;	
		} else if (currentState == CreateAPlayerStates.FINALSETUP) {
			//Go back to stat allocation
			currentState = CreateAPlayerStates.STATALLOCATION;
		}
	}

	public static void MenuGoNext(){

		if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.CLASSSELECTION) {
			// Define the class and base stat
			historyAllocation.ChooseClass (classSelection);
			// Then go to user-defined stat allocation 
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
			
		} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION) {
			// Apply the current selection of stats
			statAllocation.StoreStatAllocation ();
			// Then go to final set up
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;
			
		} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP) {
			// Save locally Information about name, bio, gender 
			backgroundAllocation.StoreLastInfo ();
			// Then go to global save
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVE;
			
		} else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP) {
			
			//Save all information
			//go to Play
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;
		}}


}

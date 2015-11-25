using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public static CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,HISTORYSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}

	private static HistoryAllocation historyAllocation = new HistoryAllocation();
	private static StatAllocation statAllocation= new StatAllocation();
	private static BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

	public static GameObject Stand;
	public static GameObject Player;


	public static int hellCircleSelection;
	public static int allegianceSelection;
	public static int genusSelection;
	public static int speciesSelection;
	public static int classSelection;
	public static int impSelection;
	public static int originSelection;	
	public static int temperSelection;	
	public static int astroSelection;	
	public static int affinitySelection;

	public static bool lastActionWasNext;



	void Start () {
		currentState = CreateAPlayerStates.MENU;
		Stand = GameObject.FindGameObjectWithTag ("Stand");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Stand.SetActive(false);
		Player.SetActive(false);

		hellCircleSelection=0;
		allegianceSelection=0;
		genusSelection=0;
		speciesSelection = 0;
		classSelection=0;
		impSelection=0;
		originSelection=0;	
		temperSelection=0;	
		astroSelection=0;	
		affinitySelection=0;
		lastActionWasNext = true;

	}











	public static void MenuLoad(){
		lastActionWasNext = true;
		currentState = CreateAPlayerStates.LOAD;
		GameMenuButtons.GameMenu.enabled = false;
		LoadGameMenuButtons.LoadGameMenu.enabled = true;
		LoadGameMenuButtons.GetLoadNames();
	}









	
	public static void MenuGoNext(){
		
		lastActionWasNext = true;
		
		switch (currentState) {
			
		case CreateAPlayerStates.MENU:
			currentState = CreateAPlayerStates.HISTORYSELECTION;
			GameMenuButtons.GameMenu.enabled = false;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
			HistorySelectionButtons.HistorySelection.enabled = true;
			Stand.SetActive (true);
			Player.SetActive (true);
			break;
			
		case CreateAPlayerStates.HISTORYSELECTION: 
			HistorySelectionNext ();
			if(HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.END){	
				historyAllocation.CreateNewPlayer (hellCircleSelection, allegianceSelection, genusSelection, speciesSelection, classSelection, impSelection, originSelection, temperSelection, astroSelection, affinitySelection);
				currentState = CreateAPlayerStates.STATALLOCATION;
				HistorySelectionButtons.HistorySelection.enabled = false;
				StatAllocationButtons.StatAllocationMenu.enabled = true;
				statAllocation.DisplayStatAllocationModule();
			}
			break;
			
		case CreateAPlayerStates.STATALLOCATION: 
			if (statAllocation.readyForNext==true) {
				statAllocation.StoreStatAllocation ();
				currentState = CreateAPlayerStates.FINALSETUP;
				StatAllocationButtons.StatAllocationMenu.enabled = false;
				BackgroundSelectionButtons.BackgroundSelection.enabled=true;
			}
			break;
			
		case CreateAPlayerStates.FINALSETUP:
			bool ReadyforNext=BackgroundSelectionButtons.TestDetails();

			if (ReadyforNext==true) {
				BackgroundSelectionButtons.SendDetails();
				BackgroundSelectionButtons.BackgroundSelection.enabled=false;
				CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = false;
				SaveGameMenuButtons.SaveGameMenu.enabled=true;
				SaveGameMenuButtons.GetSaveNames();
				currentState = CreateAPlayerStates.SAVE;
			}
			break;

		case CreateAPlayerStates.LOAD: 
			LoadGameMenuButtons.LoadGameMenu.enabled = false;
			currentState = CreateAPlayerStates.PLAY;
			Application.LoadLevel("Play");
			break;

		case CreateAPlayerStates.SAVE:
			SaveGameMenuButtons.SaveGameMenu.enabled=false;
			currentState = CreateAPlayerStates.PLAY;
			Stand.SetActive (false);
			Player.SetActive (false);
			Application.LoadLevel("Play");
			break;
		}
		
	}







	public static void MenuGoBack(){

		lastActionWasNext = false;

		switch (currentState) {
		
		case CreateAPlayerStates.MENU:
			Application.Quit ();
			break;

		case CreateAPlayerStates.LOAD:
			currentState = CreateAPlayerStates.MENU;
			LoadGameMenuButtons.LoadGameMenu.enabled = false;
			GameMenuButtons.GameMenu.enabled = true;
			break;

		case CreateAPlayerStates.HISTORYSELECTION:
			HistorySelectionBack ();
			if (HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.START) {
				currentState = CreateAPlayerStates.MENU;
				CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = false;
				HistorySelectionButtons.HistorySelection.enabled = false;
				GameMenuButtons.GameMenu.enabled = true;
				Stand.SetActive (false);
				Player.SetActive (false);
			}
			break;

		case CreateAPlayerStates.STATALLOCATION:
			StatAllocationButtons.StatAllocationMenu.enabled = false;
			currentState = CreateAPlayerStates.HISTORYSELECTION;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.AFFINITY;
			statAllocation.didRunOnce = false;
			HistorySelectionButtons.HistoryChoice = affinitySelection;
			HistorySelectionButtons.HistorySelection.enabled = true;
			break;

		case CreateAPlayerStates.FINALSETUP:
			BackgroundSelectionButtons.BackgroundSelection.enabled=false;
			StatAllocationButtons.StatAllocationMenu.enabled = true;
			currentState = CreateAPlayerStates.STATALLOCATION;
			break;

		case CreateAPlayerStates.SAVE:
			SaveGameMenuButtons.SaveGameMenu.enabled=false;
			BackgroundSelectionButtons.BackgroundSelection.enabled=true;
			currentState = CreateAPlayerStates.FINALSETUP;
			break;

		}
	}











































	
	public static void HistorySelectionNext(){
	

		if (!(HistorySelectionButtons.HistoryChoice == 0)) {

			switch (HistorySelectionButtons.currentStep) {

			case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
				hellCircleSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE:
				allegianceSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.GENUS;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.GENUS:
				genusSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.SPECIES;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.SPECIES:
				speciesSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.CLASS;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.CLASS:
				classSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.IMP;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.IMP:
				impSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ORIGIN:
				originSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.TEMPER;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.TEMPER: 
				temperSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ASTRO;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ASTRO:
				astroSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.AFFINITY;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.AFFINITY: 
				affinitySelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.END;
				break;
			}

			if(!(HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.END)) {
			HistorySelectionButtons.GetHistoryUIButtons ();
			HistorySelectionButtons.HistoryChoice = 0;
			}
		}
	}









	
	
	public static void HistorySelectionBack(){

		switch (HistorySelectionButtons.currentStep) {

		case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.START;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE:
			HistorySelectionButtons.HistoryChoice = hellCircleSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.GENUS:
			HistorySelectionButtons.HistoryChoice = allegianceSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.SPECIES:
			HistorySelectionButtons.HistoryChoice = genusSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.GENUS;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.CLASS:
			HistorySelectionButtons.HistoryChoice = speciesSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.SPECIES;
			break;
	
		case HistorySelectionButtons.PlayerHistoryStep.IMP:
			HistorySelectionButtons.HistoryChoice = classSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.CLASS;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.ORIGIN:
			HistorySelectionButtons.HistoryChoice = impSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.IMP;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.TEMPER: 
			HistorySelectionButtons.HistoryChoice = originSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.ASTRO:
			HistorySelectionButtons.HistoryChoice = temperSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.TEMPER;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.AFFINITY: 
			HistorySelectionButtons.HistoryChoice = astroSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ASTRO;
			break;
		}

		HistorySelectionButtons.GetHistoryUIButtons ();


	}





	public static void CallSendDetails(string PlayerFirstName,string PlayerLastName,string PlayerBio, int genderSelection){
		backgroundAllocation.StoreLastInfo (PlayerFirstName,PlayerLastName,PlayerBio,genderSelection);
	}



	public static void CallStatAllocationMoveStat(bool Move,int Stat_ID){
		statAllocation.MoveStat (Move, Stat_ID);
		statAllocation.RefreshDisplayStatsStatus ();
		statAllocation.CalculateDisplayPlusMinusButtons ();
	}


}

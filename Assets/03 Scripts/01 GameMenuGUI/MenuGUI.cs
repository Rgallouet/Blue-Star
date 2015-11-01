using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public static CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,HISTORYSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();

	private static HistoryAllocation historyAllocation = new HistoryAllocation();
	private static StatAllocation statAllocation= new StatAllocation();
	private static BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

	public static GameObject Stand;
	public static GameObject Player;


	public static int hellCircleSelection;
	public static int genusSelection;
	public static int speciesSelection;
	public static int classSelection;
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
		genusSelection=0;
		speciesSelection = 0;
		classSelection=0;
		originSelection=0;	
		temperSelection=0;	
		astroSelection=0;	
		affinitySelection=0;

		lastActionWasNext = true;

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
			break;

		case CreateAPlayerStates.STATALLOCATION:
			StatAllocationButtons.StatAllocationMenu.enabled = false;
			currentState = CreateAPlayerStates.HISTORYSELECTION;
			statAllocation.didRunOnce = false;
			HistorySelectionButtons.HistoryChoice = affinitySelection;
			HistorySelectionButtons.HistorySelection.enabled = true;
			break;

		case CreateAPlayerStates.FINALSETUP:
			currentState = CreateAPlayerStates.STATALLOCATION;
			break;

		case CreateAPlayerStates.SAVE:
			currentState = CreateAPlayerStates.FINALSETUP;
			break;

		}
	}















	public static void MenuGoNext(){

		lastActionWasNext = true;

		switch (MenuGUI.currentState) {

		case MenuGUI.CreateAPlayerStates.MENU:
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.HISTORYSELECTION;
			GameMenuButtons.GameMenu.enabled = false;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
			HistorySelectionButtons.HistorySelection.enabled = true;
			Stand.SetActive (true);
			Player.SetActive (true);
			break;

		case MenuGUI.CreateAPlayerStates.LOAD: 
			LoadGameMenuButtons.LoadGameMenu.enabled = false;
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;
			break;

		case MenuGUI.CreateAPlayerStates.HISTORYSELECTION: 
			HistorySelectionNext ();
			break;

		case MenuGUI.CreateAPlayerStates.STATALLOCATION: 
			statAllocation.StoreStatAllocation ();
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;
			break;

		case MenuGUI.CreateAPlayerStates.FINALSETUP:
			backgroundAllocation.StoreLastInfo ();
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVE;
			break;

		case MenuGUI.CreateAPlayerStates.SAVE:
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;
			break;
		}

	}








	public static void MenuLoad(){
		lastActionWasNext = true;
		MenuGUI.currentState = MenuGUI.CreateAPlayerStates.LOAD;
		GameMenuButtons.GameMenu.enabled = false;
		LoadGameMenuButtons.LoadGameMenu.enabled = true;
	}




















	
	public static void HistorySelectionNext(){
	

		if (HistorySelectionButtons.HistoryChoice == 0) {
		} else {

			switch (HistorySelectionButtons.currentStep) {

			case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
				hellCircleSelection = HistorySelectionButtons.HistoryChoice;
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
				historyAllocation.CreateNewPlayer (hellCircleSelection, genusSelection, speciesSelection, classSelection, originSelection, temperSelection, astroSelection, affinitySelection);
				MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
				HistorySelectionButtons.HistorySelection.enabled = false;
				StatAllocationButtons.StatAllocationMenu.enabled = true;
				StatAllocation.DisplayStatAllocationModule();
				break;
			}

			if(!(HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.AFFINITY)) {
			HistorySelectionButtons.GetHistoryUIButtons ();
			HistorySelectionButtons.HistoryChoice = 0;
			}
		}
	}









	
	
	public static void HistorySelectionBack(){

		switch (HistorySelectionButtons.currentStep) {
		case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
			currentState = CreateAPlayerStates.MENU;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = false;
			HistorySelectionButtons.HistorySelection.enabled = false;
			GameMenuButtons.GameMenu.enabled = true;
			Stand.SetActive (false);
			Player.SetActive (false);
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.GENUS:
			HistorySelectionButtons.HistoryChoice = hellCircleSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.SPECIES:
			HistorySelectionButtons.HistoryChoice = genusSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.GENUS;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.CLASS:
			HistorySelectionButtons.HistoryChoice = speciesSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.SPECIES;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.ORIGIN:
			HistorySelectionButtons.HistoryChoice = classSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.CLASS;
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

}

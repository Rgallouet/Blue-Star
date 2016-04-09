using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour {

	public static CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,MODESELECTION,PREDEFINEDSELECTION,HISTORYSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}

	private static HistoryAllocation historyAllocation = new HistoryAllocation();
	private static StatAllocation statAllocation= new StatAllocation();
	private static BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

	public MenuAudio menuAudio;


	public GameObject Stand;
	public GameObject Player;
	

	//private int hellCircleSelection;
	//private int allegianceSelection;
	//private int genusSelection;
	//private int speciesSelection;
	//private int jobSelection;
	//private int impSelection;
	//private int originSelection;	
	//private int temperSelection;	
	//private int astroSelection;	
	//private int affinitySelection;

	public static int HellCircleSelection 	{ get; set; }
	public static int AllegianceSelection 	{ get; set; }
	public static int GenusSelection 		{ get; set; }
	public static int SpeciesSelection 		{ get; set; }
	public static int JobSelection 			{ get; set; }
	public static int ImpSelection 			{ get; set; }
	public static int OriginSelection 		{ get; set; }	
	public static int TemperSelection 		{ get; set; }	
	public static int AstroSelection 		{ get; set; }	
	public static int AffinitySelection 	{ get; set; }
	


	public static bool lastActionWasNext;



	void Start () {

		// Get objects
		currentState = CreateAPlayerStates.MENU;

		Stand.SetActive(false);
		Player.SetActive(false);

		// Initiate selections
		HellCircleSelection=0;
		AllegianceSelection=0;
		GenusSelection=0;
		SpeciesSelection = 0;
		JobSelection=0;
		ImpSelection=0;
		OriginSelection=0;	
		TemperSelection=0;	
		AstroSelection=0;	
		AffinitySelection=0;

		// Initiate transition status
		lastActionWasNext = true;




	}









	
public void MenuGoNext(int Option){
		
		lastActionWasNext = true;
		
		switch (currentState) {
			
		case CreateAPlayerStates.MENU:

			switch (Option) {
			case 1: // I chose "New game"
			currentState = CreateAPlayerStates.MODESELECTION;
			GameMenuButtons.GameMenu.enabled = false;
			NewGameMenuButtons.NewGameMenu.enabled = true;
			break;

			case 2: // I chose "load game"
			currentState = CreateAPlayerStates.LOAD;
			GameMenuButtons.GameMenu.enabled = false;
			LoadGameMenuButtons.LoadGameMenu.enabled = true;
			LoadGameMenuButtons.GetLoadNames();
			break;
			}
		break;


		case CreateAPlayerStates.MODESELECTION:
			menuAudio.PlayCreationMenuAudio();
			switch (Option) {
			case 1: // I chose "Guided"
				currentState = CreateAPlayerStates.PREDEFINEDSELECTION;
				NewGameMenuButtons.NewGameMenu.enabled = false;
				CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
				PreDefinedSelectionButtons.PreDefinedSelection.enabled = true;
				Stand.SetActive (true);
				Player.SetActive (true);
				break;
				
			case 2: // I chose "Custom"
				currentState = CreateAPlayerStates.HISTORYSELECTION;
				NewGameMenuButtons.NewGameMenu.enabled = false;
				CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
				HistorySelectionButtons.HistorySelection.enabled = true;
				Stand.SetActive (true);
				Player.SetActive (true);
				break;
			}
		break;

		case CreateAPlayerStates.PREDEFINEDSELECTION: 
			if (!(PreDefinedSelectionButtons.HistoryChoice == 0)) {
			HistorySelectionNext (Option);
			historyAllocation.CreateNewPlayer (HellCircleSelection, AllegianceSelection, GenusSelection, SpeciesSelection, JobSelection, ImpSelection, OriginSelection, TemperSelection, AstroSelection, AffinitySelection);
			currentState = CreateAPlayerStates.STATALLOCATION;
			PreDefinedSelectionButtons.PreDefinedSelection.enabled = false;
			StatAllocationButtons.StatAllocationMenu.enabled = true;
				statAllocation.DisplayStatAllocationModule();
			}
			break;

			
		case CreateAPlayerStates.HISTORYSELECTION: 
			HistorySelectionNext (Option);
			if(HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.END){	
				historyAllocation.CreateNewPlayer (HellCircleSelection, AllegianceSelection, GenusSelection, SpeciesSelection, JobSelection, ImpSelection, OriginSelection, TemperSelection, AstroSelection, AffinitySelection);
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
			SceneManager.LoadScene("Play");
			break;

		case CreateAPlayerStates.SAVE:
			SaveGameMenuButtons.SaveGameMenu.enabled=false;
			currentState = CreateAPlayerStates.PLAY;
			Stand.SetActive (false);
			Player.SetActive (false);
			Debug.Log("Before:" + GameInformation.BasePlayer.PlayerFirstName.ToString());
            SceneManager.LoadScene("Play");
			Debug.Log("After 1:" + GameInformation.BasePlayer.PlayerFirstName.ToString());

			break;
		}
		
	}







	public void MenuGoBack(int option){

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

		case CreateAPlayerStates.MODESELECTION:
			currentState = CreateAPlayerStates.MENU;
			NewGameMenuButtons.NewGameMenu.enabled = false;
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
				menuAudio.PlayGameMenuAudio();
			}
			break;

		case CreateAPlayerStates.PREDEFINEDSELECTION:
				currentState = CreateAPlayerStates.MENU;
				CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = false;
				PreDefinedSelectionButtons.PreDefinedSelection.enabled = false;
				GameMenuButtons.GameMenu.enabled = true;
				Stand.SetActive (false);
				Player.SetActive (false);
				menuAudio.PlayGameMenuAudio();
			break;

		case CreateAPlayerStates.STATALLOCATION:

			switch (option) {
			case 1:

				StatAllocationButtons.StatAllocationMenu.enabled = false;
				currentState = CreateAPlayerStates.PREDEFINEDSELECTION;
				statAllocation.didRunOnce = false;
				PreDefinedSelectionButtons.PreDefinedSelection.enabled = true;
				break;
			case 2:
			
				StatAllocationButtons.StatAllocationMenu.enabled = false;
				currentState = CreateAPlayerStates.HISTORYSELECTION;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.AFFINITY;
				statAllocation.didRunOnce = false;
				HistorySelectionButtons.HistoryChoice = AffinitySelection;
				HistorySelectionButtons.HistorySelection.enabled = true;
				break;

			}


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











































	
	public static void HistorySelectionNext(int mode){
	


		switch(mode){

		case 1:
			if (!(PreDefinedSelectionButtons.HistoryChoice == 0)) {

				HellCircleSelection = PreDefinedSelectionButtons.HellCircleChoice;
				AllegianceSelection = PreDefinedSelectionButtons.AllegianceChoice;
				GenusSelection = PreDefinedSelectionButtons.GenusChoice;
				SpeciesSelection = PreDefinedSelectionButtons.SpeciesChoice;
				JobSelection = PreDefinedSelectionButtons.JobChoice;
				ImpSelection = PreDefinedSelectionButtons.ImpChoice;
				OriginSelection = PreDefinedSelectionButtons.OriginChoice;
				TemperSelection = PreDefinedSelectionButtons.TemperChoice;
				AstroSelection = PreDefinedSelectionButtons.AstroChoice;
				AffinitySelection = PreDefinedSelectionButtons.AffinityChoice;

			}
			break;

		case 2:
			if (!(HistorySelectionButtons.HistoryChoice == 0)) {
			switch (HistorySelectionButtons.currentStep) {

			case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
				HellCircleSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE:
				AllegianceSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.GENUS;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.GENUS:
				GenusSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.SPECIES;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.SPECIES:
				SpeciesSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.CLASS;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.CLASS:
				JobSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.IMP;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.IMP:
				ImpSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ORIGIN:
				OriginSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.TEMPER;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.TEMPER: 
				TemperSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ASTRO;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.ASTRO:
				AstroSelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.AFFINITY;
				break;

			case HistorySelectionButtons.PlayerHistoryStep.AFFINITY: 
				AffinitySelection = HistorySelectionButtons.HistoryChoice;
				HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.END;
				break;
			}

			if(!(HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.END)) {
			HistorySelectionButtons.GetHistoryUIButtons ();
			HistorySelectionButtons.HistoryChoice = 0;
			}
		}
			break;








		}
	}










	
	
	public static void HistorySelectionBack(){

		switch (HistorySelectionButtons.currentStep) {

		case HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE:
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.START;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE:
			HistorySelectionButtons.HistoryChoice = HellCircleSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.GENUS:
			HistorySelectionButtons.HistoryChoice = AllegianceSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ALLEGIANCE;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.SPECIES:
			HistorySelectionButtons.HistoryChoice = GenusSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.GENUS;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.CLASS:
			HistorySelectionButtons.HistoryChoice = SpeciesSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.SPECIES;
			break;
	
		case HistorySelectionButtons.PlayerHistoryStep.IMP:
			HistorySelectionButtons.HistoryChoice = JobSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.CLASS;
			break;

		case HistorySelectionButtons.PlayerHistoryStep.ORIGIN:
			HistorySelectionButtons.HistoryChoice = ImpSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.IMP;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.TEMPER: 
			HistorySelectionButtons.HistoryChoice = OriginSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.ASTRO:
			HistorySelectionButtons.HistoryChoice = TemperSelection;
			HistorySelectionButtons.currentStep = HistorySelectionButtons.PlayerHistoryStep.TEMPER;
			break;
			
		case HistorySelectionButtons.PlayerHistoryStep.AFFINITY: 
			HistorySelectionButtons.HistoryChoice = AstroSelection;
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
		statAllocation.RefreshDisplayStatsNumbers ();
		statAllocation.CalculateDisplayPlusMinusButtons ();
	}




	// AUDIO






}

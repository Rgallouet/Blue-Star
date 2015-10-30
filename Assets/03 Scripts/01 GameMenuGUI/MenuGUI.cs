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







	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MENU;
		Stand = GameObject.FindGameObjectWithTag ("Stand");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Stand.SetActive(false);
		Player.SetActive(false);

		hellCircleSelection=1;
		genusSelection=1;
		speciesSelection = 1;
		classSelection=1;
		originSelection=1;	
		temperSelection=1;	
		astroSelection=1;	
		affinitySelection=1;

		lastActionWasNext = true;

	}















	public static void MenuGoBack(){
		lastActionWasNext = false;

		if (currentState == CreateAPlayerStates.MENU) 
		
		{Application.Quit();}

		else if (currentState == CreateAPlayerStates.LOAD) 
			
		{	currentState = CreateAPlayerStates.MENU;
			LoadGameMenuButtons.LoadGameMenu.enabled= false;
			GameMenuButtons.GameMenu.enabled = true;
		} 

		else if (currentState == CreateAPlayerStates.HISTORYSELECTION) 
		
		{	HistorySelectionBack();} 

		else if (currentState == CreateAPlayerStates.STATALLOCATION) 
		
		{	
			currentState = CreateAPlayerStates.HISTORYSELECTION;
			statAllocation.didRunOnce=false;
			HistorySelectionButtons.HistorySelection.enabled=true;} 

		else if (currentState == CreateAPlayerStates.FINALSETUP) 
		
		{currentState = CreateAPlayerStates.STATALLOCATION;}

		else if (currentState == CreateAPlayerStates.SAVE) 
			
		{currentState = CreateAPlayerStates.FINALSETUP;}


	}















	public static void MenuGoNext(){

		lastActionWasNext = true;

		if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.MENU) 

		{	MenuGUI.currentState = MenuGUI.CreateAPlayerStates.HISTORYSELECTION;
			GameMenuButtons.GameMenu.enabled = false;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
			HistorySelectionButtons.HistorySelection.enabled=true;
			Stand.SetActive(true);
			Player.SetActive(true);}

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.LOAD) 
			
		{	LoadGameMenuButtons.LoadGameMenu.enabled=false;
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;} 

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.HISTORYSELECTION) 
		
		{	HistorySelectionNext();} 

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.STATALLOCATION) 
		
		{	statAllocation.StoreStatAllocation ();
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;} 


		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.FINALSETUP) 
		
		{	backgroundAllocation.StoreLastInfo ();
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVE;} 

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.SAVE) 
		
		{	//Save all information
			//go to Play
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;
		}
	}










	public static void MenuLoad(){
		lastActionWasNext = true;
		MenuGUI.currentState = MenuGUI.CreateAPlayerStates.LOAD;
		GameMenuButtons.GameMenu.enabled = false;
		LoadGameMenuButtons.LoadGameMenu.enabled = true;
	}




















	
	public static void HistorySelectionNext(){
		
		if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE) {
			hellCircleSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetGenusButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.GENUS;
		}
		
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.GENUS) {
			genusSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetSpeciesButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.SPECIES;
		}
		
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.SPECIES) {
			speciesSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetClassButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.CLASS;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.CLASS) {
			classSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetOriginButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.ORIGIN) {
			originSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetTemperButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.TEMPER;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.TEMPER) {
			temperSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetAstroButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.ASTRO;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.ASTRO) {
			astroSelection=HistorySelectionButtons.HistoryChoice;
			HistorySelectionButtons.GetAffinityButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.AFFINITY;
		}
		
		else if (HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.AFFINITY) 
			
		{	affinitySelection=HistorySelectionButtons.HistoryChoice;
			historyAllocation.CreateNewPlayer(hellCircleSelection,genusSelection,speciesSelection,classSelection,originSelection,temperSelection,astroSelection,affinitySelection);
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;
			HistorySelectionButtons.HistorySelection.enabled=false;

		}
		
		
	}










	
	
	public static void HistorySelectionBack(){
		
		if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE) {
			currentState = CreateAPlayerStates.MENU;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled= false;
			HistorySelectionButtons.HistorySelection.enabled=false;
			GameMenuButtons.GameMenu.enabled = true;
			Stand.SetActive(false);
			Player.SetActive(false);
		}
		
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.GENUS) {
			HistorySelectionButtons.GetHellCircleButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.HELLCIRCLE;
		}
		
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.SPECIES) {
			HistorySelectionButtons.GetGenusButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.GENUS;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.CLASS) {
			HistorySelectionButtons.GetSpeciesButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.SPECIES;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.ORIGIN) {
			HistorySelectionButtons.GetClassButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.CLASS;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.TEMPER) {
			HistorySelectionButtons.GetOriginButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.ORIGIN;
		}
		else if (HistorySelectionButtons.currentStep == HistorySelectionButtons.PlayerHistoryStep.ASTRO) {
			HistorySelectionButtons.GetTemperButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.TEMPER;
		}
		
		else if (HistorySelectionButtons.currentStep==HistorySelectionButtons.PlayerHistoryStep.AFFINITY) 
			
		{	HistorySelectionButtons.GetAstroButtons();
			HistorySelectionButtons.currentStep=HistorySelectionButtons.PlayerHistoryStep.ASTRO;}
		
		
	}




}

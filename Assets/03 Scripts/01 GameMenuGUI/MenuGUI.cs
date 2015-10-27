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

	public static GameObject Stand;
	public static GameObject Player;











	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MENU;
		Stand = GameObject.FindGameObjectWithTag ("Stand");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Stand.SetActive(false);
		Player.SetActive(false);
	}















	public static void MenuGoBack(){

		if (currentState == CreateAPlayerStates.MENU) 
		
		{Application.Quit();}

		else if (currentState == CreateAPlayerStates.LOAD) 
			
		{	currentState = CreateAPlayerStates.MENU;
			LoadGameMenuButtons.LoadGameMenu.enabled= false;
			GameMenuButtons.GameMenu.enabled = true;
		} 

		else if (currentState == CreateAPlayerStates.CLASSSELECTION) 
		
		{	currentState = CreateAPlayerStates.MENU;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled= false;
			HistorySelectionButtons.HistorySelection.enabled=false;
			GameMenuButtons.GameMenu.enabled = true;
			Stand.SetActive(false);
			Player.SetActive(false);} 

		else if (currentState == CreateAPlayerStates.STATALLOCATION) 
		
		{	//Go back to ClassSelection
			currentState = CreateAPlayerStates.CLASSSELECTION;
			//Reset the "get base stat" function
			statAllocation.didRunOnce=false;} 

		else if (currentState == CreateAPlayerStates.FINALSETUP) 
		
		{currentState = CreateAPlayerStates.STATALLOCATION;}

		else if (currentState == CreateAPlayerStates.SAVE) 
			
		{currentState = CreateAPlayerStates.FINALSETUP;}


	}















	public static void MenuGoNext(){

		if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.MENU) 

		{	MenuGUI.currentState = MenuGUI.CreateAPlayerStates.CLASSSELECTION;
			GameMenuButtons.GameMenu.enabled = false;
			CreationGameMenuStaticButtons.CreationGameMenuStatic.enabled = true;
			HistorySelectionButtons.HistorySelection.enabled=true;
			Stand.SetActive(true);
			Player.SetActive(true);}

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.LOAD) 
			
		{	LoadGameMenuButtons.LoadGameMenu.enabled=false;
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.PLAY;} 

		else if (MenuGUI.currentState == MenuGUI.CreateAPlayerStates.CLASSSELECTION) 
		
		{	historyAllocation.ChooseClass (classSelection);
			MenuGUI.currentState = MenuGUI.CreateAPlayerStates.STATALLOCATION;} 

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
		MenuGUI.currentState = MenuGUI.CreateAPlayerStates.LOAD;
		GameMenuButtons.GameMenu.enabled = false;
		LoadGameMenuButtons.LoadGameMenu.enabled = true;
	}












}

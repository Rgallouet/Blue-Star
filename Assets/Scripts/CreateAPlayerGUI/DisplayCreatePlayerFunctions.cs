using UnityEngine;
using System.Collections;
using System.Linq;

public class DisplayCreatePlayerFunctions {


	private BasePlayer newPlayer;

	private int classSelection;

	private string[] classSelectionNames = new string[] {"Butcher","Lord","Class3","Class4","Class5","Class6"};
	private string[] genderSelectionNames = new string[] {"Male","Female","Bigender","Pangender","Agender","Other"};

	private string PlayerFirstName = "Demonic first name"; 		//
	private string PlayerLastName="Demonic last name"; 			//
	private string PlayerBio="Demonic history"; 				//
	private int genderSelection;

	private StatAllocationModule statAllocationModule = new StatAllocationModule();


	public void DisplayClassSelections(){
		//A list of toggle buttons and each button will be a class
		classSelection=GUI.SelectionGrid(new Rect(100,100,100,300),classSelection,classSelectionNames,1);
		GUI.Label (new Rect (Screen.width-400, 100, 300, 300), FindClassDescription (classSelection));
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
	

	public void DisplayStatAllocation(){
		//a list of stats with plus and minus buttons
		statAllocationModule.DisplayStatAllocationModule();

	}

	public void DisplayFinalSetup(){
		//name
		PlayerFirstName = GUI.TextArea (new Rect (100, 100, 150, 35), PlayerFirstName, 18);
		PlayerLastName = GUI.TextArea (new Rect (260, 100, 150, 35), PlayerLastName, 18);
		//gender
		genderSelection=GUI.SelectionGrid(new Rect(100,260,310,150),genderSelection,genderSelectionNames,1);
		//Description
		PlayerBio = GUI.TextArea (new Rect (100, 150, 310, 100), PlayerBio, 50);
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

		if (!(CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)) {
			// If not in final setup, then show next button
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height) - 120, 50, 50), "Next")) {
				
				if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION) {
					ChooseClass (classSelection);
					CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
					
				} else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION) {
					// to be changed by loops (all stats)
					StoreStatAllocation();
					CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP;
				}
				
				
			}	
		} else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height) - 120, 50, 50), "Finish")) {
				// Final Save
				StoreLastInfo();
				Debug.Log ("Make Final Save");
			}
				
		}

			if (GUI.Button(new Rect ((Screen.width / 2) - 25, (Screen.height) - 60, 50, 50), "Back")) {
				
			if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION) {
				CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION;
				statAllocationModule.didRunOnce=false;	
			} else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP) {
				CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
				}
				
				
			}	



	}



	// Selecting the class and creating the character

	
	private void ChooseClass(int classSelection) {
		if (classSelection == 0) {
			newPlayer = new BasePlayer ();
			newPlayer.PlayerClass= new ButcherClass();
			CreateNewPlayer();
			StoreNewPlayerInfo();
			SaveInformation.SaveAllInformation();
		}
		else if (classSelection == 1) {
			newPlayer = new BasePlayer ();
			newPlayer.PlayerClass= new LordClass();
			CreateNewPlayer();
			StoreNewPlayerInfo();
			SaveInformation.SaveAllInformation();
		}
	}


	
	private void CreateNewPlayer(){
		
		// Init level
		newPlayer.PlayerLevel=1;
		
		newPlayer.TotalXP=0;
		newPlayer.CurrentXP=0;
		newPlayer.RequiredXP=100;
		newPlayer.HumanCrap = 0;
		
		newPlayer.PrimaryStatPointsToAllocate=5;
		newPlayer.HeroicStatPointsToAllocate=0;
		newPlayer.SecondaryStatPointsToAllocate=5;
		
		//HP are always 100, same for action points
		newPlayer.HP=			100+newPlayer.PlayerClass.HP; 			//Health Points are always 100
		newPlayer.AP=			100+newPlayer.PlayerClass.AP;			//Action Points are always 100
		
		newPlayer.CurrentHP = newPlayer.HP;
		newPlayer.CurrentAP = newPlayer.AP;


		int Base_prim = 20;
		int Base_heroic = 10;
		int Base_sec = 100;


		newPlayer.Strength = Base_prim+newPlayer.PlayerClass.Strength;
		newPlayer.Speed = Base_prim+newPlayer.PlayerClass.Speed;
		newPlayer.Dexterity = Base_prim+newPlayer.PlayerClass.Dexterity;
		newPlayer.Reflex = Base_prim+newPlayer.PlayerClass.Reflex;
		newPlayer.Resilience = Base_prim+newPlayer.PlayerClass.Resilience;
		newPlayer.Knowledge = Base_prim+newPlayer.PlayerClass.Knowledge;
		newPlayer.Elocution = Base_prim+newPlayer.PlayerClass.Elocution;
		newPlayer.Intellect = Base_prim+newPlayer.PlayerClass.Intellect;
		newPlayer.Focus = Base_prim+newPlayer.PlayerClass.Focus;
		newPlayer.Mockery = Base_prim+newPlayer.PlayerClass.Mockery;
		newPlayer.Malevolant = Base_prim+newPlayer.PlayerClass.Malevolant;
		newPlayer.Unmerciful = Base_prim+newPlayer.PlayerClass.Unmerciful;
		newPlayer.Rage = Base_heroic+newPlayer.PlayerClass.Rage;
		newPlayer.Phase = Base_heroic+newPlayer.PlayerClass.Phase;
		newPlayer.Momentum = Base_sec+newPlayer.PlayerClass.Momentum;
		newPlayer.Balance = Base_sec+newPlayer.PlayerClass.Balance;
		newPlayer.Luck = Base_sec+newPlayer.PlayerClass.Luck;
		newPlayer.Perception = Base_sec+newPlayer.PlayerClass.Perception;
		newPlayer.Judgement = Base_sec+newPlayer.PlayerClass.Judgement;
		newPlayer.Chaos = Base_sec+newPlayer.PlayerClass.Chaos;



	}


	private void StoreNewPlayerInfo(){

		GameInformation.TotalXP = newPlayer.TotalXP;
		GameInformation.CurrentXP = newPlayer.CurrentXP;
		GameInformation.RequiredXP = newPlayer.RequiredXP;

		GameInformation.PrimaryStatPointsToAllocate = newPlayer.PrimaryStatPointsToAllocate;
		GameInformation.HeroicStatPointsToAllocate = newPlayer.HeroicStatPointsToAllocate;
		GameInformation.SecondaryStatPointsToAllocate = newPlayer.SecondaryStatPointsToAllocate;

		GameInformation.HumanCrap = newPlayer.HumanCrap;
		GameInformation.CurrentHP = newPlayer.CurrentHP;
		GameInformation.CurrentAP = newPlayer.CurrentAP;
		GameInformation.HP = newPlayer.HP;
		GameInformation.AP = newPlayer.AP;
	

		GameInformation.Strength = newPlayer.Strength;
		GameInformation.Speed = newPlayer.Speed;
		GameInformation.Dexterity = newPlayer.Dexterity;
		GameInformation.Reflex = newPlayer.Reflex;
		GameInformation.Resilience = newPlayer.Resilience;
		GameInformation.Knowledge = newPlayer.Knowledge;
		GameInformation.Elocution = newPlayer.Elocution;
		GameInformation.Intellect = newPlayer.Intellect;
		GameInformation.Focus = newPlayer.Focus;
		GameInformation.Mockery = newPlayer.Mockery;
		GameInformation.Malevolant = newPlayer.Malevolant;
		GameInformation.Unmerciful = newPlayer.Unmerciful;
		GameInformation.Rage = newPlayer.Rage;
		GameInformation.Phase = newPlayer.Phase;
		GameInformation.Momentum = newPlayer.Momentum;
		GameInformation.Balance = newPlayer.Balance;
		GameInformation.Luck = newPlayer.Luck;
		GameInformation.Perception = newPlayer.Perception;
		GameInformation.Judgement = newPlayer.Judgement;
		GameInformation.Chaos = newPlayer.Chaos;



	}


	private void StoreStatAllocation(){

		GameInformation.PrimaryStatPointsToAllocate=	statAllocationModule.primaryStatPointsToAllocate;
		GameInformation.HeroicStatPointsToAllocate=		statAllocationModule.heroicStatPointsToAllocate;
		GameInformation.SecondaryStatPointsToAllocate=	statAllocationModule.secondaryStatPointsToAllocate;

		GameInformation.Strength = newPlayer.Strength;
		GameInformation.Speed = newPlayer.Speed;
		GameInformation.Dexterity = newPlayer.Dexterity;
		GameInformation.Reflex = newPlayer.Reflex;
		GameInformation.Resilience = newPlayer.Resilience;
		GameInformation.Knowledge = newPlayer.Knowledge;
		GameInformation.Elocution = newPlayer.Elocution;
		GameInformation.Intellect = newPlayer.Intellect;
		GameInformation.Focus = newPlayer.Focus;
		GameInformation.Mockery = newPlayer.Mockery;
		GameInformation.Malevolant = newPlayer.Malevolant;
		GameInformation.Unmerciful = newPlayer.Unmerciful;
		GameInformation.Rage = newPlayer.Rage;
		GameInformation.Phase = newPlayer.Phase;
		GameInformation.Momentum = newPlayer.Momentum;
		GameInformation.Balance = newPlayer.Balance;
		GameInformation.Luck = newPlayer.Luck;
		GameInformation.Perception = newPlayer.Perception;
		GameInformation.Judgement = newPlayer.Judgement;
		GameInformation.Chaos = newPlayer.Chaos;
	}

	
	private void StoreLastInfo(){
		
		GameInformation.PlayerFirstName = 				PlayerFirstName;
		GameInformation.PlayerLastName = 				PlayerLastName;
		GameInformation.PlayerBio = 					PlayerBio;
		GameInformation.PlayerGender=					genderSelectionNames[genderSelection];

	}


}

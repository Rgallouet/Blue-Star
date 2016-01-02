using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class StatAllocation{



	public int[] primaryPointsToAllocate = new int[14];
	public int[] heroicPointsToAllocate = new int[2];
	public int[] secondaryPointsToAllocate = new int[6];

	public int[] primaryPointsMinimum = new int[14];
	public int[] heroicPointsMinimum = new int[2];
	public int[] secondaryPointsMinimum = new int[6];

	private bool[] primaryStatSelectionsPlus = new bool[14];
	private bool[] heroicStatSelectionsPlus = new bool[2];
	private bool[] secondaryStatSelectionsPlus = new bool[6];

	private bool[] primaryStatSelectionsMinus = new bool[14];
	private bool[] heroicStatSelectionsMinus = new bool[2];
	private bool[] secondaryStatSelectionsMinus = new bool[6];

	public int primaryStatPointsToAllocate;
	public int heroicStatPointsToAllocate;
	public int secondaryStatPointsToAllocate;

	public bool didRunOnce=false;
	public bool readyForNext = false;





	public void DisplayStatAllocationModule(){

		if (!didRunOnce) {
			RetrieveStatBaseStatPoints ();
			didRunOnce=true;}

	
		InitialisePlusMinusButtons ();
		CalculateDisplayPlusMinusButtons ();
		RefreshDisplayStatsNumbers ();
	}


	public void MoveStat(bool Move,int Stat_ID){

		switch (Move) {
		case true:

			if (Stat_ID < 14) {
				++primaryPointsToAllocate [Stat_ID];
				--primaryStatPointsToAllocate;
			} else if (Stat_ID < 16) {
				++heroicPointsToAllocate [Stat_ID - 14];
				--heroicStatPointsToAllocate;
			} else {
				++secondaryPointsToAllocate [Stat_ID - 16];
				--secondaryStatPointsToAllocate;
			}
			break;

		case false:

			if (Stat_ID < 14) {
				--primaryPointsToAllocate [Stat_ID];
				++primaryStatPointsToAllocate;
			} else if (Stat_ID < 16) {
				--heroicPointsToAllocate [Stat_ID - 14];
				++heroicStatPointsToAllocate;
			} else {
				--secondaryPointsToAllocate [Stat_ID - 16];
				++secondaryStatPointsToAllocate;
			}
			break;

		}

		if (primaryStatPointsToAllocate+heroicStatPointsToAllocate+secondaryStatPointsToAllocate==0) {
			readyForNext=true;
		} else {
			readyForNext=false;
		}

	}







	void InitialisePlusMinusButtons(){
	
		for (int i=0; i<14 ; i++) {
			primaryStatSelectionsMinus[i]=true; 
			StatAllocationButtons.PrimaryMinus [i].interactable=true; 
			StatAllocationButtons.PrimaryMinus [i].GetComponentInChildren<Text>().text="-"; 
			
			primaryStatSelectionsPlus[i]=true;
			StatAllocationButtons.PrimaryPlus [i].interactable=true; 
			StatAllocationButtons.PrimaryPlus [i].GetComponentInChildren<Text>().text="+"; 		
		}
		
		for (int i=0; i<2 ; i++) {
			heroicStatSelectionsMinus[i]=true; 
			StatAllocationButtons.HeroicMinus [i].interactable=true; 
			StatAllocationButtons.HeroicMinus [i].GetComponentInChildren<Text>().text="-"; 
			
			heroicStatSelectionsPlus[i]=true;
			StatAllocationButtons.HeroicPlus [i].interactable=true; 
			StatAllocationButtons.HeroicPlus [i].GetComponentInChildren<Text>().text="+"; 
		}
		
		for (int i=0; i<6 ; i++) {
			secondaryStatSelectionsMinus[i]=true; 
			StatAllocationButtons.SecondaryMinus [i].interactable=true; 
			StatAllocationButtons.SecondaryMinus [i].GetComponentInChildren<Text>().text="-"; 
			
			secondaryStatSelectionsPlus[i]=true;
			StatAllocationButtons.SecondaryPlus [i].interactable=true; 
			StatAllocationButtons.SecondaryPlus [i].GetComponentInChildren<Text>().text="+"; 
		}

	}




	
	public void CalculateDisplayPlusMinusButtons() {
		
		//Display the "Plus" buttons
		if (primaryStatPointsToAllocate > 0) {	
			for (int i=0; i<14 ; i++)	{ 
				if(primaryStatSelectionsPlus[i]==false) {
					StatAllocationButtons.PrimaryPlus [i].interactable=true; 
					StatAllocationButtons.PrimaryPlus [i].GetComponentInChildren<Text>().text="+"; 
					primaryStatSelectionsPlus[i]=true;}}
		} 
		else {			
			for (int i=0; i<14 ; i++)	{ 
				if(primaryStatSelectionsPlus[i]==true) {
					StatAllocationButtons.PrimaryPlus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.PrimaryPlus [i].interactable=false; 
					primaryStatSelectionsPlus[i]=false;}}
		} 
		
		
		if (heroicStatPointsToAllocate > 0) {
			for (int i=0; i<2 ; i++)	{ 
				if(heroicStatSelectionsPlus[i]==false) {
					StatAllocationButtons.HeroicPlus [i].interactable=true; 
					StatAllocationButtons.HeroicPlus [i].GetComponentInChildren<Text>().text="+"; 
					heroicStatSelectionsPlus[i]=true;}}
		} 
		else {			
			for (int i=0; i<2 ; i++)	{ 
				if(heroicStatSelectionsPlus[i]==true) {
					StatAllocationButtons.HeroicPlus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.HeroicPlus [i].interactable=false; 
					heroicStatSelectionsPlus[i]=false;}}
		} 
		
		
		if (secondaryStatPointsToAllocate > 0) {	
			for (int i=0; i<6 ; i++)	{ 
				if(secondaryStatSelectionsPlus[i]==false) {
					StatAllocationButtons.SecondaryPlus [i].interactable=true; 
					StatAllocationButtons.SecondaryPlus [i].GetComponentInChildren<Text>().text="+"; 
					secondaryStatSelectionsPlus[i]=true;}}
		} 
		else {		
			for (int i=0; i<6 ; i++)	{ 
				if(secondaryStatSelectionsPlus[i]==true) {
					StatAllocationButtons.SecondaryPlus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.SecondaryPlus [i].interactable=false; 
					secondaryStatSelectionsPlus[i]=false;}}
		} 
		









		
		//Display the "Minus" buttons
		for (int i=0; i<14 ; i++) {
	
			if (primaryPointsToAllocate[i]-primaryPointsMinimum[i]>0) {
				if(primaryStatSelectionsMinus[i]==false) {
					StatAllocationButtons.PrimaryMinus [i].interactable=true; 
					StatAllocationButtons.PrimaryMinus [i].GetComponentInChildren<Text>().text="-"; 
					primaryStatSelectionsMinus[i]=true;}
			} else {
				if(primaryStatSelectionsMinus[i]==true) {
					StatAllocationButtons.PrimaryMinus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.PrimaryMinus [i].interactable=false; 
					primaryStatSelectionsMinus[i]=false;}
			}
		}
		
		
		for (int i=0; i<2 ; i++) {
			if (heroicPointsToAllocate[i]-heroicPointsMinimum[i]>0) {
				if(heroicStatSelectionsMinus[i]==false) {
					StatAllocationButtons.HeroicMinus [i].interactable=true; 
					StatAllocationButtons.HeroicMinus [i].GetComponentInChildren<Text>().text="-"; 
					heroicStatSelectionsMinus[i]=true;}
			} else {
				if(heroicStatSelectionsMinus[i]==true) {
					StatAllocationButtons.HeroicMinus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.HeroicMinus [i].interactable=false; 
					heroicStatSelectionsMinus[i]=false;}
			}
		}
		
		
		for (int i=0; i<6 ; i++) {
			if (secondaryPointsToAllocate[i]-secondaryPointsMinimum[i]>0) {
				if(secondaryStatSelectionsMinus[i]==false) {
					StatAllocationButtons.SecondaryMinus [i].interactable=true; 
					StatAllocationButtons.SecondaryMinus [i].GetComponentInChildren<Text>().text="-"; 
					secondaryStatSelectionsMinus[i]=true;}
			} else {
				if(secondaryStatSelectionsMinus[i]==true) {
					StatAllocationButtons.SecondaryMinus [i].GetComponentInChildren<Text>().text=""; 
					StatAllocationButtons.SecondaryMinus [i].interactable=false; 
					secondaryStatSelectionsMinus[i]=false;}
			}
		}
	}






	public void RefreshDisplayStatsNumbers(){

			for (int i=0; i<14; i++) {StatAllocationButtons.PrimaryNumbers [i].text = "" + primaryPointsToAllocate [i];}
			for (int i=0; i<2; i++) {StatAllocationButtons.HeroicNumbers [i].text = "" + heroicPointsToAllocate [i];}
			for (int i=0; i<6; i++) {StatAllocationButtons.SecondaryNumbers [i].text = "" + secondaryPointsToAllocate [i];}
			
		StatAllocationButtons.PointsToAlloc [0].text = "" + primaryStatPointsToAllocate;
		StatAllocationButtons.PointsToAlloc [1].text = "" + heroicStatPointsToAllocate;
		StatAllocationButtons.PointsToAlloc [2].text = "" + secondaryStatPointsToAllocate;

			
	}













	private void RetrieveStatBaseStatPoints(){


		primaryStatPointsToAllocate = GameInformation.BasePlayer.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = GameInformation.BasePlayer.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = GameInformation.BasePlayer.SecondaryStatPointsToAllocate;


		// Initiation des stats allouées
		primaryPointsToAllocate[0] = GameInformation.BasePlayer.Strength;
		primaryPointsToAllocate[1] = GameInformation.BasePlayer.Speed;
		primaryPointsToAllocate[2] = GameInformation.BasePlayer.Dexterity;
		primaryPointsToAllocate[3] = GameInformation.BasePlayer.Embodiment;
		primaryPointsToAllocate[4] = GameInformation.BasePlayer.Reflex;
		primaryPointsToAllocate[5] = GameInformation.BasePlayer.Resilience;
		primaryPointsToAllocate[6] = GameInformation.BasePlayer.Knowledge;
		primaryPointsToAllocate[7] = GameInformation.BasePlayer.Elocution;
		primaryPointsToAllocate[8] = GameInformation.BasePlayer.Intellect;
		primaryPointsToAllocate[9] = GameInformation.BasePlayer.Influence;
		primaryPointsToAllocate[10] = GameInformation.BasePlayer.Focus;
		primaryPointsToAllocate[11] = GameInformation.BasePlayer.Mockery;
		primaryPointsToAllocate[12] = GameInformation.BasePlayer.Malevolent;
		primaryPointsToAllocate[13] = GameInformation.BasePlayer.Unmerciful;

		heroicPointsToAllocate[0] = GameInformation.BasePlayer.Rage;
		heroicPointsToAllocate[1] = GameInformation.BasePlayer.Phase;

		secondaryPointsToAllocate[0] = GameInformation.BasePlayer.Momentum;
		secondaryPointsToAllocate[1] = GameInformation.BasePlayer.Balance;
		secondaryPointsToAllocate[2] = GameInformation.BasePlayer.Luck;
		secondaryPointsToAllocate[3] = GameInformation.BasePlayer.Perception;
		secondaryPointsToAllocate[4] = GameInformation.BasePlayer.Judgement;
		secondaryPointsToAllocate[5] = GameInformation.BasePlayer.Chaos;


		for (int i=0; i<14; i++) 	{ primaryPointsMinimum[i]=		primaryPointsToAllocate[i];		}
		for (int i=0; i<2; i++) 	{ heroicPointsMinimum[i]=		heroicPointsToAllocate[i]-1;	}
		for (int i=0; i<6; i++) 	{ secondaryPointsMinimum[i]=	secondaryPointsToAllocate[i]-1;	}


		}
	



	public void StoreStatAllocation(){
		
		GameInformation.BasePlayer.PrimaryStatPointsToAllocate=		primaryStatPointsToAllocate;
		GameInformation.BasePlayer.HeroicStatPointsToAllocate=		heroicStatPointsToAllocate;
		GameInformation.BasePlayer.SecondaryStatPointsToAllocate=	secondaryStatPointsToAllocate;

		GameInformation.BasePlayer.Strength = 		primaryPointsToAllocate[0];
		GameInformation.BasePlayer.Speed = 			primaryPointsToAllocate[1];
		GameInformation.BasePlayer.Dexterity = 		primaryPointsToAllocate[2];
		GameInformation.BasePlayer.Embodiment = 	primaryPointsToAllocate[3];
		GameInformation.BasePlayer.Reflex = 		primaryPointsToAllocate[4];
		GameInformation.BasePlayer.Resilience = 	primaryPointsToAllocate[5];
		GameInformation.BasePlayer.Knowledge = 		primaryPointsToAllocate[6];
		GameInformation.BasePlayer.Elocution = 		primaryPointsToAllocate[7];
		GameInformation.BasePlayer.Intellect = 		primaryPointsToAllocate[8];
		GameInformation.BasePlayer.Influence =		primaryPointsToAllocate[9];
		GameInformation.BasePlayer.Focus =			primaryPointsToAllocate[10];
		GameInformation.BasePlayer.Mockery = 		primaryPointsToAllocate[11];
		GameInformation.BasePlayer.Malevolent = 	primaryPointsToAllocate[12];
		GameInformation.BasePlayer.Unmerciful = 	primaryPointsToAllocate[13];

		GameInformation.BasePlayer.Rage = 			heroicPointsToAllocate[0];
		GameInformation.BasePlayer.Phase = 			heroicPointsToAllocate[1];

		GameInformation.BasePlayer.Momentum = 		secondaryPointsToAllocate[0];
		GameInformation.BasePlayer.Balance = 		secondaryPointsToAllocate[1];
		GameInformation.BasePlayer.Luck = 			secondaryPointsToAllocate[2];
		GameInformation.BasePlayer.Perception = 	secondaryPointsToAllocate[3];
		GameInformation.BasePlayer.Judgement = 		secondaryPointsToAllocate[4];
		GameInformation.BasePlayer.Chaos = 			secondaryPointsToAllocate[5];
	}








	}


using UnityEngine;
using System.Collections;

public class StatAllocation{



	public int[] primaryPointsToAllocate = new int[14];
	public int[] heroicPointsToAllocate = new int[2];
	public int[] secondaryPointsToAllocate = new int[6];

	public int[] primaryPointsMinimum = new int[14];
	public int[] heroicPointsMinimum = new int[2];
	public int[] secondaryPointsMinimum = new int[6];

	private bool[] primaryStatSelections = new bool[14];
	private bool[] heroicStatSelections = new bool[2];
	private bool[] secondaryStatSelections = new bool[6];


	public int primaryStatPointsToAllocate;
	public int heroicStatPointsToAllocate;
	public int secondaryStatPointsToAllocate;

	public bool didRunOnce=false;





	public void DisplayStatAllocationModule(){

		if (!didRunOnce) {
			RetrieveStatBaseStatPoints ();
			didRunOnce=true;}

		DisplayStatsStatus ();
		CalculateDisplayPlusMinusButtons ();

	}


	private void MoveStat(bool Move,int Stat_ID){

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
	}









	
	public void CalculateDisplayPlusMinusButtons() {
		
		//Display the "Plus" buttons
		if (primaryStatPointsToAllocate > 0) {	
			for (int i=0; i<14 ; i++)	{ 
				if(StatAllocationButtons.PrimaryPlus [i].enabled==false) {StatAllocationButtons.PrimaryPlus [i].gameObject.SetActive(true);}}
		} 
		else {			
			for (int i=0; i<14 ; i++)	{ 
				if(StatAllocationButtons.PrimaryPlus [i].enabled==true) {StatAllocationButtons.PrimaryPlus [i].gameObject.SetActive(false);}}
		} 
		
		
		if (heroicStatPointsToAllocate > 0) {
			for (int i=0; i<2 ; i++)	{ 
				if(StatAllocationButtons.HeroicPlus [i].enabled==false) {StatAllocationButtons.HeroicPlus [i].gameObject.SetActive(true);}}
		} 
		else {			
			for (int i=0; i<2 ; i++)	{ 
				if(StatAllocationButtons.HeroicPlus [i].enabled==true) {StatAllocationButtons.HeroicPlus [i].gameObject.SetActive(false);}}
		} 
		
		
		if (secondaryStatPointsToAllocate > 0) {	
			for (int i=0; i<5 ; i++)	{ 
				if(StatAllocationButtons.SecondaryPlus [i].enabled==false) {StatAllocationButtons.SecondaryPlus [i].gameObject.SetActive(true);}}
		} 
		else {		
			for (int i=0; i<5 ; i++)	{ 
				if(StatAllocationButtons.SecondaryPlus [i].enabled==true) {StatAllocationButtons.SecondaryPlus [i].gameObject.SetActive(false);}}
		} 
		
		
		
		//Display the "Minus" buttons
		
		for (int i=0; i<14 ; i++) {
			if (primaryPointsToAllocate[i]-primaryPointsMinimum[i]>0) {
				if(StatAllocationButtons.PrimaryMinus [i].enabled==false) {StatAllocationButtons.PrimaryMinus [i].gameObject.SetActive(true);}
			} else {
				if(StatAllocationButtons.PrimaryMinus [i].enabled==true) {StatAllocationButtons.PrimaryMinus [i].gameObject.SetActive(false);}
			}
		}
		
		
		for (int i=0; i<2 ; i++) {
			if (heroicPointsToAllocate[i]-heroicPointsMinimum[i]>0) {
				if(StatAllocationButtons.HeroicMinus [i].enabled==false) {StatAllocationButtons.HeroicMinus [i].gameObject.SetActive(true);}
			} else {
				if(StatAllocationButtons.HeroicMinus [i].enabled==true) {StatAllocationButtons.HeroicMinus [i].gameObject.SetActive(false);}
			}
		}
		
		
		for (int i=0; i<5 ; i++) {
			if (secondaryPointsToAllocate[i]-secondaryPointsMinimum[i]>0) {
				if(StatAllocationButtons.PrimaryMinus [i].enabled==false) {StatAllocationButtons.PrimaryMinus [i].gameObject.SetActive(true);}
			} else {
				if(StatAllocationButtons.PrimaryMinus [i].enabled==true) {StatAllocationButtons.PrimaryMinus [i].gameObject.SetActive(false);}
			}
		}
	}






	public void DisplayStatsStatus(){

			for (int i=0; i<14; i++) {
			StatAllocationButtons.PrimaryNumbers [i].text = ""+primaryPointsToAllocate [i];
			}
			for (int i=0; i<2; i++) {
			StatAllocationButtons.HeroicNumbers [i].text = ""+heroicPointsToAllocate [i];
			}
			for (int i=0; i<5; i++) {
			StatAllocationButtons.SecondaryNumbers [i].text = ""+secondaryPointsToAllocate [i];
			}
			
		StatAllocationButtons.PointsToAlloc [0].text = "" + primaryStatPointsToAllocate;
		StatAllocationButtons.PointsToAlloc [1].text = "" + heroicStatPointsToAllocate;
		StatAllocationButtons.PointsToAlloc [2].text = "" + secondaryStatPointsToAllocate;

			
	}













	private void RetrieveStatBaseStatPoints(){


		primaryStatPointsToAllocate = GameInformation.basePlayer.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = GameInformation.basePlayer.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = GameInformation.basePlayer.SecondaryStatPointsToAllocate;


		// Initiation des stats allouées
		primaryPointsToAllocate[0] = GameInformation.basePlayer.Strength;
		primaryPointsMinimum[0] = GameInformation.basePlayer.Strength;
		primaryPointsToAllocate[1] = GameInformation.basePlayer.Speed;
		primaryPointsMinimum[1] = GameInformation.basePlayer.Speed;
		primaryPointsToAllocate[2] = GameInformation.basePlayer.Dexterity;
		primaryPointsMinimum[2] = GameInformation.basePlayer.Dexterity;
		primaryPointsToAllocate[3] = GameInformation.basePlayer.Embodiment;
		primaryPointsMinimum[3] = GameInformation.basePlayer.Embodiment;
		primaryPointsToAllocate[4] = GameInformation.basePlayer.Reflex;
		primaryPointsMinimum[4] = GameInformation.basePlayer.Reflex;
		primaryPointsToAllocate[5] = GameInformation.basePlayer.Resilience;
		primaryPointsMinimum[5] = GameInformation.basePlayer.Resilience;
		primaryPointsToAllocate[6] = GameInformation.basePlayer.Knowledge;
		primaryPointsMinimum[6] = GameInformation.basePlayer.Knowledge;
		primaryPointsToAllocate[7] = GameInformation.basePlayer.Elocution;
		primaryPointsMinimum[7] = GameInformation.basePlayer.Elocution;
		primaryPointsToAllocate[8] = GameInformation.basePlayer.Intellect;
		primaryPointsMinimum[8] = GameInformation.basePlayer.Intellect;
		primaryPointsToAllocate[9] = GameInformation.basePlayer.Influence;
		primaryPointsMinimum[9] = GameInformation.basePlayer.Influence;
		primaryPointsToAllocate[10] = GameInformation.basePlayer.Focus;
		primaryPointsMinimum[10] = GameInformation.basePlayer.Focus;
		primaryPointsToAllocate[11] = GameInformation.basePlayer.Mockery;
		primaryPointsMinimum[11] = GameInformation.basePlayer.Mockery;
		primaryPointsToAllocate[12] = GameInformation.basePlayer.Malevolant;
		primaryPointsMinimum[12] = GameInformation.basePlayer.Malevolant;
		primaryPointsToAllocate[13] = GameInformation.basePlayer.Unmerciful;
		primaryPointsMinimum[13] = GameInformation.basePlayer.Unmerciful;

		heroicPointsToAllocate[0] = GameInformation.basePlayer.Rage;
		heroicPointsMinimum[0] = GameInformation.basePlayer.Rage-1;
		heroicPointsToAllocate[1] = GameInformation.basePlayer.Phase;
		heroicPointsMinimum[1] = GameInformation.basePlayer.Phase-1;

		secondaryPointsToAllocate[0] = GameInformation.basePlayer.Momentum;
		secondaryPointsMinimum[0] = GameInformation.basePlayer.Momentum-1;
		secondaryPointsToAllocate[1] = GameInformation.basePlayer.Balance;
		secondaryPointsMinimum[1] = GameInformation.basePlayer.Balance-1;
		secondaryPointsToAllocate[2] = GameInformation.basePlayer.Luck;
		secondaryPointsMinimum[2] = GameInformation.basePlayer.Luck-1;
		secondaryPointsToAllocate[3] = GameInformation.basePlayer.Perception;
		secondaryPointsMinimum[3] = GameInformation.basePlayer.Perception-1;
		secondaryPointsToAllocate[4] = GameInformation.basePlayer.Judgement;
		secondaryPointsMinimum[4] = GameInformation.basePlayer.Judgement-1;
		secondaryPointsToAllocate[5] = GameInformation.basePlayer.Chaos;
		secondaryPointsMinimum[5] = GameInformation.basePlayer.Chaos-1;

		}
	



	public void StoreStatAllocation(){
		
		GameInformation.basePlayer.PrimaryStatPointsToAllocate=		primaryStatPointsToAllocate;
		GameInformation.basePlayer.HeroicStatPointsToAllocate=		heroicStatPointsToAllocate;
		GameInformation.basePlayer.SecondaryStatPointsToAllocate=	secondaryStatPointsToAllocate;



		GameInformation.basePlayer.Strength = 		primaryPointsToAllocate[0];
		GameInformation.basePlayer.Speed = 			primaryPointsToAllocate[1];
		GameInformation.basePlayer.Dexterity = 		primaryPointsToAllocate[2];
		GameInformation.basePlayer.Embodiment = 	primaryPointsToAllocate[3];
		GameInformation.basePlayer.Reflex = 		primaryPointsToAllocate[4];
		GameInformation.basePlayer.Resilience = 	primaryPointsToAllocate[5];
		GameInformation.basePlayer.Knowledge = 		primaryPointsToAllocate[6];
		GameInformation.basePlayer.Elocution = 		primaryPointsToAllocate[7];
		GameInformation.basePlayer.Intellect = 		primaryPointsToAllocate[8];
		GameInformation.basePlayer.Influence =		primaryPointsToAllocate[9];
		GameInformation.basePlayer.Focus =			primaryPointsToAllocate[10];
		GameInformation.basePlayer.Mockery = 		primaryPointsToAllocate[11];
		GameInformation.basePlayer.Malevolant = 	primaryPointsToAllocate[12];
		GameInformation.basePlayer.Unmerciful = 	primaryPointsToAllocate[13];

		GameInformation.basePlayer.Rage = 			heroicPointsToAllocate[0];
		GameInformation.basePlayer.Phase = 			heroicPointsToAllocate[1];

		GameInformation.basePlayer.Momentum = 		secondaryPointsToAllocate[0];
		GameInformation.basePlayer.Balance = 		secondaryPointsToAllocate[1];
		GameInformation.basePlayer.Luck = 			secondaryPointsToAllocate[2];
		GameInformation.basePlayer.Perception = 	secondaryPointsToAllocate[3];
		GameInformation.basePlayer.Judgement = 		secondaryPointsToAllocate[4];
		GameInformation.basePlayer.Chaos = 			secondaryPointsToAllocate[5];
	}








	}


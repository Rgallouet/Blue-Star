using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class StatAllocation { 

    public StatAllocationButtons statAllocationButtons;

    // Stat Data
    public int[] InitialStat = new int[22];
	public int[] InitialStatMinimum = new int[22];
    public int[] StatModifier = new int[22];

    // Stat button controlers
    private bool[] TrackingPlus = new bool[22];
    private bool[] TrackingMinus = new bool[22];

    // Modifier Allocation
    public int primaryStatPointsToAllocate;
	public int heroicStatPointsToAllocate;
	public int secondaryStatPointsToAllocate;

	public bool readyForNext = false;





	public void DisplayStatAllocationModule(bool Reset){

		if (Reset) InitialiseStats();
        
		InitialisePlusMinusButtons ();
		CalculateDisplayPlusMinusButtons ();
		RefreshDisplayedStatsNumbers ();
	}

	public void MoveStat(bool Move,int Stat_ID){

		switch (Move) {
		case true:
                ++StatModifier[Stat_ID];
            if (Stat_ID < 14) {
				--primaryStatPointsToAllocate;
			} else if (Stat_ID < 16) {
				--heroicStatPointsToAllocate;
			} else {
				--secondaryStatPointsToAllocate;
			}
			break;

		case false:
                --StatModifier[Stat_ID];
            if (Stat_ID < 14) {
				++primaryStatPointsToAllocate;
			} else if (Stat_ID < 16) {
				++heroicStatPointsToAllocate;
			} else {
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
	
		for (int i=0; i<22 ; i++) {
			TrackingMinus[i]=true; 
			statAllocationButtons.StatMinus [i].interactable=true; 
			statAllocationButtons.StatMinus [i].GetComponentInChildren<Text>().text="-"; 
			
			TrackingPlus[i]=true;
			statAllocationButtons.StatPlus [i].interactable=true; 
			statAllocationButtons.StatPlus[i].GetComponentInChildren<Text>().text="+"; 		
		}

	}
	
	public void CalculateDisplayPlusMinusButtons() {

        int[] CanIAllocate = new int[22];

        for (int j = 0; j < 14; j++) { CanIAllocate[j] = primaryStatPointsToAllocate; }
        for (int j = 14; j < 16; j++) { CanIAllocate[j] = heroicStatPointsToAllocate; }
        for (int j = 16; j < 22; j++) { CanIAllocate[j] = secondaryStatPointsToAllocate; }


        for (int i = 0; i < 22; i++)
        {
            
            //Restore the "Plus" buttons
            if (CanIAllocate[i] > 0 && TrackingPlus[i] == false) {
                statAllocationButtons.StatPlus[i].interactable = true;
                statAllocationButtons.StatPlus[i].GetComponentInChildren<Text>().text = "+";
                TrackingPlus[i] = true; }

            //Remove the "Plus" buttons
            if (CanIAllocate[i] == 0 && TrackingPlus[i] == true) {
                statAllocationButtons.StatPlus[i].GetComponentInChildren<Text>().text = "";
                statAllocationButtons.StatPlus[i].interactable = false;
                TrackingPlus[i] = false; }

            //Restore the "Minus" buttons
			if ((InitialStat[i] + StatModifier[i] > InitialStatMinimum[i]) && TrackingMinus[i] == false) {
				statAllocationButtons.StatMinus[i].interactable=true; 
				statAllocationButtons.StatMinus[i].GetComponentInChildren<Text>().text="-";
                TrackingMinus[i]=true;}

            //Remove the "Minus" buttons
            if ((InitialStat[i] + StatModifier[i] == InitialStatMinimum[i]) && TrackingMinus[i] == true) { 
					statAllocationButtons.StatMinus[i].GetComponentInChildren<Text>().text=""; 
					statAllocationButtons.StatMinus[i].interactable=false;
                    TrackingMinus[i]=false;}
		}
		
	}

	public void RefreshDisplayedStatsNumbers(){

			for (int i=0; i<22; i++)    {statAllocationButtons.Stat[i].text = "" + (InitialStat[i]+StatModifier[i]); }
			
		statAllocationButtons.PointsToAlloc [0].text = "" + primaryStatPointsToAllocate;
		statAllocationButtons.PointsToAlloc [1].text = "" + heroicStatPointsToAllocate;
		statAllocationButtons.PointsToAlloc [2].text = "" + secondaryStatPointsToAllocate;

			
	}

	public void InitialiseStats(){


		primaryStatPointsToAllocate = GameInformation.BasePlayer.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = GameInformation.BasePlayer.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = GameInformation.BasePlayer.SecondaryStatPointsToAllocate;
        
		// Initiation des stats allouées
		InitialStat[0] = GameInformation.BasePlayer.Strength;
        InitialStat[1] = GameInformation.BasePlayer.Speed;
        InitialStat[2] = GameInformation.BasePlayer.Dexterity;
        InitialStat[3] = GameInformation.BasePlayer.Embodiment;
        InitialStat[4] = GameInformation.BasePlayer.Reflex;
        InitialStat[5] = GameInformation.BasePlayer.Resilience;
        InitialStat[6] = GameInformation.BasePlayer.Knowledge;
        InitialStat[7] = GameInformation.BasePlayer.Elocution;
        InitialStat[8] = GameInformation.BasePlayer.Intellect;
        InitialStat[9] = GameInformation.BasePlayer.Influence;
        InitialStat[10] = GameInformation.BasePlayer.Focus;
        InitialStat[11] = GameInformation.BasePlayer.Mockery;
        InitialStat[12] = GameInformation.BasePlayer.Malevolent;
        InitialStat[13] = GameInformation.BasePlayer.Unmerciful;
        InitialStat[14] = GameInformation.BasePlayer.Rage;
        InitialStat[15] = GameInformation.BasePlayer.Phase;
        InitialStat[16] = GameInformation.BasePlayer.Momentum;
        InitialStat[17] = GameInformation.BasePlayer.Balance;
        InitialStat[18] = GameInformation.BasePlayer.Chaos;
        InitialStat[19] = GameInformation.BasePlayer.Perception;
        InitialStat[20] = GameInformation.BasePlayer.Judgement;
        InitialStat[21] = GameInformation.BasePlayer.Luck;


        // Setting minimum of stats
        for (int i=0; i<14; i++) 	{ InitialStatMinimum[i]= InitialStat[i];	}
		for (int i=14; i<16; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-1;	}
		for (int i=16; i<22; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-2;	}

        // Setting the modifier vector
        for (int i=0; i<22; i++)    { StatModifier[i] = 0; }


    }

    public void StoreStatAllocation(){
		
		GameInformation.BasePlayer.PrimaryStatPointsToAllocate=		primaryStatPointsToAllocate;
		GameInformation.BasePlayer.HeroicStatPointsToAllocate=		heroicStatPointsToAllocate;
		GameInformation.BasePlayer.SecondaryStatPointsToAllocate=	secondaryStatPointsToAllocate;

		GameInformation.BasePlayer.Strength =   InitialStat[0] + StatModifier[0];
		GameInformation.BasePlayer.Speed =      InitialStat[1] + StatModifier[1];
        GameInformation.BasePlayer.Dexterity =  InitialStat[2] + StatModifier[2];
        GameInformation.BasePlayer.Embodiment = InitialStat[3] + StatModifier[3];
        GameInformation.BasePlayer.Reflex =     InitialStat[4] + StatModifier[4];
        GameInformation.BasePlayer.Resilience = InitialStat[5] + StatModifier[5];
        GameInformation.BasePlayer.Knowledge =  InitialStat[6] + StatModifier[6];
        GameInformation.BasePlayer.Elocution =  InitialStat[7] + StatModifier[7];
        GameInformation.BasePlayer.Intellect =  InitialStat[8] + StatModifier[8];
        GameInformation.BasePlayer.Influence =  InitialStat[9] + StatModifier[9];
        GameInformation.BasePlayer.Focus =      InitialStat[10] + StatModifier[10];
        GameInformation.BasePlayer.Mockery =    InitialStat[11] + StatModifier[11];
        GameInformation.BasePlayer.Malevolent = InitialStat[12] + StatModifier[12];
        GameInformation.BasePlayer.Unmerciful = InitialStat[13] + StatModifier[13];
        GameInformation.BasePlayer.Rage =       InitialStat[14] + StatModifier[14];
        GameInformation.BasePlayer.Phase =      InitialStat[15] + StatModifier[15];
        GameInformation.BasePlayer.Momentum =   InitialStat[16] + StatModifier[16];
        GameInformation.BasePlayer.Balance =    InitialStat[17] + StatModifier[17];
        GameInformation.BasePlayer.Chaos =      InitialStat[18] + StatModifier[18];
        GameInformation.BasePlayer.Perception = InitialStat[19] + StatModifier[19];
        GameInformation.BasePlayer.Judgement =  InitialStat[20] + StatModifier[20];
        GameInformation.BasePlayer.Luck =       InitialStat[21] + StatModifier[21];
    }

	}


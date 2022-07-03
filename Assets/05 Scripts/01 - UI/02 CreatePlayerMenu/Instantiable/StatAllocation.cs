using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// changed to :monobehaviour

public class StatAllocation { 

    public StatAllocationButtons statAllocationButtons;
    public StatModifier AllocatedStatsModifier = new StatModifier();


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





	public void DisplayStatAllocationModule(bool Reset, BaseCharacter newPlayer){

		if (Reset) InitialiseStats(newPlayer);
        
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

        UpdateStatsinPlayer();

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

	public void InitialiseStats(BaseCharacter newPlayer){


		primaryStatPointsToAllocate = 5;
		heroicStatPointsToAllocate = 0;
		secondaryStatPointsToAllocate = 5;
        
		// Initiation des stats allouées
		InitialStat[0] = newPlayer.HistoryChoicesModifier.Strength;
        InitialStat[1] = newPlayer.HistoryChoicesModifier.Speed;
        InitialStat[2] = newPlayer.HistoryChoicesModifier.Dexterity;
        InitialStat[3] = newPlayer.HistoryChoicesModifier.Embodiment;
        InitialStat[4] = newPlayer.HistoryChoicesModifier.Reflex;
        InitialStat[5] = newPlayer.HistoryChoicesModifier.Resilience;
        InitialStat[6] = newPlayer.HistoryChoicesModifier.Knowledge;
        InitialStat[7] = newPlayer.HistoryChoicesModifier.Elocution;
        InitialStat[8] = newPlayer.HistoryChoicesModifier.Intellect;
        InitialStat[9] = newPlayer.HistoryChoicesModifier.Influence;
        InitialStat[10] = newPlayer.HistoryChoicesModifier.Focus;
        InitialStat[11] = newPlayer.HistoryChoicesModifier.Mockery;
        InitialStat[12] = newPlayer.HistoryChoicesModifier.Malevolent;
        InitialStat[13] = newPlayer.HistoryChoicesModifier.Unmerciful;
        InitialStat[14] = newPlayer.HistoryChoicesModifier.Rage;
        InitialStat[15] = newPlayer.HistoryChoicesModifier.Phase;
        InitialStat[16] = newPlayer.HistoryChoicesModifier.Momentum;
        InitialStat[17] = newPlayer.HistoryChoicesModifier.Balance;
        InitialStat[18] = newPlayer.HistoryChoicesModifier.Chaos;
        InitialStat[19] = newPlayer.HistoryChoicesModifier.Perception;
        InitialStat[20] = newPlayer.HistoryChoicesModifier.Judgement;
        InitialStat[21] = newPlayer.HistoryChoicesModifier.Luck;


        // Setting minimum of stats
        for (int i=0; i<14; i++) 	{ InitialStatMinimum[i]= InitialStat[i];	}
		for (int i=14; i<16; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-1;	}
		for (int i=16; i<22; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-2;	}

        // Setting the modifier vector
        for (int i=0; i<22; i++)    { StatModifier[i] = 0; }


    }


    void UpdateStatsinPlayer() {
        AllocatedStatsModifier.Strength =     StatModifier[0];
        AllocatedStatsModifier.Speed =        StatModifier[1];
        AllocatedStatsModifier.Dexterity =    StatModifier[2];
        AllocatedStatsModifier.Embodiment =   StatModifier[3];
        AllocatedStatsModifier.Reflex =       StatModifier[4];
        AllocatedStatsModifier.Resilience =   StatModifier[5];
        AllocatedStatsModifier.Knowledge =    StatModifier[6];
        AllocatedStatsModifier.Elocution =    StatModifier[7];
        AllocatedStatsModifier.Intellect =    StatModifier[8];
        AllocatedStatsModifier.Influence =    StatModifier[9];
        AllocatedStatsModifier.Focus =        StatModifier[10];
        AllocatedStatsModifier.Mockery =      StatModifier[11];
        AllocatedStatsModifier.Malevolent =   StatModifier[12];
        AllocatedStatsModifier.Unmerciful =   StatModifier[13];
        AllocatedStatsModifier.Rage =         StatModifier[14];
        AllocatedStatsModifier.Phase =        StatModifier[15];
        AllocatedStatsModifier.Momentum =     StatModifier[16];
        AllocatedStatsModifier.Balance =      StatModifier[17];
        AllocatedStatsModifier.Chaos =        StatModifier[18];
        AllocatedStatsModifier.Perception =   StatModifier[19];
        AllocatedStatsModifier.Judgement =    StatModifier[20];
        AllocatedStatsModifier.Luck =         StatModifier[21];



    }



	}


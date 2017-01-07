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





	public void DisplayStatAllocationModule(bool Reset, BasePlayer newPlayer){

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

	public void InitialiseStats(BasePlayer newPlayer){


		primaryStatPointsToAllocate = newPlayer.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = newPlayer.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = newPlayer.SecondaryStatPointsToAllocate;
        
		// Initiation des stats allouées
		InitialStat[0] = newPlayer.Strength;
        InitialStat[1] = newPlayer.Speed;
        InitialStat[2] = newPlayer.Dexterity;
        InitialStat[3] = newPlayer.Embodiment;
        InitialStat[4] = newPlayer.Reflex;
        InitialStat[5] = newPlayer.Resilience;
        InitialStat[6] = newPlayer.Knowledge;
        InitialStat[7] = newPlayer.Elocution;
        InitialStat[8] = newPlayer.Intellect;
        InitialStat[9] = newPlayer.Influence;
        InitialStat[10] = newPlayer.Focus;
        InitialStat[11] = newPlayer.Mockery;
        InitialStat[12] = newPlayer.Malevolent;
        InitialStat[13] = newPlayer.Unmerciful;
        InitialStat[14] = newPlayer.Rage;
        InitialStat[15] = newPlayer.Phase;
        InitialStat[16] = newPlayer.Momentum;
        InitialStat[17] = newPlayer.Balance;
        InitialStat[18] = newPlayer.Chaos;
        InitialStat[19] = newPlayer.Perception;
        InitialStat[20] = newPlayer.Judgement;
        InitialStat[21] = newPlayer.Luck;


        // Setting minimum of stats
        for (int i=0; i<14; i++) 	{ InitialStatMinimum[i]= InitialStat[i];	}
		for (int i=14; i<16; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-1;	}
		for (int i=16; i<22; i++) 	{ InitialStatMinimum[i]= InitialStat[i]-2;	}

        // Setting the modifier vector
        for (int i=0; i<22; i++)    { StatModifier[i] = 0; }


    }
    
	}


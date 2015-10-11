using UnityEngine;
using System.Collections;

public class HistoryAllocation {

	private BasePlayer newPlayer;


	public void ChooseClass(int classSelection) {

		CreateNewPlayer(classSelection);
		StoreNewPlayerInfo();
	}

	private void CreateNewPlayer( int classSelection){

		BasePlayer newPlayer = new BasePlayer ();

		if (classSelection == 0) {newPlayer.PlayerClass = new ButcherClass ();}
		if (classSelection == 1) {newPlayer.PlayerClass = new LordClass ();}

		// Init level
		newPlayer.PlayerLevel=1;
		
		newPlayer.TotalXP=0;
		newPlayer.CurrentXP=0;
		newPlayer.RequiredXP=100;
		newPlayer.HumanCrap = 0;
		
		newPlayer.PrimaryStatPointsToAllocate=5;
		newPlayer.HeroicStatPointsToAllocate=0;
		newPlayer.SecondaryStatPointsToAllocate=5;
		
		//Embodiment are always 100, same for action points
		
		int Base_prim = 100;
		int Base_heroic = 10;
		int Base_sec = 100;
		
	
		newPlayer.Embodiment=Base_prim+newPlayer.PlayerClass.Embodiment; 			
		newPlayer.Strength = Base_prim+newPlayer.PlayerClass.Strength;
		newPlayer.Speed = Base_prim+newPlayer.PlayerClass.Speed;
		newPlayer.Dexterity = Base_prim+newPlayer.PlayerClass.Dexterity;
		newPlayer.Reflex = Base_prim+newPlayer.PlayerClass.Reflex;
		newPlayer.Resilience = Base_prim+newPlayer.PlayerClass.Resilience;

		newPlayer.Influence=Base_prim+newPlayer.PlayerClass.Influence;			
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

		newPlayer.CurrentEmbodiment = newPlayer.Embodiment;
		newPlayer.CurrentInfluence = newPlayer.Influence;



		GameInformation.basePlayer.TotalXP = newPlayer.TotalXP;
		GameInformation.basePlayer.CurrentXP = newPlayer.CurrentXP;
		GameInformation.basePlayer.RequiredXP = newPlayer.RequiredXP;

		GameInformation.basePlayer.PrimaryStatPointsToAllocate = newPlayer.PrimaryStatPointsToAllocate;
		GameInformation.basePlayer.HeroicStatPointsToAllocate = newPlayer.HeroicStatPointsToAllocate;
		GameInformation.basePlayer.SecondaryStatPointsToAllocate = newPlayer.SecondaryStatPointsToAllocate;
		
		GameInformation.basePlayer.HumanCrap = newPlayer.HumanCrap;
		GameInformation.basePlayer.CurrentEmbodiment = newPlayer.CurrentEmbodiment;
		GameInformation.basePlayer.CurrentInfluence = newPlayer.CurrentInfluence;
		GameInformation.basePlayer.Embodiment = newPlayer.Embodiment;
		GameInformation.basePlayer.Influence = newPlayer.Influence;
		
		
		GameInformation.basePlayer.Strength = newPlayer.Strength;
		GameInformation.basePlayer.Speed = newPlayer.Speed;
		GameInformation.basePlayer.Dexterity = newPlayer.Dexterity;
		GameInformation.basePlayer.Reflex = newPlayer.Reflex;
		GameInformation.basePlayer.Resilience = newPlayer.Resilience;
		GameInformation.basePlayer.Knowledge = newPlayer.Knowledge;
		GameInformation.basePlayer.Elocution = newPlayer.Elocution;
		GameInformation.basePlayer.Intellect = newPlayer.Intellect;
		GameInformation.basePlayer.Focus = newPlayer.Focus;
		GameInformation.basePlayer.Mockery = newPlayer.Mockery;
		GameInformation.basePlayer.Malevolant = newPlayer.Malevolant;
		GameInformation.basePlayer.Unmerciful = newPlayer.Unmerciful;
		GameInformation.basePlayer.Rage = newPlayer.Rage;
		GameInformation.basePlayer.Phase = newPlayer.Phase;
		GameInformation.basePlayer.Momentum = newPlayer.Momentum;
		GameInformation.basePlayer.Balance = newPlayer.Balance;
		GameInformation.basePlayer.Luck = newPlayer.Luck;
		GameInformation.basePlayer.Perception = newPlayer.Perception;
		GameInformation.basePlayer.Judgement = newPlayer.Judgement;
		GameInformation.basePlayer.Chaos = newPlayer.Chaos;


		
	}
	
	
	private void StoreNewPlayerInfo(){
		

		
		
		
	}
	
	







}

using UnityEngine;
using System.Collections;

public class HistoryAllocation {




	private BasePlayer newPlayer;



	public void CreateNewPlayer(int hellCircleSelection,int allegianceSelection,int genusSelection,int speciesSelection,int classSelection,int impSelection,int originSelection,int temperSelection,int astroSelection,int affinitySelection){

		BasePlayer newPlayer = new BasePlayer ();




		// Defining the history

		newPlayer.PlayerHellCircle = new DefineHellCircle(hellCircleSelection);
		newPlayer.PlayerAllegiance = new DefineAllegiance(allegianceSelection);
		newPlayer.PlayerGenus = new DefineGenus(genusSelection);
		newPlayer.PlayerSpecies = new DefineSpecies(speciesSelection+((genusSelection-1)*3));
		newPlayer.PlayerJob = new DefineJob(classSelection);
		newPlayer.PlayerImp = new DefineImp(impSelection);
		newPlayer.PlayerOrigin = new DefineOrigin(originSelection);
		newPlayer.PlayerDeathState = new DefineDeathState(temperSelection);
		newPlayer.PlayerAstro = new DefineAstro(astroSelection);
		newPlayer.PlayerAffi = new DefineAffi(affinitySelection);



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
		
	
		// Calculate Base stats

		newPlayer.Embodiment	= Base_prim+newPlayer.PlayerHellCircle.Embodiment+newPlayer.PlayerAllegiance.Embodiment+newPlayer.PlayerGenus.Embodiment+newPlayer.PlayerSpecies.Embodiment+newPlayer.PlayerJob.Embodiment+newPlayer.PlayerImp.Embodiment+newPlayer.PlayerOrigin.Embodiment+newPlayer.PlayerDeathState.Embodiment+newPlayer.PlayerAstro.Embodiment+newPlayer.PlayerAffi.Embodiment; 			
		newPlayer.Strength 		= Base_prim+newPlayer.PlayerHellCircle.Strength+newPlayer.PlayerAllegiance.Strength+newPlayer.PlayerGenus.Strength+newPlayer.PlayerSpecies.Strength+newPlayer.PlayerJob.Strength+newPlayer.PlayerImp.Strength+newPlayer.PlayerOrigin.Strength+newPlayer.PlayerDeathState.Strength+newPlayer.PlayerAstro.Strength+newPlayer.PlayerAffi.Strength;
		newPlayer.Speed 		= Base_prim+newPlayer.PlayerHellCircle.Speed+newPlayer.PlayerAllegiance.Speed+newPlayer.PlayerGenus.Speed+newPlayer.PlayerSpecies.Speed+newPlayer.PlayerJob.Speed+newPlayer.PlayerImp.Speed+newPlayer.PlayerOrigin.Speed+newPlayer.PlayerDeathState.Speed+newPlayer.PlayerAstro.Speed+newPlayer.PlayerAffi.Speed;
		newPlayer.Dexterity 	= Base_prim+newPlayer.PlayerHellCircle.Dexterity+newPlayer.PlayerAllegiance.Dexterity+newPlayer.PlayerGenus.Dexterity+newPlayer.PlayerSpecies.Dexterity+newPlayer.PlayerJob.Dexterity+newPlayer.PlayerImp.Dexterity+newPlayer.PlayerOrigin.Dexterity+newPlayer.PlayerDeathState.Dexterity+newPlayer.PlayerAstro.Dexterity+newPlayer.PlayerAffi.Dexterity;
		newPlayer.Reflex 		= Base_prim+newPlayer.PlayerHellCircle.Reflex+newPlayer.PlayerAllegiance.Reflex+newPlayer.PlayerGenus.Reflex+newPlayer.PlayerSpecies.Reflex+newPlayer.PlayerJob.Reflex+newPlayer.PlayerImp.Reflex+newPlayer.PlayerOrigin.Reflex+newPlayer.PlayerDeathState.Reflex+newPlayer.PlayerAstro.Reflex+newPlayer.PlayerAffi.Reflex;
		newPlayer.Resilience 	= Base_prim+newPlayer.PlayerHellCircle.Resilience+newPlayer.PlayerAllegiance.Resilience+newPlayer.PlayerGenus.Resilience+newPlayer.PlayerSpecies.Resilience+newPlayer.PlayerJob.Resilience+newPlayer.PlayerImp.Resilience+newPlayer.PlayerOrigin.Resilience+newPlayer.PlayerDeathState.Resilience+newPlayer.PlayerAstro.Resilience+newPlayer.PlayerAffi.Resilience;

		newPlayer.Influence		= Base_prim+newPlayer.PlayerHellCircle.Influence+newPlayer.PlayerAllegiance.Influence+newPlayer.PlayerGenus.Influence+newPlayer.PlayerSpecies.Influence+newPlayer.PlayerJob.Influence+newPlayer.PlayerImp.Influence+newPlayer.PlayerOrigin.Influence+newPlayer.PlayerDeathState.Influence+newPlayer.PlayerAstro.Influence+newPlayer.PlayerAffi.Influence;			
		newPlayer.Knowledge 	= Base_prim+newPlayer.PlayerHellCircle.Knowledge+newPlayer.PlayerAllegiance.Knowledge+newPlayer.PlayerGenus.Knowledge+newPlayer.PlayerSpecies.Knowledge+newPlayer.PlayerJob.Knowledge+newPlayer.PlayerImp.Knowledge+newPlayer.PlayerOrigin.Knowledge+newPlayer.PlayerDeathState.Knowledge+newPlayer.PlayerAstro.Knowledge+newPlayer.PlayerAffi.Knowledge;
		newPlayer.Elocution 	= Base_prim+newPlayer.PlayerHellCircle.Elocution+newPlayer.PlayerAllegiance.Elocution+newPlayer.PlayerGenus.Elocution+newPlayer.PlayerSpecies.Elocution+newPlayer.PlayerJob.Elocution+newPlayer.PlayerImp.Elocution+newPlayer.PlayerOrigin.Elocution+newPlayer.PlayerDeathState.Elocution+newPlayer.PlayerAstro.Elocution+newPlayer.PlayerAffi.Elocution;
		newPlayer.Intellect 	= Base_prim+newPlayer.PlayerHellCircle.Intellect+newPlayer.PlayerAllegiance.Intellect+newPlayer.PlayerGenus.Intellect+newPlayer.PlayerSpecies.Intellect+newPlayer.PlayerJob.Intellect+newPlayer.PlayerImp.Intellect+newPlayer.PlayerOrigin.Intellect+newPlayer.PlayerDeathState.Intellect+newPlayer.PlayerAstro.Intellect+newPlayer.PlayerAffi.Intellect;
		newPlayer.Focus 		= Base_prim+newPlayer.PlayerHellCircle.Focus+newPlayer.PlayerAllegiance.Focus+newPlayer.PlayerGenus.Focus+newPlayer.PlayerSpecies.Focus+newPlayer.PlayerJob.Focus+newPlayer.PlayerImp.Focus+newPlayer.PlayerOrigin.Focus+newPlayer.PlayerDeathState.Focus+newPlayer.PlayerAstro.Focus+newPlayer.PlayerAffi.Focus;
		newPlayer.Mockery 		= Base_prim+newPlayer.PlayerHellCircle.Mockery+newPlayer.PlayerAllegiance.Mockery+newPlayer.PlayerGenus.Mockery+newPlayer.PlayerSpecies.Mockery+newPlayer.PlayerJob.Mockery+newPlayer.PlayerImp.Mockery+newPlayer.PlayerOrigin.Mockery+newPlayer.PlayerDeathState.Mockery+newPlayer.PlayerAstro.Mockery+newPlayer.PlayerAffi.Mockery;

		newPlayer.Malevolent 	= Base_prim+newPlayer.PlayerHellCircle.Malevolent+newPlayer.PlayerAllegiance.Malevolent+newPlayer.PlayerGenus.Malevolent+newPlayer.PlayerSpecies.Malevolent+newPlayer.PlayerJob.Malevolent+newPlayer.PlayerImp.Malevolent+newPlayer.PlayerOrigin.Malevolent+newPlayer.PlayerDeathState.Malevolent+newPlayer.PlayerAstro.Malevolent+newPlayer.PlayerAffi.Malevolent;
		newPlayer.Unmerciful 	= Base_prim+newPlayer.PlayerHellCircle.Unmerciful+newPlayer.PlayerAllegiance.Unmerciful+newPlayer.PlayerGenus.Unmerciful+newPlayer.PlayerSpecies.Unmerciful+newPlayer.PlayerJob.Unmerciful+newPlayer.PlayerImp.Unmerciful+newPlayer.PlayerOrigin.Unmerciful+newPlayer.PlayerDeathState.Unmerciful+newPlayer.PlayerAstro.Unmerciful+newPlayer.PlayerAffi.Unmerciful;

		newPlayer.Rage 			= Base_heroic+newPlayer.PlayerHellCircle.Rage+newPlayer.PlayerAllegiance.Rage+newPlayer.PlayerGenus.Rage+newPlayer.PlayerSpecies.Rage+newPlayer.PlayerJob.Rage+newPlayer.PlayerImp.Rage+newPlayer.PlayerOrigin.Rage+newPlayer.PlayerDeathState.Rage+newPlayer.PlayerAstro.Rage+newPlayer.PlayerAffi.Rage;
		newPlayer.Phase 		= Base_heroic+newPlayer.PlayerHellCircle.Phase+newPlayer.PlayerAllegiance.Phase+newPlayer.PlayerGenus.Phase+newPlayer.PlayerSpecies.Phase+newPlayer.PlayerJob.Phase+newPlayer.PlayerImp.Phase+newPlayer.PlayerOrigin.Phase+newPlayer.PlayerDeathState.Phase+newPlayer.PlayerAstro.Phase+newPlayer.PlayerAffi.Phase;

		newPlayer.Momentum 		= Base_sec+newPlayer.PlayerHellCircle.Momentum+newPlayer.PlayerAllegiance.Momentum+newPlayer.PlayerGenus.Momentum+newPlayer.PlayerSpecies.Momentum+newPlayer.PlayerJob.Momentum+newPlayer.PlayerImp.Momentum+newPlayer.PlayerOrigin.Momentum+newPlayer.PlayerDeathState.Momentum+newPlayer.PlayerAstro.Momentum+newPlayer.PlayerAffi.Momentum;
		newPlayer.Balance 		= Base_sec+newPlayer.PlayerHellCircle.Balance+newPlayer.PlayerAllegiance.Balance+newPlayer.PlayerGenus.Balance+newPlayer.PlayerSpecies.Balance+newPlayer.PlayerJob.Balance+newPlayer.PlayerImp.Balance+newPlayer.PlayerOrigin.Balance+newPlayer.PlayerDeathState.Balance+newPlayer.PlayerAstro.Balance+newPlayer.PlayerAffi.Balance;
		newPlayer.Luck 			= Base_sec+newPlayer.PlayerHellCircle.Luck+newPlayer.PlayerAllegiance.Luck+newPlayer.PlayerGenus.Luck+newPlayer.PlayerSpecies.Luck+newPlayer.PlayerJob.Luck+newPlayer.PlayerImp.Luck+newPlayer.PlayerOrigin.Luck+newPlayer.PlayerDeathState.Luck+newPlayer.PlayerAstro.Luck+newPlayer.PlayerAffi.Luck;
		newPlayer.Perception 	= Base_sec+newPlayer.PlayerHellCircle.Perception+newPlayer.PlayerAllegiance.Perception+newPlayer.PlayerGenus.Perception+newPlayer.PlayerSpecies.Perception+newPlayer.PlayerJob.Perception+newPlayer.PlayerImp.Perception+newPlayer.PlayerOrigin.Perception+newPlayer.PlayerDeathState.Perception+newPlayer.PlayerAstro.Perception+newPlayer.PlayerAffi.Perception;
		newPlayer.Judgement 	= Base_sec+newPlayer.PlayerHellCircle.Judgement+newPlayer.PlayerAllegiance.Judgement+newPlayer.PlayerGenus.Judgement+newPlayer.PlayerSpecies.Judgement+newPlayer.PlayerJob.Judgement+newPlayer.PlayerImp.Judgement+newPlayer.PlayerOrigin.Judgement+newPlayer.PlayerDeathState.Judgement+newPlayer.PlayerAstro.Judgement+newPlayer.PlayerAffi.Judgement;
		newPlayer.Chaos			= Base_sec+newPlayer.PlayerHellCircle.Chaos+newPlayer.PlayerAllegiance.Chaos+newPlayer.PlayerGenus.Chaos+newPlayer.PlayerSpecies.Chaos+newPlayer.PlayerJob.Chaos+newPlayer.PlayerImp.Chaos+newPlayer.PlayerOrigin.Chaos+newPlayer.PlayerDeathState.Chaos+newPlayer.PlayerAstro.Chaos+newPlayer.PlayerAffi.Chaos;

		newPlayer.CurrentEmbodiment = newPlayer.Embodiment;
		newPlayer.CurrentInfluence = newPlayer.Influence;















		//Storing base stat in environment

		GameInformation.basePlayer.PlayerLevel = newPlayer.PlayerLevel;
		GameInformation.basePlayer.PlayerJob = newPlayer.PlayerJob;

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
		GameInformation.basePlayer.Malevolent = newPlayer.Malevolent;
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

	
	







}

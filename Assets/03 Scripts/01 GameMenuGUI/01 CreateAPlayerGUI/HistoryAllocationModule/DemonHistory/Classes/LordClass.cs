using UnityEngine;
using System.Collections;

public class LordClass : BaseClass {
	
	public LordClass (){
		ClassName = "Lord";
		ClassDescription = "My dead life is not something I want to part with just yet...";
		
		//Embodiment are always 100, same for action points
		Embodiment=5; 		//Health Points are always 100
		Influence=-5;			//Action Points are always 100
		

		//Primary physical
		Strength = 		1; 	//Crit dmg
		Speed = 		-1; 	//Speed
		Dexterity = 	0; 	//Hit
		Reflex = 		1; 	//Deflect rate
		Resilience = 	1; 	//Deflect amount
		
		//Primary non-physical		
		Knowledge = 	-1; //Crit dmg
		Elocution = 	-1; //Speed
		Intellect = 	-2; //Hit
		Focus = 		1; 	//Deflect rate
		Mockery = 		1; 	//Deflect amount
		
		//Primary leadership		
		Malevolant = 	-1; 	//DMG minion
		Unmerciful = 	1;	//Res minion
		
		//Heroic
		Rage = 			-1; 	//Crit
		Phase = 		1;	//Avoid all
		
		//Secondary
		Momentum = 		0; 	//Crowd
		Balance = 		0; 	//Run
		Luck = 			0; 	//human crap
		Perception = 	1;	//Number of loots
		Judgement = 	0;	//Rarity of loots
		Chaos = 		-1; //Random effects



	}
}
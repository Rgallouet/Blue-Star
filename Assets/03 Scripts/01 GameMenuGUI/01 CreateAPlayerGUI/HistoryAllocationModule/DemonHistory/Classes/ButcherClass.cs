using UnityEngine;
using System.Collections;


public class ButcherClass : BaseClass {

	public ButcherClass (){
		ClassName = "Butcher";
		ClassDescription = "Gotta slice 'em all!";

		//Embodiment are always 100, same for action points
		Embodiment=0; 		//Health Points are always 100
		Influence=0;			//Action Points are always 100

		//Primary physical
		Strength = 		2; 	//Crit dmg
		Speed = 		2; 	//Speed
		Dexterity = 	1; 	//Hit
		Reflex = 		0; 	//Deflect rate
		Resilience = 	0; 	//Deflect amount

		//Primary non-physical		
		Knowledge = 	-2; //Crit dmg
		Elocution = 	-1; //Speed
		Intellect = 	-2; //Hit
		Focus = 		0; 	//Deflect rate
		Mockery = 		0; 	//Deflect amount

		//Primary leadership		
		Malevolant = 	1; 	//DMG minion
		Unmerciful = 	-1;	//Res minion

		//Heroic
		Rage = 			1; 	//Crit
		Phase = 		-1;	//Avoid all

		//Secondary
		Momentum = 		1; 	//Crowd
		Balance = 		1; 	//Run
		Luck = 			0; 	//human crap
		Perception = 	-1;	//Number of loots
		Judgement = 	0;	//Rarity of loots
		Chaos = 		-1; //Random effects




	}
}

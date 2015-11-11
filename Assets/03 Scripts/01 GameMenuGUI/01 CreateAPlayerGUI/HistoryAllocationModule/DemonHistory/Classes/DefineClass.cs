using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineClass : BaseClass {

	public DefineClass (int Choice){

		switch (Choice) {
		case 1: 
			break;
		case 2: 

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

			break;
		case 3: 
			break;
		case 4: 
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

			break;
		case 5: 
			break;
		case 6: 
			break;
		case 7: 
			break;
		case 8: 
			break;
		case 9: 
			break;
		
		
		}


	if (ClassName == "") {


			ClassName = "Lord";
			ClassDescription = "My dead life is not something I want to part with just yet...";
		
			//Embodiment are always 100, same for action points
			Embodiment = 5; 		//Health Points are always 100
			Influence = -5;			//Action Points are always 100
		
		
			//Primary physical
			Strength = 1; 	//Crit dmg
			Speed = -1; 	//Speed
			Dexterity = 0; 	//Hit
			Reflex = 1; 	//Deflect rate
			Resilience = 1; 	//Deflect amount
		
			//Primary non-physical		
			Knowledge = -1; //Crit dmg
			Elocution = -1; //Speed
			Intellect = -2; //Hit
			Focus = 1; 	//Deflect rate
			Mockery = 1; 	//Deflect amount
		
			//Primary leadership		
			Malevolant = -1; 	//DMG minion
			Unmerciful = 1;	//Res minion
		
			//Heroic
			Rage = -1; 	//Crit
			Phase = 1;	//Avoid all
		
			//Secondary
			Momentum = 0; 	//Crowd
			Balance = 0; 	//Run
			Luck = 0; 	//human crap
			Perception = 0;	//Number of loots
			Judgement = 0;	//Rarity of loots
			Chaos = 0; //Random effect

		}


	}
}

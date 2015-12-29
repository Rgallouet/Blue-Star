using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineImp: BaseHistory {
	
	public DefineImp (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Imp Maid";Embodiment=-2;Reflex=3;Resilience=-4;Strength=-3;Speed=-4;Dexterity=3;Influence=2;Focus=-3;Mockery=4;Knowledge=3;Elocution=4;Intellect=-3;Malevolent=4;Unmerciful=-4;Rage=5;Phase=-5;Momentum=4;Balance=3;Luck=4;Perception=-4;Judgement=-3;Chaos=-4;
			break;
		case 2: 
			ClassName="Imp Cook";Embodiment=0;Reflex=0;Resilience=-2;Strength=0;Speed=5;Dexterity=2;Influence=0;Focus=0;Mockery=2;Knowledge=0;Elocution=-5;Intellect=-2;Malevolent=3;Unmerciful=-3;Rage=0;Phase=0;Momentum=-5;Balance=-2;Luck=0;Perception=0;Judgement=2;Chaos=5;
			break;
		case 3: 
			ClassName="Imp Butler";Embodiment=0;Reflex=-4;Resilience=2;Strength=0;Speed=-5;Dexterity=0;Influence=0;Focus=4;Mockery=-2;Knowledge=0;Elocution=5;Intellect=0;Malevolent=-3;Unmerciful=3;Rage=4;Phase=-4;Momentum=2;Balance=0;Luck=4;Perception=-4;Judgement=0;Chaos=-2;
			break;
		case 4: 
			ClassName="Imp Nurse";Embodiment=-3;Reflex=0;Resilience=0;Strength=0;Speed=4;Dexterity=0;Influence=3;Focus=0;Mockery=0;Knowledge=0;Elocution=-4;Intellect=0;Malevolent=5;Unmerciful=-5;Rage=0;Phase=0;Momentum=-5;Balance=5;Luck=-4;Perception=4;Judgement=-5;Chaos=5;
			break;
		case 5: 
			ClassName="Imp Driver";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Imp Cleaner";Embodiment=3;Reflex=0;Resilience=0;Strength=0;Speed=-4;Dexterity=0;Influence=-3;Focus=0;Mockery=0;Knowledge=0;Elocution=4;Intellect=0;Malevolent=-5;Unmerciful=5;Rage=0;Phase=0;Momentum=5;Balance=-5;Luck=4;Perception=-4;Judgement=5;Chaos=-5;
			break;
		case 7: 
			ClassName="Imp Builder";Embodiment=0;Reflex=4;Resilience=-2;Strength=0;Speed=5;Dexterity=0;Influence=0;Focus=-4;Mockery=2;Knowledge=0;Elocution=-5;Intellect=0;Malevolent=3;Unmerciful=-3;Rage=-4;Phase=4;Momentum=-2;Balance=0;Luck=-4;Perception=4;Judgement=0;Chaos=2;
			break;
		case 8: 
			ClassName="Imp Bodyguard";Embodiment=0;Reflex=0;Resilience=2;Strength=0;Speed=-5;Dexterity=-2;Influence=0;Focus=0;Mockery=-2;Knowledge=0;Elocution=5;Intellect=2;Malevolent=-3;Unmerciful=3;Rage=0;Phase=0;Momentum=5;Balance=2;Luck=0;Perception=0;Judgement=-2;Chaos=-5;
			break;
		case 9: 
			ClassName="Imp Governess";Embodiment=2;Reflex=-3;Resilience=4;Strength=3;Speed=4;Dexterity=-3;Influence=-2;Focus=3;Mockery=-4;Knowledge=-3;Elocution=-4;Intellect=3;Malevolent=-4;Unmerciful=4;Rage=-5;Phase=5;Momentum=-4;Balance=-3;Luck=-4;Perception=4;Judgement=3;Chaos=4;
			break;
		}
	}
}

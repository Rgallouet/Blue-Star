using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineImp: BaseHistory {
	
	public DefineImp (int i){

		Choice = i;

		switch (i) {
		case 1: 
			ClassName="Imp Maid";Embodiment=-6;Reflex=5;Resilience=-4;Strength=-7;Speed=-4;Dexterity=-3;Influence=6;Focus=-5;Mockery=4;Knowledge=7;Elocution=4;Intellect=3;Malevolent=3;Unmerciful=-3;Rage=1;Phase=-1;Momentum=-4;Balance=-2;Luck=-2;Perception=2;Judgement=2;Chaos=4;
			break;
		case 2: 
			ClassName="Imp Cook";Embodiment=6;Reflex=-5;Resilience=4;Strength=7;Speed=4;Dexterity=3;Influence=-6;Focus=5;Mockery=-4;Knowledge=-7;Elocution=-4;Intellect=-3;Malevolent=-3;Unmerciful=3;Rage=-1;Phase=1;Momentum=4;Balance=2;Luck=2;Perception=-2;Judgement=-2;Chaos=-4;
			break;
		case 3: 
			ClassName="Imp Butler";Embodiment=5;Reflex=-3;Resilience=2;Strength=-3;Speed=-4;Dexterity=-3;Influence=-5;Focus=3;Mockery=-2;Knowledge=3;Elocution=4;Intellect=3;Malevolent=-2;Unmerciful=2;Rage=0;Phase=0;Momentum=-2;Balance=-4;Luck=2;Perception=-2;Judgement=4;Chaos=2;
			break;
		case 4: 
			ClassName="Imp Nurse";Embodiment=-5;Reflex=3;Resilience=-2;Strength=3;Speed=4;Dexterity=3;Influence=5;Focus=-3;Mockery=2;Knowledge=-3;Elocution=-4;Intellect=-3;Malevolent=2;Unmerciful=-2;Rage=0;Phase=0;Momentum=2;Balance=4;Luck=-2;Perception=2;Judgement=-4;Chaos=-2;
			break;
		case 5: 
			ClassName="Imp Driver";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Imp Cleaner";Embodiment=-7;Reflex=-8;Resilience=-4;Strength=-2;Speed=-4;Dexterity=-2;Influence=7;Focus=8;Mockery=4;Knowledge=2;Elocution=4;Intellect=2;Malevolent=-2;Unmerciful=2;Rage=-1;Phase=1;Momentum=1;Balance=-3;Luck=-2;Perception=2;Judgement=3;Chaos=-1;
			break;
		case 7: 
			ClassName="Imp Builder";Embodiment=2;Reflex=-2;Resilience=2;Strength=-2;Speed=-1;Dexterity=-2;Influence=-2;Focus=2;Mockery=-2;Knowledge=2;Elocution=1;Intellect=2;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=2;Balance=2;Luck=-2;Perception=2;Judgement=-2;Chaos=-2;
			break;
		case 8: 
			ClassName="Imp Bodyguard";Embodiment=7;Reflex=8;Resilience=4;Strength=2;Speed=4;Dexterity=2;Influence=-7;Focus=-8;Mockery=-4;Knowledge=-2;Elocution=-4;Intellect=-2;Malevolent=2;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-1;Balance=3;Luck=2;Perception=-2;Judgement=-3;Chaos=1;
			break;
		case 9: 
			ClassName="Imp Governess";Embodiment=-2;Reflex=2;Resilience=-2;Strength=2;Speed=1;Dexterity=2;Influence=2;Focus=-2;Mockery=2;Knowledge=-2;Elocution=-1;Intellect=-2;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=-2;Balance=-2;Luck=2;Perception=-2;Judgement=2;Chaos=2;
			break;
		}
	}
}

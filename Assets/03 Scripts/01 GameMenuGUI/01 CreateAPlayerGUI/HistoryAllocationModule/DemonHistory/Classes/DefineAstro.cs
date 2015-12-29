using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineAstro: BaseHistory {
	
	public DefineAstro (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Canis";Embodiment=0;Reflex=5;Resilience=-2;Strength=-4;Speed=-2;Dexterity=4;Influence=0;Focus=-5;Mockery=2;Knowledge=4;Elocution=2;Intellect=-4;Malevolent=0;Unmerciful=0;Rage=3;Phase=-3;Momentum=0;Balance=-4;Luck=0;Perception=0;Judgement=4;Chaos=0;
			break;
		case 2: 
			ClassName="Scuti";Embodiment=0;Reflex=4;Resilience=-5;Strength=0;Speed=3;Dexterity=4;Influence=0;Focus=-4;Mockery=5;Knowledge=0;Elocution=-3;Intellect=-4;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=-2;Balance=0;Luck=-4;Perception=4;Judgement=0;Chaos=2;
			break;
		case 3: 
			ClassName="Cephei";Embodiment=0;Reflex=-4;Resilience=5;Strength=0;Speed=-3;Dexterity=-4;Influence=0;Focus=4;Mockery=-5;Knowledge=0;Elocution=3;Intellect=4;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=2;Balance=0;Luck=4;Perception=-4;Judgement=0;Chaos=-2;
			break;
		case 4: 
			ClassName="Wester";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 5: 
			ClassName="Betel";Embodiment=0;Reflex=-5;Resilience=2;Strength=4;Speed=2;Dexterity=-4;Influence=0;Focus=5;Mockery=-2;Knowledge=-4;Elocution=-2;Intellect=4;Malevolent=0;Unmerciful=0;Rage=-3;Phase=3;Momentum=0;Balance=4;Luck=0;Perception=0;Judgement=-4;Chaos=0;
			break;
		case 6: 
			ClassName="Vulpe";Embodiment=0;Reflex=0;Resilience=-5;Strength=2;Speed=4;Dexterity=4;Influence=0;Focus=0;Mockery=5;Knowledge=-2;Elocution=-4;Intellect=-4;Malevolent=4;Unmerciful=-4;Rage=0;Phase=0;Momentum=0;Balance=3;Luck=0;Perception=0;Judgement=-3;Chaos=0;
			break;
		case 7: 
			ClassName="Anta";Embodiment=0;Reflex=0;Resilience=5;Strength=-2;Speed=-4;Dexterity=-4;Influence=0;Focus=0;Mockery=-5;Knowledge=2;Elocution=4;Intellect=4;Malevolent=-4;Unmerciful=4;Rage=0;Phase=0;Momentum=0;Balance=-3;Luck=0;Perception=0;Judgement=3;Chaos=0;
			break;
		case 8: 
			ClassName="Gemi";Embodiment=5;Reflex=3;Resilience=0;Strength=0;Speed=0;Dexterity=-3;Influence=-5;Focus=-3;Mockery=0;Knowledge=0;Elocution=0;Intellect=3;Malevolent=4;Unmerciful=-4;Rage=0;Phase=0;Momentum=0;Balance=4;Luck=-3;Perception=3;Judgement=-4;Chaos=0;
			break;
		case 9: 
			ClassName="Cygni";Embodiment=-5;Reflex=-3;Resilience=0;Strength=0;Speed=0;Dexterity=3;Influence=5;Focus=3;Mockery=0;Knowledge=0;Elocution=0;Intellect=-3;Malevolent=-4;Unmerciful=4;Rage=0;Phase=0;Momentum=0;Balance=-4;Luck=3;Perception=-3;Judgement=4;Chaos=0;
			break;
		}
	}
}

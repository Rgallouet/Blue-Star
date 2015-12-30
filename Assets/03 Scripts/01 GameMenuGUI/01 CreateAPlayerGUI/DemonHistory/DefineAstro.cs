using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineAstro: BaseHistory {
	
	public DefineAstro (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Canis";Embodiment=3;Reflex=-3;Resilience=2;Strength=-2;Speed=3;Dexterity=-3;Influence=3;Focus=2;Mockery=3;Knowledge=-3;Elocution=-2;Intellect=-3;Malevolent=-2;Unmerciful=2;Rage=-1;Phase=1;Momentum=3;Balance=0;Luck=-5;Perception=5;Judgement=-3;Chaos=0;
			break;
		case 2: 
			ClassName="Scuti";Embodiment=2;Reflex=5;Resilience=3;Strength=-3;Speed=-5;Dexterity=-2;Influence=3;Focus=0;Mockery=3;Knowledge=-3;Elocution=0;Intellect=-3;Malevolent=0;Unmerciful=0;Rage=-1;Phase=1;Momentum=0;Balance=0;Luck=-2;Perception=2;Judgement=0;Chaos=0;
			break;
		case 3: 
			ClassName="Cephei";Embodiment=-2;Reflex=-5;Resilience=-3;Strength=3;Speed=5;Dexterity=2;Influence=-3;Focus=0;Mockery=-3;Knowledge=3;Elocution=0;Intellect=3;Malevolent=0;Unmerciful=0;Rage=1;Phase=-1;Momentum=0;Balance=0;Luck=2;Perception=-2;Judgement=0;Chaos=0;
			break;
		case 4: 
			ClassName="Wester";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 5: 
			ClassName="Betel";Embodiment=-3;Reflex=3;Resilience=-2;Strength=2;Speed=-3;Dexterity=3;Influence=-3;Focus=-2;Mockery=-3;Knowledge=3;Elocution=2;Intellect=3;Malevolent=2;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-3;Balance=0;Luck=5;Perception=-5;Judgement=3;Chaos=0;
			break;
		case 6: 
			ClassName="Vulpe";Embodiment=0;Reflex=0;Resilience=-2;Strength=2;Speed=0;Dexterity=0;Influence=3;Focus=0;Mockery=-3;Knowledge=3;Elocution=0;Intellect=-3;Malevolent=2;Unmerciful=-2;Rage=-1;Phase=1;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 7: 
			ClassName="Anta";Embodiment=0;Reflex=0;Resilience=2;Strength=-2;Speed=0;Dexterity=0;Influence=-3;Focus=0;Mockery=3;Knowledge=-3;Elocution=0;Intellect=3;Malevolent=-2;Unmerciful=2;Rage=1;Phase=-1;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 8: 
			ClassName="Gemi";Embodiment=2;Reflex=2;Resilience=0;Strength=0;Speed=-2;Dexterity=-2;Influence=3;Focus=0;Mockery=5;Knowledge=-5;Elocution=0;Intellect=-3;Malevolent=0;Unmerciful=0;Rage=-1;Phase=1;Momentum=0;Balance=0;Luck=-5;Perception=5;Judgement=0;Chaos=0;
			break;
		case 9: 
			ClassName="Cygni";Embodiment=-2;Reflex=-2;Resilience=0;Strength=0;Speed=2;Dexterity=2;Influence=-3;Focus=0;Mockery=-5;Knowledge=5;Elocution=0;Intellect=3;Malevolent=0;Unmerciful=0;Rage=1;Phase=-1;Momentum=0;Balance=0;Luck=5;Perception=-5;Judgement=0;Chaos=0;
			break;
		}
	}
}

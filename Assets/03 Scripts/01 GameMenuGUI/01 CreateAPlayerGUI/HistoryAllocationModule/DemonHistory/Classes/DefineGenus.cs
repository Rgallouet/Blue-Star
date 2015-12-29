using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineGenus: BaseHistory {
	
	public DefineGenus (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Demono";Embodiment=0;Reflex=1;Resilience=1;Strength=-2;Speed=-2;Dexterity=-2;Influence=0;Focus=1;Mockery=1;Knowledge=-2;Elocution=-2;Intellect=-2;Malevolent=4;Unmerciful=4;Rage=0;Phase=0;Momentum=-2;Balance=1;Luck=-2;Perception=-1;Judgement=1;Chaos=3;
			break;
		case 2: 
			ClassName="Angeli";Embodiment=0;Reflex=-3;Resilience=-3;Strength=-2;Speed=-2;Dexterity=-1;Influence=1;Focus=1;Mockery=1;Knowledge=4;Elocution=3;Intellect=3;Malevolent=-1;Unmerciful=-1;Rage=1;Phase=-1;Momentum=-2;Balance=2;Luck=2;Perception=1;Judgement=-2;Chaos=-1;
			break;
		case 3: 
			ClassName="Celticus";Embodiment=-2;Reflex=-2;Resilience=-2;Strength=-2;Speed=-2;Dexterity=-2;Influence=3;Focus=3;Mockery=3;Knowledge=1;Elocution=2;Intellect=2;Malevolent=-1;Unmerciful=-1;Rage=-1;Phase=1;Momentum=2;Balance=-1;Luck=2;Perception=-1;Judgement=-1;Chaos=-1;
			break;
		case 4: 
			ClassName="Nordi";Embodiment=-1;Reflex=1;Resilience=1;Strength=3;Speed=5;Dexterity=3;Influence=-2;Focus=-2;Mockery=-1;Knowledge=-1;Elocution=-2;Intellect=-2;Malevolent=-1;Unmerciful=-1;Rage=1;Phase=-1;Momentum=1;Balance=0;Luck=1;Perception=1;Judgement=-1;Chaos=-2;
			break;
		case 5: 
			ClassName="Nyla";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=1;Balance=-1;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Homo";Embodiment=3;Reflex=3;Resilience=3;Strength=3;Speed=1;Dexterity=2;Influence=-2;Focus=-3;Mockery=-4;Knowledge=-2;Elocution=-1;Intellect=-1;Malevolent=-1;Unmerciful=-1;Rage=-1;Phase=1;Momentum=0;Balance=-1;Luck=-3;Perception=0;Judgement=3;Chaos=1;
			break;

		}
	}
}

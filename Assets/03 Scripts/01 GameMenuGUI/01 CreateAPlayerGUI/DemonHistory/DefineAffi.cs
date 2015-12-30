using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineAffi: BaseHistory {
	
	public DefineAffi (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Organic";Embodiment=5;Reflex=-3;Resilience=2;Strength=3;Speed=-5;Dexterity=-2;Influence=-1;Focus=-4;Mockery=5;Knowledge=4;Elocution=1;Intellect=-5;Malevolent=-4;Unmerciful=4;Rage=-1;Phase=1;Momentum=3;Balance=-3;Luck=4;Perception=-4;Judgement=-3;Chaos=3;
			break;
		case 2: 
			ClassName="Light";Embodiment=-4;Reflex=4;Resilience=3;Strength=-4;Speed=4;Dexterity=-3;Influence=4;Focus=3;Mockery=-4;Knowledge=-3;Elocution=-4;Intellect=4;Malevolent=2;Unmerciful=-2;Rage=0;Phase=0;Momentum=-4;Balance=4;Luck=4;Perception=-4;Judgement=5;Chaos=-5;
			break;
		case 3: 
			ClassName="Heat";Embodiment=4;Reflex=-5;Resilience=5;Strength=5;Speed=-4;Dexterity=-5;Influence=5;Focus=-4;Mockery=-5;Knowledge=4;Elocution=-5;Intellect=5;Malevolent=5;Unmerciful=-5;Rage=-1;Phase=1;Momentum=-2;Balance=2;Luck=3;Perception=-3;Judgement=-2;Chaos=2;
			break;
		case 4: 
			ClassName="Nuclear";Embodiment=5;Reflex=3;Resilience=-2;Strength=-3;Speed=-5;Dexterity=2;Influence=-2;Focus=-4;Mockery=2;Knowledge=4;Elocution=2;Intellect=-2;Malevolent=-4;Unmerciful=4;Rage=1;Phase=-1;Momentum=-3;Balance=3;Luck=5;Perception=-5;Judgement=-2;Chaos=2;
			break;
		case 5: 
			ClassName="Magneto";Embodiment=-5;Reflex=-3;Resilience=2;Strength=3;Speed=5;Dexterity=-2;Influence=2;Focus=4;Mockery=-2;Knowledge=-4;Elocution=-2;Intellect=2;Malevolent=4;Unmerciful=-4;Rage=-1;Phase=1;Momentum=3;Balance=-3;Luck=-5;Perception=5;Judgement=2;Chaos=-2;
			break;
		case 6: 
			ClassName="Psychic";Embodiment=-5;Reflex=3;Resilience=-2;Strength=-3;Speed=5;Dexterity=2;Influence=1;Focus=4;Mockery=-5;Knowledge=-4;Elocution=-1;Intellect=5;Malevolent=4;Unmerciful=-4;Rage=1;Phase=-1;Momentum=-3;Balance=3;Luck=-4;Perception=4;Judgement=3;Chaos=-3;
			break;
		case 7: 
			ClassName="Gravity";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 8: 
			ClassName="Cold";Embodiment=-4;Reflex=5;Resilience=-5;Strength=-5;Speed=4;Dexterity=5;Influence=-5;Focus=4;Mockery=5;Knowledge=-4;Elocution=5;Intellect=-5;Malevolent=-5;Unmerciful=5;Rage=1;Phase=-1;Momentum=2;Balance=-2;Luck=-3;Perception=3;Judgement=2;Chaos=-2;
			break;
		case 9: 
			ClassName="Shadow";Embodiment=4;Reflex=-4;Resilience=-3;Strength=4;Speed=-4;Dexterity=3;Influence=-4;Focus=-3;Mockery=4;Knowledge=3;Elocution=4;Intellect=-4;Malevolent=-2;Unmerciful=2;Rage=0;Phase=0;Momentum=4;Balance=-4;Luck=-4;Perception=4;Judgement=-5;Chaos=5;
			break;
		}
	}
}

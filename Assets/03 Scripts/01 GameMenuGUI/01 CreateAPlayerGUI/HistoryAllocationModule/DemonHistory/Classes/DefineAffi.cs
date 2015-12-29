using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineAffi: BaseHistory {
	
	public DefineAffi (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Organic";Embodiment=-2;Reflex=-2;Resilience=0;Strength=5;Speed=2;Dexterity=0;Influence=2;Focus=2;Mockery=0;Knowledge=-5;Elocution=-2;Intellect=0;Malevolent=0;Unmerciful=0;Rage=-4;Phase=4;Momentum=0;Balance=4;Luck=-4;Perception=0;Judgement=5;Chaos=-5;
			break;
		case 2: 
			ClassName="Light";Embodiment=-5;Reflex=4;Resilience=-4;Strength=4;Speed=2;Dexterity=-4;Influence=5;Focus=-4;Mockery=4;Knowledge=-4;Elocution=-2;Intellect=4;Malevolent=-3;Unmerciful=3;Rage=0;Phase=0;Momentum=0;Balance=-2;Luck=2;Perception=0;Judgement=2;Chaos=-2;
			break;
		case 3: 
			ClassName="Heat";Embodiment=2;Reflex=0;Resilience=3;Strength=-4;Speed=-4;Dexterity=-5;Influence=-2;Focus=0;Mockery=-3;Knowledge=4;Elocution=4;Intellect=5;Malevolent=4;Unmerciful=-4;Rage=4;Phase=-4;Momentum=-4;Balance=0;Luck=0;Perception=4;Judgement=-2;Chaos=2;
			break;
		case 4: 
			ClassName="Nuclear";Embodiment=3;Reflex=5;Resilience=-3;Strength=4;Speed=-4;Dexterity=0;Influence=-3;Focus=-5;Mockery=3;Knowledge=-4;Elocution=4;Intellect=0;Malevolent=-2;Unmerciful=2;Rage=4;Phase=-4;Momentum=0;Balance=-3;Luck=3;Perception=0;Judgement=-2;Chaos=2;
			break;
		case 5: 
			ClassName="Magneto";Embodiment=-3;Reflex=-5;Resilience=3;Strength=-4;Speed=4;Dexterity=0;Influence=3;Focus=5;Mockery=-3;Knowledge=4;Elocution=-4;Intellect=0;Malevolent=2;Unmerciful=-2;Rage=-4;Phase=4;Momentum=0;Balance=3;Luck=-3;Perception=0;Judgement=2;Chaos=-2;
			break;
		case 6: 
			ClassName="Psychic";Embodiment=2;Reflex=2;Resilience=0;Strength=-5;Speed=-2;Dexterity=0;Influence=-2;Focus=-2;Mockery=0;Knowledge=5;Elocution=2;Intellect=0;Malevolent=0;Unmerciful=0;Rage=4;Phase=-4;Momentum=0;Balance=-4;Luck=4;Perception=0;Judgement=-5;Chaos=5;
			break;
		case 7: 
			ClassName="Gravity";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 8: 
			ClassName="Cold";Embodiment=-2;Reflex=0;Resilience=-3;Strength=4;Speed=4;Dexterity=5;Influence=2;Focus=0;Mockery=3;Knowledge=-4;Elocution=-4;Intellect=-5;Malevolent=-4;Unmerciful=4;Rage=-4;Phase=4;Momentum=4;Balance=0;Luck=0;Perception=-4;Judgement=2;Chaos=-2;
			break;
		case 9: 
			ClassName="Shadow";Embodiment=5;Reflex=-4;Resilience=4;Strength=-4;Speed=-2;Dexterity=4;Influence=-5;Focus=4;Mockery=-4;Knowledge=4;Elocution=2;Intellect=-4;Malevolent=3;Unmerciful=-3;Rage=0;Phase=0;Momentum=0;Balance=2;Luck=-2;Perception=0;Judgement=-2;Chaos=2;
			break;
		}
	}
}

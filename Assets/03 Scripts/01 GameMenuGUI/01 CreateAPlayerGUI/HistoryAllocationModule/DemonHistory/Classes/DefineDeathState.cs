using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineDeathState: BaseHistory {
	
	public DefineDeathState (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Lashing out";Embodiment=2;Reflex=-4;Resilience=-4;Strength=-5;Speed=0;Dexterity=0;Influence=-2;Focus=4;Mockery=4;Knowledge=5;Elocution=0;Intellect=0;Malevolent=4;Unmerciful=-4;Rage=-2;Phase=2;Momentum=4;Balance=-4;Luck=-5;Perception=5;Judgement=4;Chaos=-4;
			break;
		case 2: 
			ClassName="Rebellious";Embodiment=0;Reflex=-2;Resilience=-2;Strength=-5;Speed=-3;Dexterity=-5;Influence=0;Focus=2;Mockery=2;Knowledge=5;Elocution=3;Intellect=5;Malevolent=4;Unmerciful=-4;Rage=0;Phase=0;Momentum=4;Balance=0;Luck=4;Perception=-4;Judgement=0;Chaos=-4;
			break;
		case 3: 
			ClassName="Bored";Embodiment=-3;Reflex=5;Resilience=3;Strength=4;Speed=-3;Dexterity=0;Influence=3;Focus=-5;Mockery=-3;Knowledge=-4;Elocution=3;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=-3;Luck=5;Perception=-5;Judgement=3;Chaos=0;
			break;
		case 4: 
			ClassName="Violent";Embodiment=3;Reflex=-5;Resilience=-3;Strength=-4;Speed=3;Dexterity=0;Influence=-3;Focus=5;Mockery=3;Knowledge=4;Elocution=-3;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=3;Luck=-5;Perception=5;Judgement=-3;Chaos=0;
			break;
		case 5: 
			ClassName="Powerlessness";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Unfairness";Embodiment=0;Reflex=-4;Resilience=0;Strength=0;Speed=-4;Dexterity=-5;Influence=0;Focus=4;Mockery=0;Knowledge=0;Elocution=4;Intellect=5;Malevolent=3;Unmerciful=-3;Rage=-2;Phase=2;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 7: 
			ClassName="At peace";Embodiment=0;Reflex=4;Resilience=0;Strength=0;Speed=4;Dexterity=5;Influence=0;Focus=-4;Mockery=0;Knowledge=0;Elocution=-4;Intellect=-5;Malevolent=-3;Unmerciful=3;Rage=2;Phase=-2;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 8: 
			ClassName="Sleepy";Embodiment=0;Reflex=2;Resilience=2;Strength=5;Speed=3;Dexterity=5;Influence=0;Focus=-2;Mockery=-2;Knowledge=-5;Elocution=-3;Intellect=-5;Malevolent=-4;Unmerciful=4;Rage=0;Phase=0;Momentum=-4;Balance=0;Luck=-4;Perception=4;Judgement=0;Chaos=4;
			break;
		case 9: 
			ClassName="Passive";Embodiment=-2;Reflex=4;Resilience=4;Strength=5;Speed=0;Dexterity=0;Influence=2;Focus=-4;Mockery=-4;Knowledge=-5;Elocution=0;Intellect=0;Malevolent=-4;Unmerciful=4;Rage=2;Phase=-2;Momentum=-4;Balance=4;Luck=5;Perception=-5;Judgement=-4;Chaos=4;
			break;
		}
	}
}

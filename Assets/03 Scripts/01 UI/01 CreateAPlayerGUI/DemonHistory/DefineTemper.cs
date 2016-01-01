using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineTemper: BaseHistory {
	
	public DefineTemper (int i){

		Choice = i;

		switch (i) {
		case 1: 
			ClassName="Lashing out";Embodiment=3;Reflex=6;Resilience=2;Strength=3;Speed=-2;Dexterity=4;Influence=-3;Focus=-6;Mockery=-2;Knowledge=-3;Elocution=2;Intellect=-4;Malevolent=1;Unmerciful=-1;Rage=0;Phase=0;Momentum=2;Balance=-2;Luck=-2;Perception=2;Judgement=2;Chaos=-2;
			break;
		case 2: 
			ClassName="Rebellious";Embodiment=-2;Reflex=-2;Resilience=2;Strength=7;Speed=1;Dexterity=1;Influence=2;Focus=2;Mockery=-2;Knowledge=-7;Elocution=-1;Intellect=-1;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=-2;Balance=3;Luck=-1;Perception=1;Judgement=-3;Chaos=2;
			break;
		case 3: 
			ClassName="Bored";Embodiment=-3;Reflex=-2;Resilience=0;Strength=-2;Speed=-2;Dexterity=2;Influence=3;Focus=2;Mockery=0;Knowledge=2;Elocution=2;Intellect=-2;Malevolent=2;Unmerciful=-2;Rage=0;Phase=0;Momentum=3;Balance=-5;Luck=-1;Perception=1;Judgement=5;Chaos=-3;
			break;
		case 4: 
			ClassName="Violent";Embodiment=3;Reflex=2;Resilience=0;Strength=2;Speed=2;Dexterity=-2;Influence=-3;Focus=-2;Mockery=0;Knowledge=-2;Elocution=-2;Intellect=2;Malevolent=-2;Unmerciful=2;Rage=0;Phase=0;Momentum=-3;Balance=5;Luck=1;Perception=-1;Judgement=-5;Chaos=3;
			break;
		case 5: 
			ClassName="Powerlessness";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Unfairness";Embodiment=-3;Reflex=-2;Resilience=-3;Strength=-1;Speed=-2;Dexterity=-1;Influence=3;Focus=2;Mockery=3;Knowledge=1;Elocution=2;Intellect=1;Malevolent=2;Unmerciful=-2;Rage=0;Phase=0;Momentum=3;Balance=2;Luck=2;Perception=-2;Judgement=-2;Chaos=-3;
			break;
		case 7: 
			ClassName="At peace";Embodiment=2;Reflex=2;Resilience=-2;Strength=-7;Speed=-1;Dexterity=-1;Influence=-2;Focus=-2;Mockery=2;Knowledge=7;Elocution=1;Intellect=1;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=2;Balance=-3;Luck=1;Perception=-1;Judgement=3;Chaos=-2;
			break;
		case 8: 
			ClassName="Sleepy";Embodiment=3;Reflex=2;Resilience=3;Strength=1;Speed=2;Dexterity=1;Influence=-3;Focus=-2;Mockery=-3;Knowledge=-1;Elocution=-2;Intellect=-1;Malevolent=-2;Unmerciful=2;Rage=0;Phase=0;Momentum=-3;Balance=-2;Luck=-2;Perception=2;Judgement=2;Chaos=3;
			break;
		case 9: 
			ClassName="Passive";Embodiment=-3;Reflex=-6;Resilience=-2;Strength=-3;Speed=2;Dexterity=-4;Influence=3;Focus=6;Mockery=2;Knowledge=3;Elocution=-2;Intellect=4;Malevolent=-1;Unmerciful=1;Rage=0;Phase=0;Momentum=-2;Balance=2;Luck=2;Perception=-2;Judgement=-2;Chaos=2;
			break;
		}
	}
}

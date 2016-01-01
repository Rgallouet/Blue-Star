using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineAllegiance: BaseHistory {
	
	public DefineAllegiance (int i){

		Choice = i;

		switch (i) {
		case 1: 
			ClassName="House Da'rhas";Embodiment=-2;Reflex=4;Resilience=-2;Strength=-4;Speed=2;Dexterity=-2;Influence=2;Focus=4;Mockery=-2;Knowledge=-4;Elocution=2;Intellect=-2;Malevolent=2;Unmerciful=2;Rage=0;Phase=0;Momentum=-5;Balance=-5;Luck=5;Perception=5;Judgement=5;Chaos=-5;
			break;
		case 2: 
			ClassName="House O'prescu";Embodiment=2;Reflex=-2;Resilience=4;Strength=2;Speed=-4;Dexterity=-2;Influence=-2;Focus=-2;Mockery=4;Knowledge=2;Elocution=-4;Intellect=-2;Malevolent=2;Unmerciful=2;Rage=0;Phase=0;Momentum=5;Balance=5;Luck=-5;Perception=-5;Judgement=-5;Chaos=5;
			break;
		case 3: 
			ClassName="House Maliborgis";Embodiment=2;Reflex=-3;Resilience=-2;Strength=3;Speed=-5;Dexterity=3;Influence=3;Focus=-2;Mockery=-3;Knowledge=3;Elocution=-2;Intellect=-3;Malevolent=3;Unmerciful=3;Rage=0;Phase=0;Momentum=2;Balance=2;Luck=-10;Perception=2;Judgement=2;Chaos=2;
			break;
		case 4: 
			ClassName="The doubt";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 5: 
			ClassName="The Free Market Guild";Embodiment=4;Reflex=3;Resilience=2;Strength=3;Speed=5;Dexterity=1;Influence=-4;Focus=-5;Mockery=-2;Knowledge=-5;Elocution=-8;Intellect=3;Malevolent=2;Unmerciful=1;Rage=0;Phase=0;Momentum=-5;Balance=-5;Luck=15;Perception=0;Judgement=0;Chaos=-5;
			break;
		case 6: 
			ClassName="The Autonomous Senate";Embodiment=-4;Reflex=-2;Resilience=-2;Strength=-4;Speed=-2;Dexterity=-3;Influence=3;Focus=4;Mockery=-2;Knowledge=2;Elocution=6;Intellect=-2;Malevolent=3;Unmerciful=3;Rage=0;Phase=0;Momentum=-2;Balance=-2;Luck=2;Perception=2;Judgement=2;Chaos=-2;
			break;
		case 7: 
			ClassName="The Sheath";Embodiment=6;Reflex=2;Resilience=2;Strength=2;Speed=4;Dexterity=2;Influence=-4;Focus=-4;Mockery=2;Knowledge=-3;Elocution=0;Intellect=-1;Malevolent=-4;Unmerciful=-4;Rage=0;Phase=0;Momentum=5;Balance=5;Luck=-7;Perception=-4;Judgement=-4;Chaos=5;
			break;
		case 8: 
			ClassName="The Deministries";Embodiment=-4;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=1;Influence=1;Focus=2;Mockery=2;Knowledge=0;Elocution=1;Intellect=1;Malevolent=-2;Unmerciful=-2;Rage=0;Phase=0;Momentum=4;Balance=-2;Luck=-2;Perception=-2;Judgement=-2;Chaos=4;
			break;
		case 9: 
			ClassName="None";Embodiment=-4;Reflex=-2;Resilience=-2;Strength=-2;Speed=0;Dexterity=0;Influence=1;Focus=3;Mockery=1;Knowledge=5;Elocution=5;Intellect=6;Malevolent=-6;Unmerciful=-5;Rage=0;Phase=0;Momentum=-4;Balance=2;Luck=2;Perception=2;Judgement=2;Chaos=-4;			
			break;
		}
	}
}

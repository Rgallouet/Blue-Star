using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineOrigin : BaseHistory {
	
	public DefineOrigin (int i){

		Choice = i;

		switch (i) {
		case 1: 
			
			ClassName="Monkey";Embodiment=5;Reflex=2;Resilience=2;Strength=5;Speed=2;Dexterity=5;Influence=-3;Focus=-4;Mockery=-3;Knowledge=-4;Elocution=-4;Intellect=-3;Malevolent=2;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-4;Balance=5;Luck=2;Perception=-1;Judgement=-2;Chaos=0;
			break;
		case 2: 
			
			ClassName="Bear";Embodiment=2;Reflex=5;Resilience=5;Strength=5;Speed=2;Dexterity=2;Influence=-4;Focus=-3;Mockery=-4;Knowledge=-3;Elocution=-3;Intellect=-4;Malevolent=-2;Unmerciful=2;Rage=-1;Phase=1;Momentum=2;Balance=-3;Luck=-2;Perception=2;Judgement=3;Chaos=-2;
			break;
		case 3: 
			
			ClassName="Wolf";Embodiment=2;Reflex=2;Resilience=5;Strength=2;Speed=5;Dexterity=5;Influence=-4;Focus=-3;Mockery=-3;Knowledge=-4;Elocution=-3;Intellect=-4;Malevolent=2;Unmerciful=-2;Rage=1;Phase=-1;Momentum=1;Balance=7;Luck=-3;Perception=-3;Judgement=-4;Chaos=2;
			break;
		case 4: 
			ClassName="Bee";Embodiment=-4;Reflex=-3;Resilience=-3;Strength=-4;Speed=-4;Dexterity=-3;Influence=2;Focus=5;Mockery=2;Knowledge=2;Elocution=5;Intellect=5;Malevolent=0;Unmerciful=0;Rage=1;Phase=-1;Momentum=-7;Balance=5;Luck=3;Perception=-2;Judgement=5;Chaos=-4;
			break;
		case 5: 
			
			ClassName="Snail";Embodiment=-3;Reflex=-4;Resilience=-3;Strength=-4;Speed=-3;Dexterity=-4;Influence=2;Focus=5;Mockery=5;Knowledge=5;Elocution=2;Intellect=2;Malevolent=-2;Unmerciful=2;Rage=-1;Phase=1;Momentum=4;Balance=-7;Luck=-1;Perception=2;Judgement=2;Chaos=0;
			break;
		case 6: 
			
			ClassName="Ant";Embodiment=-3;Reflex=-3;Resilience=-4;Strength=-3;Speed=-4;Dexterity=-4;Influence=5;Focus=2;Mockery=2;Knowledge=5;Elocution=5;Intellect=2;Malevolent=2;Unmerciful=-2;Rage=1;Phase=-1;Momentum=2;Balance=-2;Luck=1;Perception=2;Judgement=-1;Chaos=-2;
			break;
		case 7: 
			
			ClassName="Doe";Embodiment=-4;Reflex=-4;Resilience=-4;Strength=-3;Speed=-3;Dexterity=-3;Influence=5;Focus=2;Mockery=5;Knowledge=2;Elocution=2;Intellect=5;Malevolent=0;Unmerciful=0;Rage=-1;Phase=1;Momentum=1;Balance=1;Luck=-2;Perception=2;Judgement=-6;Chaos=4;
			break;
		case 8: 
			
			ClassName="Owl";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 9: 
			
			ClassName="Turtle";Embodiment=5;Reflex=5;Resilience=2;Strength=2;Speed=5;Dexterity=2;Influence=-3;Focus=-4;Mockery=-4;Knowledge=-3;Elocution=-4;Intellect=-3;Malevolent=-2;Unmerciful=2;Rage=-1;Phase=1;Momentum=1;Balance=-6;Luck=2;Perception=-2;Judgement=3;Chaos=2;			break;
			
			
		}
		
		
	}
}

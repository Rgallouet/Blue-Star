using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineJob : BaseHistory {
	
	public DefineJob (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Hunter";Embodiment=3;Reflex=12;Resilience=0;Strength=1;Speed=12;Dexterity=12;Influence=-9;Focus=-8;Mockery=-7;Knowledge=-4;Elocution=-9;Intellect=-7;Malevolent=5;Unmerciful=-6;Rage=1;Phase=-1;Momentum=-2;Balance=2;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 2: 
			
			ClassName="Butcher";Embodiment=1;Reflex=2;Resilience=12;Strength=12;Speed=2;Dexterity=12;Influence=-7;Focus=-10;Mockery=-7;Knowledge=-9;Elocution=-7;Intellect=-7;Malevolent=6;Unmerciful=-5;Rage=1;Phase=-1;Momentum=-2;Balance=2;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 3: 
			ClassName="Guardian";Embodiment=12;Reflex=12;Resilience=0;Strength=0;Speed=12;Dexterity=1;Influence=-7;Focus=-5;Mockery=-7;Knowledge=-8;Elocution=-8;Intellect=-8;Malevolent=0;Unmerciful=1;Rage=-1;Phase=1;Momentum=2;Balance=-2;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 4: 
			ClassName="Lord";Embodiment=12;Reflex=0;Resilience=12;Strength=12;Speed=1;Dexterity=1;Influence=-7;Focus=-5;Mockery=-9;Knowledge=-7;Elocution=-7;Intellect=-7;Malevolent=-6;Unmerciful=5;Rage=-1;Phase=1;Momentum=2;Balance=-2;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 5: 
			ClassName="Architect";Embodiment=0;Reflex=0;Resilience=0;Strength=-1;Speed=0;Dexterity=0;Influence=-1;Focus=0;Mockery=0;Knowledge=-1;Elocution=0;Intellect=0;Malevolent=-1;Unmerciful=-1;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		case 6: 
			ClassName="Judge";Embodiment=-10;Reflex=-9;Resilience=-6;Strength=-5;Speed=-8;Dexterity=-7;Influence=3;Focus=12;Mockery=2;Knowledge=2;Elocution=12;Intellect=12;Malevolent=-1;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-2;Balance=2;Luck=0;Perception=0;Judgement=0;Chaos=0;

			break;
		case 7: 
			ClassName="Warlock";Embodiment=-7;Reflex=-10;Resilience=-7;Strength=-7;Speed=-7;Dexterity=-7;Influence=1;Focus=1;Mockery=12;Knowledge=12;Elocution=3;Intellect=12;Malevolent=0;Unmerciful=-1;Rage=1;Phase=-1;Momentum=-2;Balance=2;Luck=0;Perception=0;Judgement=0;Chaos=0;

			break;
		case 8: 
			ClassName="Whisperer";Embodiment=-7;Reflex=-5;Resilience=-6;Strength=-7;Speed=-9;Dexterity=-8;Influence=12;Focus=12;Mockery=1;Knowledge=0;Elocution=12;Intellect=0;Malevolent=0;Unmerciful=0;Rage=-1;Phase=1;Momentum=2;Balance=-2;Luck=0;Perception=0;Judgement=0;Chaos=0;

			break;
		case 9: 
			ClassName="Soul healer";Embodiment=-7;Reflex=-5;Resilience=-8;Strength=-9;Speed=-6;Dexterity=-7;Influence=12;Focus=0;Mockery=12;Knowledge=12;Elocution=0;Intellect=2;Malevolent=-6;Unmerciful=5;Rage=-1;Phase=1;Momentum=2;Balance=-2;Luck=0;Perception=0;Judgement=0;Chaos=0;

			break;	
	
		}
	}
}

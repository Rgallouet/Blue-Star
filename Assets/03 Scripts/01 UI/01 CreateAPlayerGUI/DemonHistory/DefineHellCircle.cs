using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineHellCircle : BaseHistory {

	public DefineHellCircle (int i){

		Choice = i;

		switch (i) {
		case 1: 
			ClassName="Limbo town";Embodiment=-4;Reflex=-4;Resilience=-3;Strength=-4;Speed=-3;Dexterity=-4;Influence=3;Focus=2;Mockery=3;Knowledge=2;Elocution=3;Intellect=2;Malevolent=4;Unmerciful=3;Rage=-1;Phase=1;Momentum=0;Balance=-1;Luck=-1;Perception=1;Judgement=4;Chaos=-3;
			break;
		case 2: 
			ClassName="Lust halls";Embodiment=-3;Reflex=-3;Resilience=-3;Strength=-3;Speed=-3;Dexterity=-4;Influence=4;Focus=4;Mockery=4;Knowledge=4;Elocution=4;Intellect=4;Malevolent=-3;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-1;Balance=4;Luck=-1;Perception=-2;Judgement=1;Chaos=-1;
			break;
		case 3: 
			ClassName="Gluttonbourg";Embodiment=4;Reflex=3;Resilience=4;Strength=-3;Speed=-4;Dexterity=-3;Influence=3;Focus=4;Mockery=3;Knowledge=-3;Elocution=-2;Intellect=-4;Malevolent=-4;Unmerciful=2;Rage=-1;Phase=1;Momentum=4;Balance=-3;Luck=1;Perception=1;Judgement=-1;Chaos=-2;
			break;
		case 4: 
			ClassName="Greedopolis";Embodiment=-4;Reflex=-3;Resilience=-4;Strength=3;Speed=4;Dexterity=3;Influence=-3;Focus=-4;Mockery=-3;Knowledge=3;Elocution=2;Intellect=4;Malevolent=4;Unmerciful=-2;Rage=1;Phase=-1;Momentum=-4;Balance=-2;Luck=4;Perception=-1;Judgement=1;Chaos=2;
			break;
		case 5: 
			ClassName="Capanger";Embodiment=4;Reflex=4;Resilience=4;Strength=4;Speed=4;Dexterity=4;Influence=-4;Focus=-3;Mockery=-3;Knowledge=-3;Elocution=-4;Intellect=-3;Malevolent=-2;Unmerciful=-2;Rage=0;Phase=0;Momentum=3;Balance=2;Luck=-2;Perception=1;Judgement=-3;Chaos=-1;
			break;
		case 6: 
			ClassName="Heresynia";Embodiment=2;Reflex=2;Resilience=2;Strength=2;Speed=2;Dexterity=4;Influence=-4;Focus=-4;Mockery=-3;Knowledge=-3;Elocution=-4;Intellect=-3;Malevolent=3;Unmerciful=4;Rage=-1;Phase=1;Momentum=-2;Balance=2;Luck=-1;Perception=-2;Judgement=-3;Chaos=6;
			break;
		case 7: 
			ClassName="Violocanto";Embodiment=-3;Reflex=-3;Resilience=-2;Strength=3;Speed=2;Dexterity=3;Influence=2;Focus=4;Mockery=4;Knowledge=-3;Elocution=-3;Intellect=-4;Malevolent=1;Unmerciful=-1;Rage=1;Phase=-1;Momentum=2;Balance=1;Luck=-1;Perception=-2;Judgement=-2;Chaos=2;
			break;
		case 8: 
			ClassName="Bolgiafraudis";Embodiment=4;Reflex=4;Resilience=2;Strength=-2;Speed=-2;Dexterity=-3;Influence=-2;Focus=-3;Mockery=-4;Knowledge=3;Elocution=4;Intellect=4;Malevolent=-3;Unmerciful=-2;Rage=0;Phase=0;Momentum=-2;Balance=-3;Luck=1;Perception=4;Judgement=3;Chaos=-3;
			break;
		case 9: 
			ClassName="Traitor's frost grounds";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=1;Focus=0;Mockery=-1;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=0;Judgement=0;Chaos=0;
			break;
		}
	}
}

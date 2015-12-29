using UnityEngine;
using System.Collections;
[System.Serializable]

public class DefineSpecies: BaseHistory {
	
	public DefineSpecies (int Choice){
		
		switch (Choice) {
		case 1: 
			ClassName="Hornydi";Embodiment=0;Reflex=3;Resilience=-3;Strength=2;Speed=-1;Dexterity=-1;Influence=0;Focus=3;Mockery=-3;Knowledge=4;Elocution=-3;Intellect=-1;Malevolent=1;Unmerciful=-1;Rage=0;Phase=0;Momentum=-3;Balance=2;Luck=-6;Perception=2;Judgement=2;Chaos=3;
			break;
		case 2: 
			ClassName="Succybi";Embodiment=-2;Reflex=3;Resilience=-3;Strength=-4;Speed=-3;Dexterity=0;Influence=2;Focus=5;Mockery=-5;Knowledge=2;Elocution=1;Intellect=1;Malevolent=2;Unmerciful=1;Rage=0;Phase=0;Momentum=-5;Balance=1;Luck=-2;Perception=0;Judgement=2;Chaos=4;
			break;
		case 3: 
			ClassName="Vampyri";Embodiment=2;Reflex=3;Resilience=-3;Strength=1;Speed=3;Dexterity=2;Influence=-2;Focus=-1;Mockery=2;Knowledge=-3;Elocution=-2;Intellect=-2;Malevolent=-1;Unmerciful=1;Rage=0;Phase=0;Momentum=-3;Balance=1;Luck=-1;Perception=2;Judgement=-2;Chaos=3;
			break;
		case 4: 
			ClassName="Seraphim";Embodiment=-2;Reflex=2;Resilience=-2;Strength=-2;Speed=-4;Dexterity=-3;Influence=2;Focus=4;Mockery=0;Knowledge=3;Elocution=4;Intellect=2;Malevolent=-2;Unmerciful=-2;Rage=0;Phase=0;Momentum=-4;Balance=-5;Luck=13;Perception=1;Judgement=1;Chaos=-6;
			break;
		case 5: 
			ClassName="Cherubim";Embodiment=-2;Reflex=2;Resilience=-4;Strength=-2;Speed=2;Dexterity=-1;Influence=2;Focus=3;Mockery=-4;Knowledge=2;Elocution=4;Intellect=3;Malevolent=-2;Unmerciful=-3;Rage=1;Phase=-1;Momentum=-6;Balance=-1;Luck=10;Perception=0;Judgement=2;Chaos=-5;
			break;
		case 6: 
			ClassName="Thronoi";Embodiment=1;Reflex=2;Resilience=-3;Strength=-3;Speed=0;Dexterity=-2;Influence=4;Focus=4;Mockery=-3;Knowledge=0;Elocution=0;Intellect=2;Malevolent=-1;Unmerciful=-1;Rage=-1;Phase=1;Momentum=-6;Balance=-8;Luck=12;Perception=2;Judgement=4;Chaos=-4;
			break;
		case 7: 
			ClassName="Ankou";Embodiment=-1;Reflex=-5;Resilience=5;Strength=-2;Speed=-4;Dexterity=-1;Influence=2;Focus=-3;Mockery=5;Knowledge=0;Elocution=0;Intellect=1;Malevolent=1;Unmerciful=2;Rage=0;Phase=0;Momentum=5;Balance=-2;Luck=-1;Perception=-1;Judgement=-1;Chaos=0;
			break;
		case 8: 
			ClassName="Cernun";Embodiment=-3;Reflex=-2;Resilience=-5;Strength=0;Speed=-4;Dexterity=-3;Influence=3;Focus=-3;Mockery=6;Knowledge=2;Elocution=4;Intellect=2;Malevolent=2;Unmerciful=1;Rage=0;Phase=0;Momentum=3;Balance=-2;Luck=0;Perception=0;Judgement=0;Chaos=-1;
			break;
		case 9: 
			ClassName="Dagmus";Embodiment=6;Reflex=-4;Resilience=7;Strength=2;Speed=2;Dexterity=2;Influence=-4;Focus=-5;Mockery=-1;Knowledge=-1;Elocution=-2;Intellect=-3;Malevolent=-1;Unmerciful=2;Rage=0;Phase=0;Momentum=8;Balance=-3;Luck=-2;Perception=-1;Judgement=-1;Chaos=-1;
			break;
		case 10: 
			ClassName="Elfaji";Embodiment=3;Reflex=-3;Resilience=3;Strength=2;Speed=2;Dexterity=4;Influence=-4;Focus=-2;Mockery=2;Knowledge=-3;Elocution=-2;Intellect=-3;Malevolent=1;Unmerciful=0;Rage=0;Phase=0;Momentum=1;Balance=3;Luck=-2;Perception=1;Judgement=0;Chaos=-3;
			break;
		case 11: 
			ClassName="Trolki";Embodiment=4;Reflex=0;Resilience=6;Strength=3;Speed=1;Dexterity=-2;Influence=-3;Focus=0;Mockery=0;Knowledge=-3;Elocution=-3;Intellect=-3;Malevolent=1;Unmerciful=-1;Rage=-1;Phase=1;Momentum=4;Balance=0;Luck=-2;Perception=0;Judgement=0;Chaos=-2;	
			break;
		case 12: 
			ClassName="Berzki";Embodiment=-2;Reflex=-3;Resilience=3;Strength=3;Speed=5;Dexterity=5;Influence=-3;Focus=-4;Mockery=-1;Knowledge=-2;Elocution=-3;Intellect=2;Malevolent=-1;Unmerciful=1;Rage=1;Phase=-1;Momentum=2;Balance=2;Luck=-3;Perception=1;Judgement=0;Chaos=-2;
			break;
		case 13: 
			ClassName="Hor";Embodiment=0;Reflex=0;Resilience=0;Strength=0;Speed=0;Dexterity=0;Influence=0;Focus=0;Mockery=0;Knowledge=0;Elocution=0;Intellect=0;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=0;Balance=0;Luck=0;Perception=1;Judgement=-1;Chaos=0;	
			break;
		case 14: 
			ClassName="Ana";Embodiment=-3;Reflex=-1;Resilience=-4;Strength=-2;Speed=-4;Dexterity=-3;Influence=2;Focus=2;Mockery=3;Knowledge=3;Elocution=2;Intellect=2;Malevolent=2;Unmerciful=1;Rage=0;Phase=0;Momentum=2;Balance=3;Luck=-3;Perception=0;Judgement=0;Chaos=-2;	
			break;
		case 15: 
			ClassName="Akep";Embodiment=3;Reflex=2;Resilience=3;Strength=2;Speed=3;Dexterity=2;Influence=-2;Focus=-3;Mockery=-3;Knowledge=-3;Elocution=-2;Intellect=-2;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=2;Balance=-1;Luck=0;Perception=0;Judgement=-1;Chaos=0;	
			break;
		case 16: 
			ClassName="Spectrum";Embodiment=-7;Reflex=-4;Resilience=-4;Strength=-3;Speed=-3;Dexterity=-2;Influence=5;Focus=5;Mockery=6;Knowledge=2;Elocution=4;Intellect=3;Malevolent=-1;Unmerciful=-1;Rage=0;Phase=0;Momentum=-5;Balance=4;Luck=3;Perception=-2;Judgement=-1;Chaos=1;	
			break;
		case 17: 
			ClassName="Parisi";Embodiment=2;Reflex=3;Resilience=4;Strength=2;Speed=3;Dexterity=2;Influence=-3;Focus=-3;Mockery=-3;Knowledge=-2;Elocution=-2;Intellect=-3;Malevolent=0;Unmerciful=0;Rage=0;Phase=0;Momentum=3;Balance=2;Luck=-10;Perception=-3;Judgement=-3;Chaos=11;
			break;
		case 18: 
			ClassName="Rex";Embodiment=1;Reflex=2;Resilience=0;Strength=1;Speed=2;Dexterity=1;Influence=-1;Focus=-2;Mockery=-1;Knowledge=-1;Elocution=0;Intellect=-1;Malevolent=-1;Unmerciful=0;Rage=0;Phase=0;Momentum=2;Balance=4;Luck=-6;Perception=-3;Judgement=-1;Chaos=4;	
			break;


		}
	}
}

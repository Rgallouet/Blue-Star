using UnityEngine;
using System.Collections;

public class StatAllocation{



	public int[] primaryPointsToAllocate = new int[14];
	public int[] heroicPointsToAllocate = new int[2];
	public int[] secondaryPointsToAllocate = new int[6];

	private int[] primaryPointsMinimum = new int[14];
	private int[] heroicPointsMinimum = new int[2];
	private int[] secondaryPointsMinimum = new int[6];

	private bool[] primaryStatSelections = new bool[14];
	private bool[] heroicStatSelections = new bool[2];
	private bool[] secondaryStatSelections = new bool[6];


	public int primaryStatPointsToAllocate;
	public int heroicStatPointsToAllocate;
	public int secondaryStatPointsToAllocate;

	public bool didRunOnce=false;





	public void DisplayStatAllocationModule(){

		if (!didRunOnce) {
			RetrieveStatBaseStatPoints ();
			didRunOnce=true;
		}

		DisplayStatToggleSwitches();
		DisplayStatIncreaseDecreaseButtons ();
	}





	private void DisplayStatToggleSwitches(){

		// Display primary stats
		for (int i=0; i<primaryStatNames.Length; i++) {

			primaryStatSelections[i]=GUI.Toggle (new Rect(100,30*i+70,80,30),primaryStatSelections[i],primaryStatNames[i]);

			GUI.Label (new Rect(190,30*i+70,30,30), primaryPointsToAllocate[i].ToString ());

			if(primaryStatSelections[i]) {
				GUI.Label (new Rect(340,30*i+70,Screen.width-440,40), primaryStatDescriptions[i]);
				GUI.Label (new Rect(340,30*i+85,Screen.width-440,40), primaryStatEffect[i]);
			}
		}

		// Display heroic stats
		for (int i=0; i<heroicStatNames.Length; i++) {
			int j=i+primaryStatNames.Length;
			heroicStatSelections[i]=GUI.Toggle (new Rect(100,30*j+70,80,30),heroicStatSelections[i],heroicStatNames[i]);
			GUI.Label (new Rect(190,30*j+70,30,30), heroicPointsToAllocate[i].ToString ());
			
			if(heroicStatSelections[i]) {
				GUI.Label (new Rect(340,30*j+70,Screen.width-440,40), heroicStatDescriptions[i]);
				GUI.Label (new Rect(340,30*j+85,Screen.width-440,40), heroicStatEffect[i]);

			}
		}

		// Display Secondary stats
		for (int i=0; i<secondaryStatNames.Length; i++) {
			int j=i+primaryStatNames.Length+heroicStatNames.Length;
			secondaryStatSelections[i]=GUI.Toggle (new Rect(100,30*j+70,80,30),secondaryStatSelections[i],secondaryStatNames[i]);
			GUI.Label (new Rect(190,30*j+70,30,30), secondaryPointsToAllocate[i].ToString ());
			
			if(secondaryStatSelections[i]) {
				GUI.Label (new Rect(340,30*j+70,Screen.width-440,40), secondaryStatDescriptions[i]);
				GUI.Label (new Rect(340,30*j+85,Screen.width-440,40), secondaryStatEffect[i]);
			}
		}

	}

	private void DisplayStatIncreaseDecreaseButtons(){


		// display + and - for primary stats
		for (int i=0; i<primaryStatNames.Length; i++) {
			if (primaryStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * i + 65, 30, 30), "+")) {
					++primaryPointsToAllocate[i];
					--primaryStatPointsToAllocate;
				}
			}
			if (primaryPointsToAllocate[i]-primaryPointsMinimum[i]>0) {
				if (GUI.Button (new Rect (230, 30 * i + 65, 30, 30), "-")) {
					--primaryPointsToAllocate[i];
					++primaryStatPointsToAllocate;
			}
			}
		}

		// display + and - for heroic stats

		for (int i=0; i<heroicStatNames.Length; i++) {
			int j=i+primaryStatNames.Length;
			if (heroicStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * j + 65, 30, 30), "+")) {
					++heroicPointsToAllocate[i];
					--heroicStatPointsToAllocate;
				}
			}
			if (heroicPointsToAllocate[i]-heroicPointsMinimum[i]>-1) {
				if (GUI.Button (new Rect (230, 30 * j + 65, 30, 30), "-")) {
					--heroicPointsToAllocate[i];
					++heroicStatPointsToAllocate;
				}
			}
		}

		// display + and - for secondary stats

		for (int i=0; i<secondaryStatNames.Length; i++) {
			int j=i+primaryStatNames.Length+heroicStatNames.Length;
			if (secondaryStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * j + 65, 30, 30), "+")) {
					++secondaryPointsToAllocate[i];
					--secondaryStatPointsToAllocate;
				}
			}
			if (secondaryPointsToAllocate[i]-secondaryPointsMinimum[i]>0) {
				if (GUI.Button (new Rect (230, 30 * j + 65, 30, 30), "-")) {
					--secondaryPointsToAllocate[i];
					++secondaryStatPointsToAllocate;
				}
			}
		}



	}










	private void RetrieveStatBaseStatPoints(){


		primaryStatPointsToAllocate = GameInformation.basePlayer.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = GameInformation.basePlayer.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = GameInformation.basePlayer.SecondaryStatPointsToAllocate;


		// Initiation des stats allouées
		primaryPointsToAllocate[0] = GameInformation.basePlayer.Strength;
		primaryPointsMinimum[0] = GameInformation.basePlayer.Strength;
		primaryPointsToAllocate[1] = GameInformation.basePlayer.Speed;
		primaryPointsMinimum[1] = GameInformation.basePlayer.Speed;
		primaryPointsToAllocate[2] = GameInformation.basePlayer.Dexterity;
		primaryPointsMinimum[2] = GameInformation.basePlayer.Dexterity;
		primaryPointsToAllocate[3] = GameInformation.basePlayer.Embodiment;
		primaryPointsMinimum[3] = GameInformation.basePlayer.Embodiment;
		primaryPointsToAllocate[4] = GameInformation.basePlayer.Reflex;
		primaryPointsMinimum[4] = GameInformation.basePlayer.Reflex;
		primaryPointsToAllocate[5] = GameInformation.basePlayer.Resilience;
		primaryPointsMinimum[5] = GameInformation.basePlayer.Resilience;
		primaryPointsToAllocate[6] = GameInformation.basePlayer.Knowledge;
		primaryPointsMinimum[6] = GameInformation.basePlayer.Knowledge;
		primaryPointsToAllocate[7] = GameInformation.basePlayer.Elocution;
		primaryPointsMinimum[7] = GameInformation.basePlayer.Elocution;
		primaryPointsToAllocate[8] = GameInformation.basePlayer.Intellect;
		primaryPointsMinimum[8] = GameInformation.basePlayer.Intellect;
		primaryPointsToAllocate[9] = GameInformation.basePlayer.Influence;
		primaryPointsMinimum[9] = GameInformation.basePlayer.Influence;
		primaryPointsToAllocate[10] = GameInformation.basePlayer.Focus;
		primaryPointsMinimum[10] = GameInformation.basePlayer.Focus;
		primaryPointsToAllocate[11] = GameInformation.basePlayer.Mockery;
		primaryPointsMinimum[11] = GameInformation.basePlayer.Mockery;
		primaryPointsToAllocate[12] = GameInformation.basePlayer.Malevolant;
		primaryPointsMinimum[12] = GameInformation.basePlayer.Malevolant;
		primaryPointsToAllocate[13] = GameInformation.basePlayer.Unmerciful;
		primaryPointsMinimum[13] = GameInformation.basePlayer.Unmerciful;

		heroicPointsToAllocate[0] = GameInformation.basePlayer.Rage;
		heroicPointsMinimum[0] = GameInformation.basePlayer.Rage;
		heroicPointsToAllocate[1] = GameInformation.basePlayer.Phase;
		heroicPointsMinimum[1] = GameInformation.basePlayer.Phase;

		secondaryPointsToAllocate[0] = GameInformation.basePlayer.Momentum;
		secondaryPointsMinimum[0] = GameInformation.basePlayer.Momentum;
		secondaryPointsToAllocate[1] = GameInformation.basePlayer.Balance;
		secondaryPointsMinimum[1] = GameInformation.basePlayer.Balance;
		secondaryPointsToAllocate[2] = GameInformation.basePlayer.Luck;
		secondaryPointsMinimum[2] = GameInformation.basePlayer.Luck;
		secondaryPointsToAllocate[3] = GameInformation.basePlayer.Perception;
		secondaryPointsMinimum[3] = GameInformation.basePlayer.Perception;
		secondaryPointsToAllocate[4] = GameInformation.basePlayer.Judgement;
		secondaryPointsMinimum[4] = GameInformation.basePlayer.Judgement;
		secondaryPointsToAllocate[5] = GameInformation.basePlayer.Chaos;
		secondaryPointsMinimum[5] = GameInformation.basePlayer.Chaos;

		}
	



	public void StoreStatAllocation(){
		
		GameInformation.basePlayer.PrimaryStatPointsToAllocate=		primaryStatPointsToAllocate;
		GameInformation.basePlayer.HeroicStatPointsToAllocate=		heroicStatPointsToAllocate;
		GameInformation.basePlayer.SecondaryStatPointsToAllocate=	secondaryStatPointsToAllocate;



		GameInformation.basePlayer.Strength = 		primaryPointsToAllocate[0];
		GameInformation.basePlayer.Speed = 			primaryPointsToAllocate[1];
		GameInformation.basePlayer.Dexterity = 		primaryPointsToAllocate[2];
		GameInformation.basePlayer.Embodiment = 	primaryPointsToAllocate[3];
		GameInformation.basePlayer.Reflex = 		primaryPointsToAllocate[4];
		GameInformation.basePlayer.Resilience = 	primaryPointsToAllocate[5];
		GameInformation.basePlayer.Knowledge = 		primaryPointsToAllocate[6];
		GameInformation.basePlayer.Elocution = 		primaryPointsToAllocate[7];
		GameInformation.basePlayer.Intellect = 		primaryPointsToAllocate[8];
		GameInformation.basePlayer.Influence =		primaryPointsToAllocate[9];
		GameInformation.basePlayer.Focus =			primaryPointsToAllocate[10];
		GameInformation.basePlayer.Mockery = 		primaryPointsToAllocate[11];
		GameInformation.basePlayer.Malevolant = 	primaryPointsToAllocate[12];
		GameInformation.basePlayer.Unmerciful = 	primaryPointsToAllocate[13];

		GameInformation.basePlayer.Rage = 			heroicPointsToAllocate[0];
		GameInformation.basePlayer.Phase = 			heroicPointsToAllocate[1];

		GameInformation.basePlayer.Momentum = 		secondaryPointsToAllocate[0];
		GameInformation.basePlayer.Balance = 		secondaryPointsToAllocate[1];
		GameInformation.basePlayer.Luck = 			secondaryPointsToAllocate[2];
		GameInformation.basePlayer.Perception = 	secondaryPointsToAllocate[3];
		GameInformation.basePlayer.Judgement = 		secondaryPointsToAllocate[4];
		GameInformation.basePlayer.Chaos = 			secondaryPointsToAllocate[5];
	}








	}


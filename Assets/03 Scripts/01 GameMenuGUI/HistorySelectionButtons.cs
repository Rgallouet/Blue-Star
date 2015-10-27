using UnityEngine;
using System.Collections;

public class HistorySelectionButtons : MonoBehaviour {

	public static Canvas HistorySelection;

	public static PlayerHistoryStep currentStep;
	public enum PlayerHistoryStep{HELLCIRCLE,GENUS,SPECIES,CLASS,ASTRO,ORIGIN,TEMPER,AFFINITY}

	public int HistoryChoice;


	// Use this for initialization
	void Start () {
		HistorySelection = GetComponent<Canvas>();
		HistorySelection.enabled = false;
	}

	public void choice_1(){HistoryChoice = 1;}
	public void choice_2(){HistoryChoice = 2;}
	public void choice_3(){HistoryChoice = 3;}
	public void choice_4(){HistoryChoice = 4;}
	public void choice_5(){HistoryChoice = 5;}
	public void choice_6(){HistoryChoice = 6;}
	public void choice_7(){HistoryChoice = 7;}
	public void choice_8(){HistoryChoice = 8;}
	public void choice_9(){HistoryChoice = 9;}	


}

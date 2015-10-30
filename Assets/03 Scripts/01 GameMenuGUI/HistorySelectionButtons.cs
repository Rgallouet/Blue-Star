using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistorySelectionButtons : MonoBehaviour {

	public static Canvas HistorySelection;

	public static PlayerHistoryStep currentStep;
	public enum PlayerHistoryStep{HELLCIRCLE,GENUS,SPECIES,CLASS,ORIGIN,TEMPER,ASTRO,AFFINITY}

	public static int HistoryChoice;

	public static GridLayoutGroup Panel;

	public static Button Choice1 ;
	public static Button Choice2 ;
	public static Button Choice3 ;
	public static Button Choice4 ;
	public static Button Choice5 ;
	public static Button Choice6 ;
	public static Button Choice7 ;
	public static Button Choice8 ;
	public static Button Choice9 ;



	// Use this for initialization
	void Start () {
		currentStep = PlayerHistoryStep.HELLCIRCLE;
		HistorySelection = GetComponent<Canvas>();
		Panel=HistorySelection.GetComponentInChildren<GridLayoutGroup> ();
		Choice1 = Panel.GetComponentsInChildren<Button>()[0];
		Choice2 = Panel.GetComponentsInChildren<Button>()[1];
		Choice3 = Panel.GetComponentsInChildren<Button>()[2];
		Choice4 = Panel.GetComponentsInChildren<Button>()[3];
		Choice5 = Panel.GetComponentsInChildren<Button>()[4];
		Choice6 = Panel.GetComponentsInChildren<Button>()[5];
		Choice7 = Panel.GetComponentsInChildren<Button>()[6];
		Choice8 = Panel.GetComponentsInChildren<Button>()[7];
		Choice9 = Panel.GetComponentsInChildren<Button>()[8];

		GetHellCircleButtons ();
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


















	public static void GetHellCircleButtons() {

		if (MenuGUI.lastActionWasNext == false) {
			Choice7.gameObject.SetActive(true);
			Choice8.gameObject.SetActive(true);
			Choice9.gameObject.SetActive(true);
		}

		Choice1.GetComponentInChildren<Text>().text = "Limbo town";
		Choice2.GetComponentInChildren<Text>().text = "Lust village";
		Choice3.GetComponentInChildren<Text>().text = "Gluttonbourg";
		Choice4.GetComponentInChildren<Text>().text = "Greedpolis";
		Choice5.GetComponentInChildren<Text>().text = "Capanger";
		Choice6.GetComponentInChildren<Text>().text = "Heresynia";
		Choice7.GetComponentInChildren<Text>().text = "Violocanto";
		Choice8.GetComponentInChildren<Text>().text = "Bolgiafraudis";
		Choice9.GetComponentInChildren<Text>().text = "Traitor's hideout";
	}

	public static void GetGenusButtons() {
		if (MenuGUI.lastActionWasNext == false) {
			Choice4.gameObject.SetActive(true);
			Choice5.gameObject.SetActive(true);
			Choice6.gameObject.SetActive (true);
		}

		Choice1.GetComponentInChildren<Text>().text = "Demono";
		Choice2.GetComponentInChildren<Text>().text = "Angelum";
		Choice3.GetComponentInChildren<Text>().text = "Celticus";
		Choice4.GetComponentInChildren<Text>().text = "Nordi";
		Choice5.GetComponentInChildren<Text>().text = "Nyla";
		Choice6.GetComponentInChildren<Text>().text = "Homo";

		Choice7.gameObject.SetActive(false);
		Choice8.gameObject.SetActive(false);
		Choice9.gameObject.SetActive(false);


	}


	public static void GetSpeciesButtons() {


		if (MenuGUI.lastActionWasNext == false) {
			Choice7.gameObject.SetActive(false);
			Choice8.gameObject.SetActive(false);
			Choice9.gameObject.SetActive(false);
		}

		if (MenuGUI.genusSelection == 1) {
			Choice1.GetComponentInChildren<Text>().text = "Hornydi";
			Choice2.GetComponentInChildren<Text>().text = "Succubi";
			Choice3.GetComponentInChildren<Text>().text = "Vampyri";
		}
		else if (MenuGUI.genusSelection == 2) {
			Choice1.GetComponentInChildren<Text>().text = "Seraph";
			Choice2.GetComponentInChildren<Text>().text = "Cherubim";
			Choice3.GetComponentInChildren<Text>().text = "Thronoi";
		}
		else if (MenuGUI.genusSelection == 3) {
			Choice1.GetComponentInChildren<Text>().text = "Ankou";
			Choice2.GetComponentInChildren<Text>().text = "Cernun";
			Choice3.GetComponentInChildren<Text>().text = "Dagmus";
		}
		else if (MenuGUI.genusSelection == 4) {
			Choice1.GetComponentInChildren<Text>().text = "Elfaji";
			Choice2.GetComponentInChildren<Text>().text = "Trolki";
			Choice3.GetComponentInChildren<Text>().text = "Berzica";
		}
		else if (MenuGUI.genusSelection == 5) {
			Choice1.GetComponentInChildren<Text>().text = "Hor";
			Choice2.GetComponentInChildren<Text>().text = "Ana";
			Choice3.GetComponentInChildren<Text>().text = "Akep";
		}
		else if (MenuGUI.genusSelection == 6) {
			Choice1.GetComponentInChildren<Text>().text = "Spectrum";
			Choice2.GetComponentInChildren<Text>().text = "Parisi";
			Choice3.GetComponentInChildren<Text>().text = "Rex";
		}

		Choice4.gameObject.SetActive(false);
		Choice5.gameObject.SetActive(false);
		Choice6.gameObject.SetActive(false);

	}

	public static void GetClassButtons() {

		if (MenuGUI.lastActionWasNext == true) {

			Choice4.gameObject.SetActive(true);
			Choice5.gameObject.SetActive(true);
			Choice6.gameObject.SetActive(true);
			Choice7.gameObject.SetActive(true);
			Choice8.gameObject.SetActive(true);
			Choice9.gameObject.SetActive(true);
		}

		Choice1.GetComponentInChildren<Text>().text = "Ripper";
		Choice2.GetComponentInChildren<Text>().text = "Butcher";
		Choice3.GetComponentInChildren<Text>().text = "Guardian";
		Choice4.GetComponentInChildren<Text>().text = "Lord";
		Choice5.GetComponentInChildren<Text>().text = "Architect";
		Choice6.GetComponentInChildren<Text>().text = "Judge";
		Choice7.GetComponentInChildren<Text>().text = "Painter";
		Choice8.GetComponentInChildren<Text>().text = "Muse";
		Choice9.GetComponentInChildren<Text>().text = "Baker";
	}

	public static void GetOriginButtons() {
		Choice1.GetComponentInChildren<Text>().text = "Monkey";
		Choice2.GetComponentInChildren<Text>().text = "Bear";
		Choice3.GetComponentInChildren<Text>().text = "Wolf";
		Choice4.GetComponentInChildren<Text>().text = "Bee";
		Choice5.GetComponentInChildren<Text>().text = "Snail";
		Choice6.GetComponentInChildren<Text>().text = "Ant";
		Choice7.GetComponentInChildren<Text>().text = "Doe";
		Choice8.GetComponentInChildren<Text>().text = "Owl";
		Choice9.GetComponentInChildren<Text>().text = "Turtle";
	}

	public static void GetTemperButtons() {
		Choice1.GetComponentInChildren<Text>().text = "Tense";
		Choice2.GetComponentInChildren<Text>().text = "Tolerant";
		Choice3.GetComponentInChildren<Text>().text = "Anxious";
		Choice4.GetComponentInChildren<Text>().text = "Moderate";
		Choice5.GetComponentInChildren<Text>().text = "Hard";
		Choice6.GetComponentInChildren<Text>().text = "Aggressive";
		Choice7.GetComponentInChildren<Text>().text = "Rebellious";
		Choice8.GetComponentInChildren<Text>().text = "Moody";
		Choice9.GetComponentInChildren<Text>().text = "Passive";
	}

	public static void GetAstroButtons() {
		Choice1.GetComponentInChildren<Text>().text = "Canis";
		Choice2.GetComponentInChildren<Text>().text = "Scuti";
		Choice3.GetComponentInChildren<Text>().text = "Cephei";
		Choice4.GetComponentInChildren<Text>().text = "Wester";
		Choice5.GetComponentInChildren<Text>().text = "Betel";
		Choice6.GetComponentInChildren<Text>().text = "Vulpe";
		Choice7.GetComponentInChildren<Text>().text = "Anta";
		Choice8.GetComponentInChildren<Text>().text = "Gemi";
		Choice9.GetComponentInChildren<Text>().text = "Cygni";
	}

	public static void GetAffinityButtons() {
		Choice1.GetComponentInChildren<Text>().text = "Organic";
		Choice2.GetComponentInChildren<Text>().text = "Light";
		Choice3.GetComponentInChildren<Text>().text = "Heat";
		Choice4.GetComponentInChildren<Text>().text = "Nuclear";
		Choice5.GetComponentInChildren<Text>().text = "Magneto";
		Choice6.GetComponentInChildren<Text>().text = "Psychic";
		Choice7.GetComponentInChildren<Text>().text = "Gravity";
		Choice8.GetComponentInChildren<Text>().text = "Cold";
		Choice9.GetComponentInChildren<Text>().text = "Shadow";
	}
}

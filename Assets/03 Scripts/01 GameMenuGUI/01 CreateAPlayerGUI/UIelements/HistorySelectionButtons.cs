using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistorySelectionButtons : MonoBehaviour {

	public static Canvas HistorySelection;

	public static PlayerHistoryStep currentStep;
	public enum PlayerHistoryStep{HELLCIRCLE,GENUS,SPECIES,CLASS,ORIGIN,TEMPER,ASTRO,AFFINITY}

	public static int HistoryChoice;
	public static GridLayoutGroup ChoiceDisplay;
	public static RectTransform ChoiceDescription;

	public static Button[] Choice = new Button[10];


	public static string[] HellCircles = new string[9] 
	{"Limbo town","Lust village","Gluttonbourg","Greedpolis","Capanger","Heresynia","Violocanto","Bolgiafraudis","Traitor's hideout"};

	public static string[] Genuses = new string[6] 
	{"Demono","Angelum","Celticus","Nordi","Nyla","Homo"};

	public static string[] Species = new string[18]
	{"Hornydi","Succubi","Vampyri","Seraph","Cherubim","Thronoi","Ankou","Cernun","Dagmus","Elfaji","Trolki","Berzica","Hor","Ana","Akep","Spectrum","Parisi","Rex"};

	public static string[] Jobs = new string[9] 
	{"Ripper","Butcher","Guardian","Lord","Architect","Judge","Painter","Muse","Baker"};

	public static string[] Origins = new string[9] 
	{"Monkey","Bear","Wolf","Bee","Snail","Ant","Doe","Owl","Turtle"};

	public static string[] DeathStates = new string[9]
	{"Lashing out","Rebellious","Sleepy","Violent","Powerlessness","Unfairness","At peace","Sleepy","Passive"};

	public static string[] Astros = new string[9]
	{"Canis","Scuti","Cephei","Wester","Betel","Vulpe","Anta","Gemi","Cygni"};

	public static string[] Affis = new string[9]
	{"Organic","Light","Heat","Nuclear","Magneto","Psychic","Gravity","Cold","Shadow"};

	

	

	void Start () {

		currentStep = PlayerHistoryStep.HELLCIRCLE;
		HistorySelection = GetComponent<Canvas>();
		ChoiceDescription=HistorySelection.GetComponentInChildren<RectTransform> ();
		ChoiceDisplay=ChoiceDescription.GetComponentInChildren<GridLayoutGroup> ();
		for (int i=0; i<9; i++) { 	Choice[i]=ChoiceDisplay.GetComponentsInChildren<Button> () [i];}
		GetHistoryUIButtons ();
		HistorySelection.enabled = false;

	}







	// Interaction with UI Buttons
	public void choice_1(){HistoryChoice = 1; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_2(){HistoryChoice = 2; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_3(){HistoryChoice = 3; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_4(){HistoryChoice = 4; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_5(){HistoryChoice = 5; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_6(){HistoryChoice = 6; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_7(){HistoryChoice = 7; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_8(){HistoryChoice = 8; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}
	public void choice_9(){HistoryChoice = 9; HistorySelection.GetComponentsInChildren<Text> () [2].text = UpdateDescription ();}	











	public static string UpdateDescription() {
		switch(currentStep){
		case PlayerHistoryStep.HELLCIRCLE: 	return(HellCircles[HistoryChoice-1]);
		case PlayerHistoryStep.GENUS:		return(Genuses[HistoryChoice-1]);
		case PlayerHistoryStep.SPECIES:		return(Species[HistoryChoice-1+3*(MenuGUI.genusSelection-1)]);
		case PlayerHistoryStep.CLASS:		return(Jobs[HistoryChoice-1]);
		case PlayerHistoryStep.ORIGIN:		return(Origins[HistoryChoice-1]);
		case PlayerHistoryStep.TEMPER:		return(DeathStates[HistoryChoice-1]);
		case PlayerHistoryStep.ASTRO:		return(Astros[HistoryChoice-1]);
		case PlayerHistoryStep.AFFINITY:	return(Affis[HistoryChoice-1]);
		default: 							return(" ");
		}
	}





	public static void GetHistoryUIButtons() {

		HistorySelection.GetComponentsInChildren<Text> () [2].text = "";

		switch(currentStep){

		case PlayerHistoryStep.HELLCIRCLE: 	

			if (MenuGUI.lastActionWasNext == false) {	for (int i=6; i<9; i++) { 	Choice[i].gameObject.SetActive(true);	}	}
			HistorySelection.GetComponentInChildren<Text> ().text = "From which one of my hell circles did you crawl from, my sweet devious child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Hell Circle Lore";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = HellCircles [i];	}
			break;

		case PlayerHistoryStep.GENUS:		

			if (MenuGUI.lastActionWasNext == false) {	for (int i=3; i<6; i++) { 	Choice[i].gameObject.SetActive(true);	}}
			HistorySelection.GetComponentInChildren<Text> ().text = "My eyes are fading... could you whisper me what's in your genes, child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Genus Lore";
			for (int i=0; i<6; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Genuses [i];	}
			for (int i=6; i<9; i++) { 	Choice[i].gameObject.SetActive(false);	}
			break;

		case PlayerHistoryStep.SPECIES:		

			if (MenuGUI.lastActionWasNext == false) {for (int i=6; i<9; i++) { 	Choice[i].gameObject.SetActive(false);	}}
			HistorySelection.GetComponentInChildren<Text> ().text = "My eyes are fading... could you whisper me what's in your genes, child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Species Lore";
			for (int i=0; i<3; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Species [3*(MenuGUI.genusSelection-1)+i];	}
			for (int i=3; i<6; i++) { 	Choice[i].gameObject.SetActive(false);	}
			break;

		case PlayerHistoryStep.CLASS:		

			if (MenuGUI.lastActionWasNext == true) {for (int i=3; i<9; i++) { 	Choice[i].gameObject.SetActive(true);	}}
			HistorySelection.GetComponentInChildren<Text> ().text = "Aah... and what did you do back in your hell circle?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Job Description";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Jobs [i];	}
			break;

		case PlayerHistoryStep.ORIGIN:		

			HistorySelection.GetComponentInChildren<Text> ().text = "Hm... That's enough of your demon life for the war register... Now, what were you before coming here?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Origin Influence";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Origins [i];	}
			break;

		case PlayerHistoryStep.TEMPER:		

			HistorySelection.GetComponentInChildren<Text> ().text = "Nice... Any specific psychologic state at your time of death?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Psychologic State";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = DeathStates [i];	}
			break;

		case PlayerHistoryStep.ASTRO:		

			HistorySelection.GetComponentInChildren<Text> ().text = "Interesting... at time of your death, what was the dominant astrological sign?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Sign Lore";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Astros [i];	}
			break;

		case PlayerHistoryStep.AFFINITY:	

			HistorySelection.GetComponentInChildren<Text> ().text = "Right...off you go then, you can meet with your lieutenant on the surface. Choose your channel up.";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Primordial Affinity";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Affis [i];	}
			break;

		}


	}







}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistorySelectionButtons : MonoBehaviour {

	public static Canvas HistorySelection;

	public static PlayerHistoryStep currentStep;
	public enum PlayerHistoryStep{HELLCIRCLE,GENUS,SPECIES,CLASS,ORIGIN,TEMPER,ASTRO,AFFINITY,END}

	public static int HistoryChoice;
	public static GridLayoutGroup ChoiceDisplay;
	public static RectTransform HistoChoiceDescription;

	public static Button[] Choice = new Button[10];


	public static string[] HellCircles = new string[9] 
	{"Limbo town","Lust hills","Gluttonbourg","Greedpolis","Capanger","Heresynia","Violocanto","Bolgiafraudis","Traitor's frostgrounds"};

	public static string[] HellCirclesDescription = new string[9]
	{"Limbo town is the capital of the first hell circle. Filled with brillant minds, pacifists and scholars of chaos, the cosmopolite Limbo town is considered as the cultural and knowledge center of hell. Situated in the most remote circle, it benefit from a decent gravity but a cold climate with a dim vegetal life. The Senate, an immaculate, transparent pentagram building, made of polished diamond towers, is its decision making organ. The Senate, opened to all, often heed the advice of unofficial triumvirate : Yrsif, Oug and Sutin with no affiliation to the great demon houses. \nPopulation: Limbo dwellers prefer cooperation and studying the non-physical perks of their existence.",
		"Ah...The windy halls of lust... a sight of wonder renowned in all hell circles. home habitat of the great flying jellyfish of the thousands red silk threads, The silvery sky can hardly be seen due to the swarm of dark red hair-looking threads hanging around. The land is abusively called halls, but only a few pillars of black marble, hundreds of meters high, are lost on an otherwise red scenery of hills. The flying jellyfish have an ever-lasting mating season, and the hills are endlessly covered with a thick layer of... juicy... wiggly... glue-like red jellyfish eggs. Broken eggs emit myst and strong chemicals that tends to disrupt inhibition function of any species known in hell. Owned by the Incubus congregation, overseer Harpoc from the house Hardy, established an hourly fee for any demons entering the region to reduce crowdness.\nPopulation: Dwellers appreciate contemplation and ... well... chemically induced physical activity...",
		"Gluttonbourg is a suburban town of the Gluttonia Megapolis, in the last region able to arbor both vegetal and animal life. Dry mud roads, little rocky houses and bushy gardens can confuse any sane-minded demon: this city entertained the human dream to its littlest details. Its mayor, Lord Butchy, is a remote member of the powerful Di Oprescu family famous for its key role in the war on the Navates species, and his finances are largely responsible for the town's architectural mimicry perfection. Quiet town with no particular history except its architecture, It is well known for its MOREMEAT burgers (mashed merguez, oyster shell, reindeer ribs, eagle's talons, marmot cheeks, eel, albatross filet and tapir based patty). \nPopulation: After eating that everyday, anyone can withstand pretty much anything",
		"Don Papa, War intendant Darras, Elvish duke Dinu l'escou, so many child demon stories that paved the way for grandeur and the rise of the bourgeoisie. Heroes of wealth, all born and raised in the underground city of Greedopolis. Cavernous dark alleys here and there on an otherwise smoky and hectic country-sized bazaar, the city is a lethal maze for any untrained adventure. Shiny boards of a million light pave the lack of sky, sparsely interrupted by casinos so high they litteraly dig back in the earth from which they rise. Greedpolis is undisputedly the oppulant Hell business center.\nClose your bags, brace yourself to the heavy gravity, and look for enemies everywhere... \nPopulation: surprise effect and independance is the only survival factor.",
		"Grey as cinder, spicky fences, edgy houses, Capanger is a silent haven for demons, situated on the edge of the DeepHollow cliff. The vast emptyness a few metters away, from which no light or sound seem to ever escape, never takes rests in a demon's mind. The sense of gravity, of time, seems always distorted in its viscinity, and an invisible, relentless, yet inexplicable feeling of pull is described by many of its inhabitants. The city is often described as being rules by the heavy emptiness that resides in its every corner.\nPopulation:Passive aggresivity is a form of politeness and the occasional heat storms tend to harden the fallen souls of the area.",
		"In the majestic swamp of Heri, a complex constellation of wooden streets and dry mud back alleys can hardly be seen in the constant heavy greenish fog. The whole city slowly moves, swim in the hungry swamp, curls who moves, rotates, curls as he pleases in his undergound swamp.\nHeriens learn to adapt their inner beliefs on a daily basis, which is easier when not having to debate on those with your moving neighbors.",
		"Violocanto, the desolate region dominated by the three concentric alluminium volcanos, is but sparsely populated. \n ",
		"Bolgiafraudis, also called the Red Fan, is an impressive vertical composition of ten vast castles made of copper, gold and red rare stones, dominating a barren desert ground. High gravity, hot and dry winds, barren waste lands and occasional acid lakes are the only features one can expect here outside the city. Ruled over by the rust dragon Maliborg and his family, the stronghold is the official Deministry of War Waging in times of invasions. Many of the highest and strongest house of hell resides in the top layers of the Red Fan. The regional laws follow the strong sense of hierarchy and military disposition put in place by the last dead dragon. \nPopulation: The highdead demons are trained to battle for invasion of physical worlds, by mastering non-physical offence skills and physical defence.",
		"The frost grounds lost its original name and purpose in times before any current walking species arrived in the hell circles. It is the closest circle, and against all expectation by far the coldest. Not a thing exist here, no wind, no stone, not even a nail dare to challenge the flatness that heavily resides there. The ground is an seamingly endless, waveless pristine mirror, an ice sea with no ripples. There is apparently nothing to do or see there, so actually no demon wants to either own it or come here. No demon is known to actually live here. \nPopulation: N/A"};




	public static string[] Genuses = new string[6] 
	{"Demono","Angelum","Celticus","Nordi","Nyla","Homo"};

	public static string[] GenusesDescription = new string[6] 
	{"Demono","Angelum","Celticus","Nordi","Nyla","Homo"};




	public static string[] Species = new string[18]
	{"Hornydi","Succubi","Vampyri","Seraph","Cherubim","Thronoi","Ankou","Cernun","Dagmus","Elfaji","Trolki","Berzica","Hor","Ana","Akep","Spectrum","Parisi","Rex"};

	public static string[] SpeciesDescription = new string[18]
	{"Hornydi","Succubi","Vampyri","Seraph","Cherubim","Thronoi","Ankou","Cernun","Dagmus","Elfaji","Trolki","Berzica","Hor","Ana","Akep","Spectrum","Parisi","Rex"};





	public static string[] Jobs = new string[9] 
	{"Ripper","Butcher","Guardian","Lord","Architect","Judge","Painter","Muse","Baker"};

	public static string[] JobsDescription = new string[9] 
	{"Ripper","Butcher","Guardian","Lord","Architect","Judge","Painter","Muse","Baker"};




	public static string[] Origins = new string[9] 
	{"Monkey","Bear","Wolf","Bee","Snail","Ant","Doe","Owl","Turtle"};

	public static string[] OriginsDescription = new string[9] 
	{"Monkey","Bear","Wolf","Bee","Snail","Ant","Doe","Owl","Turtle"};




	public static string[] DeathStates = new string[9]
	{"Lashing out","Rebellious","Sleepy","Violent","Powerlessness","Unfairness","At peace","Sleepy","Passive"};

	public static string[] DeathStatesDescription = new string[9]
	{"Lashing out","Rebellious","Sleepy","Violent","Powerlessness","Unfairness","At peace","Sleepy","Passive"};





	public static string[] Astros = new string[9]
	{"Canis","Scuti","Cephei","Wester","Betel","Vulpe","Anta","Gemi","Cygni"};

	public static string[] AstrosDescription = new string[9]
	{"Canis","Scuti","Cephei","Wester","Betel","Vulpe","Anta","Gemi","Cygni"};




	public static string[] Affis = new string[9]
	{"Organic","Light","Heat","Nuclear","Magneto","Psychic","Gravity","Cold","Shadow"};

	public static string[] AffisDescription = new string[9]
	{"Organic","Light","Heat","Nuclear","Magneto","Psychic","Gravity","Cold","Shadow"};

	

	

	void Start () {

		currentStep = PlayerHistoryStep.HELLCIRCLE;
		HistorySelection = GetComponent<Canvas>();
		HistoChoiceDescription=HistorySelection.GetComponentInChildren<RectTransform> ();
		ChoiceDisplay=HistoChoiceDescription.GetComponentInChildren<GridLayoutGroup> ();
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
		case PlayerHistoryStep.HELLCIRCLE: 	return(HellCirclesDescription[HistoryChoice-1]);
		case PlayerHistoryStep.GENUS:		return(GenusesDescription[HistoryChoice-1]);
		case PlayerHistoryStep.SPECIES:		return(SpeciesDescription[HistoryChoice-1+3*(MenuGUI.genusSelection-1)]);
		case PlayerHistoryStep.CLASS:		return(JobsDescription[HistoryChoice-1]);
		case PlayerHistoryStep.ORIGIN:		return(OriginsDescription[HistoryChoice-1]);
		case PlayerHistoryStep.TEMPER:		return(DeathStatesDescription[HistoryChoice-1]);
		case PlayerHistoryStep.ASTRO:		return(AstrosDescription[HistoryChoice-1]);
		case PlayerHistoryStep.AFFINITY:	return(AffisDescription[HistoryChoice-1]);
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

			HistorySelection.GetComponentInChildren<Text> ().text = "Right... and from which channel are you planning on passing to the surface?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Primordial Affinity";
			for (int i=0; i<9; i++) { 	Choice[i].GetComponentInChildren<Text> ().text = Affis [i];	}
			break;

		}


	}







}

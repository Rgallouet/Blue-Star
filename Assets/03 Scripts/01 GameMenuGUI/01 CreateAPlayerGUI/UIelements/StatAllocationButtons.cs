using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatAllocationButtons : MonoBehaviour {

	public MenuGUI menuGUI;

	public static Canvas StatAllocationMenu;

	public static Text[] PrimaryNumbers = new Text[14];
	public static Text[] HeroicNumbers = new Text[2];
	public static Text[] SecondaryNumbers = new Text[6];
	public static Text[] PointsToAlloc = new Text[3];

	public static Button[] PrimaryPlus = new Button[14];
	public static Button[] HeroicPlus = new Button[2];
	public static Button[] SecondaryPlus = new Button[6];

	public static Button[] PrimaryMinus = new Button[14];
	public static Button[] HeroicMinus = new Button[2];
	public static Button[] SecondaryMinus = new Button[6];

	public static Text DescriptionHead;
	public static Text DescriptionBody;



	// Primary stats
	private string[] primaryStatNames = new string[14] 
	{"Strength","Speed","Dexterity","Embodiment","Reflex","Resilience","Knowledge","Elocution","Intellect","Influence","Focus","Mockery ","Malevolant","Unmerciful"};
	
	private string[] primaryStatDescriptions = new string[14] 
	{	"When your battleaxe penetrates your enemy's brestplate, your strength tends to limit the number of rib bones you shatter in your wake. \n Remember: the more, the merrier!",
		"If the first slap on a human doesn't get you where you wanted, try a second. \nDouble tap is the way",
		"These evasive schieming little humans dancing around can drive any decent demon mad... \nJust a tip: aim right between the legs, that trick actually - never - misses!",
		"The more tangible in human's mind you can get, the harder it will be for them to cast you out...",
		"'Stick them with the pointy end!' is what they teach their kids... \nYes, seriously, they do teach that... \nWell, I'd be you, I'd try to make that pointy end pointing at something else than your face...",
		"Remember that speech about the pointy end? \nRemember: your putrefied lungs or your dead hearts ain't the best 'second' choice either...",
		"Always best to remember the difference between that chicken soup spell and the meteor one, that quite makes the good difference in the battlefield... \nWell, i guess in the kitchen aswell.",
		"A good demon wizard never misses on his daily elocution exercices. \nTry after me as fast as you can: \n'Imagine an imaginary menagerie manager imagining managing an imaginary menagerie'!",
		"For a fireball to accurately blast someone's head, you've got to guess where that head's going in the next 2 seconds... \nthat sadly requires some brain function.",
		"We're not on this planet for sight-seeing... we've got some havoc to wreck! \nThe more influence on the physical plane you have, the more you'll make things go boom!",
		"Demons and belief are somewhat connected, and that can have some perks. \nDid you know that if you concentrate, you can disbelief something enough to make it actually disapear? \nthat works for fireballs and most similar things! \nP.S: By the way, that works on you too, so try really hard not to loose faith in yourself...",
		"What would be a good old lost faith without some well placed mockery and cynical attitude? \ntry this next time : if you verbally bully that iceball coming to your head, I'm sure it will shamely run away.",
		"Remember, being part of the older demons requires some parenthood skills. \nTry to teach some violence in your angelic spawns for a start.",
		"If you want your frail and spoiled little spawns to survive in the human wilderness, you've got to teach them the hard way to survive."};
	
	private string[] primaryStatEffect = new string[14] 
	{"(Physical) Increase critical damage",
		"(Physical) Increase attack speed",
		"(Physical) Increase hit rate",
		"(Physical) Amount of recievable damage before death",
		"(Physical) Increase deflect rate",
		"(Physical) Increase deflected damage ratio",
		"(Non-Physical) Increase critical damage",
		"(Non-Physical) Increase casting speed",
		"(Non-Physical) Increase hit rate",
		"(Non-Physical) Amount of available energy",
		"(Non-Physical) Increase resist rate",
		"(Non-Physical) Increase resisted damage ratio",
		"(Leadership) Increase minions damage",
		"(Leadership) Increase minions resistance"};
	
	// Heroic stats
	private string[] heroicStatNames = new string[2] 
	{"Rage","Phase"};
	
	private string[] heroicStatDescriptions = new string[2] 
	{"Come on, child. You're not making it fun enough... \nShow me your teeth, let the blood bath begin! ",
		"The mastery of your half-plane existence is simply full of shortcuts. \nGuess what, if you're good enough at that, you can just 'deny' anything bad happening to you."};
	
	private string[] heroicStatEffect = new string[2] 
	{"(Heroic) Increase all critical chances",
		"(Heroic) Increase denial of all damage rate"};
	
	// Secondary stats
	
	private string[] secondaryStatNames = new string[6] 
	{"Momentum","Balance","Luck","Perception","Judgement","Chaos"};
	
	private string[] secondaryStatDescriptions = new string[6] 
	{"Lesson on Human Castle attack 101 : \nFirst, find a rock. Now, throw very hard the rock on the human stone wall. \nLook what happened... \nIf it didn't work: find a bigger rock. Repeat.",
		"I know you like chicken. \nSo if you want to roast it, you'll have to run fast, 'cause no one is getting it for you.",
		"You tend to have a very keen eye on finding human craps no one truely cares",
		"Humans have so many pockets and layers of clothes, that can be very confusing at times...",
		"Sharp pointy end? Good. \nWet stuff with bunnies and dinosaures? Bad.",
		"You've got to teach these humans the second law of thermodynamics. They tend to forget too easily..."};
	
	private string[] secondaryStatEffect = new string[6] 
	{"(Secondary) Reduce crowd control effects",
		"(Secondary) Increase running speed",
		"(Secondary) Increase human crap amount in loot",
		"(Secondary) Increase average number of items found in loot",
		"(Secondary) Increase average rarity of items found in loot",
		"(Secondary) Increase chances of additional random effects on actions"};







	void Awake(){
		StatAllocationMenu = GetComponent<Canvas>();
			
		for (int i=0; i<6; i++)		{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+1];}
		for (int i=6; i<12; i++)	{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+2];}
		for (int i=12; i<14; i++)	{ PrimaryNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+3];}
		for (int i=0; i<2; i++) 	{ HeroicNumbers [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+14+4];}
		for (int i=0; i<6; i++) 	{ SecondaryNumbers [i] = 	StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+16+5];}
		for (int i=0; i<3; i++) 	{ PointsToAlloc [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [5].GetComponentsInChildren<Text> () [i+29];}

		for (int i=0; i<6; i++)		{ PrimaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [6].GetComponentsInChildren<Button> () [i];}
		for (int i=6; i<12; i++)	{ PrimaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [7].GetComponentsInChildren<Button> () [i-6];}
		for (int i=12; i<14; i++)	{ PrimaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [8].GetComponentsInChildren<Button> () [i-12];}
		for (int i=0; i<2; i++) 	{ HeroicPlus [i] = 			StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [9].GetComponentsInChildren<Button> () [i];}
		for (int i=0; i<6; i++) 	{ SecondaryPlus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [10].GetComponentsInChildren<Button> ()[i];}

		for (int i=0; i<6; i++)		{ PrimaryMinus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [0].GetComponentsInChildren<Button> () [i];}
		for (int i=6; i<12; i++)	{ PrimaryMinus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [1].GetComponentsInChildren<Button> () [i-6];}
		for (int i=12; i<14; i++)	{ PrimaryMinus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [2].GetComponentsInChildren<Button> () [i-12];}
		for (int i=0; i<2; i++) 	{ HeroicMinus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [3].GetComponentsInChildren<Button> () [i];}
		for (int i=0; i<6; i++) 	{ SecondaryMinus [i] = 		StatAllocationMenu.GetComponentsInChildren<GridLayoutGroup> () [4].GetComponentsInChildren<Button> () [i];}


		DescriptionHead = GameObject.FindGameObjectWithTag("LoreDisplayHead").GetComponentInChildren<Text> ();
		DescriptionBody = GameObject.FindGameObjectWithTag("LoreDisplayComment").GetComponentInChildren<Text> ();
	

		StatAllocationMenu.enabled = false;

	}




	// Interaction with UI Buttons
	public void DisplayStat(int WhichButton){

		if (WhichButton < 14) {
			DescriptionHead.text = primaryStatNames [WhichButton] + " Description"; 
			DescriptionBody.text = "<i>" + primaryStatEffect [WhichButton] + "</i> \n\n" + primaryStatDescriptions [WhichButton];
		} else if (WhichButton > 13 && WhichButton < 16) {
			DescriptionHead.text = heroicStatNames[WhichButton-14]+" Description"; 
			DescriptionBody.text ="<i>"+heroicStatEffect[WhichButton-14]+"</i> \n\n"+heroicStatDescriptions[WhichButton-14];
		} else if (WhichButton > 16) {
			DescriptionHead.text = secondaryStatNames[WhichButton-16]+" Description"; 
			DescriptionBody.text ="<i>"+secondaryStatEffect[WhichButton-16]+"</i> \n\n"+secondaryStatDescriptions[WhichButton-16];
		}

	}



	public void CallPlusStat(int Stat_ID){
		MenuGUI.CallStatAllocationMoveStat (true, Stat_ID);
	}

	public void CallMinusStat(int Stat_ID){
		MenuGUI.CallStatAllocationMoveStat (false, Stat_ID);
	}




	
	
}

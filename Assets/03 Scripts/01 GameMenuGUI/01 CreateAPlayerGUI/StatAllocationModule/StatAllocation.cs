using UnityEngine;
using System.Collections;

public class StatAllocation{



	// Primary stats
	private string[] primaryStatNames = new string[14] 
		{"Strength","Speed","Dexterity","Embodiment","Reflex","Resilience","Knowledge","Elocution","Intellect","Influence","Focus","Mockery ","Malevolant","Unmerciful"};
	
	private string[] primaryStatDescriptions = new string[14] 
	{	"When your battleaxe penetrates your enemy's brestplate, your strength tends to limit the number of rib bones you shatter in your wake. Remember: the more, the merrier!",
		"If the first slap on a human doesn't get you where you wanted, try a second. Double tap is the way",
		"These evasive schieming little humans dancing around can drive any decent demon mad... Just a tip: aim right between the legs, that trick actually - never - misses!",
		"The more tangible in human's mind you can get, the harder it will be for them to cast you out...",
		"'Stick them with the pointy end!' is what they teach their kids... Yes, seriously, they do... Well, I'd be you, I'd try to make that pointy end pointing at something else than your face...",
		"Remember that speech about the pointy end? well, your putrefied lungs or your dead hearts ain't the best second choice either.",
		"Always best to remember the difference between that chicken soup spell and the meteor one, that quite makes the good difference in the battlefield... Well, i guess in the kitchen aswell.",
		"A good demon wizard never misses on his daily elocution exercices. Try after me as fast as you can: 'Imagine an imaginary menagerie manager imagining managing an imaginary menagerie'!",
		"For a fireball to accurately blast someone's head, you've got to guess where that head's going in the next 2 seconds... that sadly requires some brain function.",
		"We're not on this planet for sight-seeing... we've got some havoc to wreck! The more influence on the physical plane you have, the more you'll make things go boom!",
		"Demons and belief are somewhat connected, and that can have some perks. Did you know that if you concentrate, you can disbelief something enough to make it actually disapear? that works for fireballs and most similar things! P.S: By the way, that works on you too, so try really hard not to loose faith in yourself...",
		"What would be a good old lost faith without some well placed mockery and cynical attitude? try this next time : if you verbally bully that iceball coming to your head, I'm sure it will shamely run away.",
		"Remember, being part of the older demons requires some parenthood skills. Try to teach some violence in your angelic spawn for a start.",
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
	{"Come on, child. You're not making it fun enough... Give me a bit of your inner fuel, let the blood bath begin! ",
	"The mastery of your half-plane existence is simply full of perks. Guess what, you can just deny anything bad that happens to you."};

	private string[] heroicStatEffect = new string[2] 
	{"(Heroic) Increase all critical chances",
	"(Heroic) Increase denial of all damage rate"};

	// Secondary stats

	private string[] secondaryStatNames = new string[6] 
	{"Momentum","Balance","Luck","Perception","Judgement","Chaos"};

	private string[] secondaryStatDescriptions = new string[6] 
	{"Lesson on Human Castle attack 101 : First find a rock, then throw very hard the rock on the human stone wall. If it doesn't work, find a bigger rock and repeat.",
	"I know you like chicken. So if you want to roast it, you'll have to run fast, 'cause no one is getting it for you.",
	"You tend to have a very keen eye on finding human craps no one truely cares",
	"Humans have so many pockets and layers of clothes, that's very confusing...",
	"Pointy end? good. Wet stuff with bunnies and dinosaures? Bad.",
	"You've got to teach these humans the second law of thermodynamics. They tend to forget too easily..."};

	private string[] secondaryStatEffect = new string[6] 
	{"(Secondary) Reduce crowd control effects",
	"(Secondary) Increase running speed",
	"(Secondary) Increase human crap amount in loot",
	"(Secondary) Increase average number of items found in loot",
	"(Secondary) Increase average rarity of items found in loot",
	"(Secondary) Increase chances of additional random effects on actions"};


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
		primaryPointsToAllocate[3] = GameInformation.basePlayer.Reflex;
		primaryPointsMinimum[3] = GameInformation.basePlayer.Reflex;
		primaryPointsToAllocate[4] = GameInformation.basePlayer.Resilience;
		primaryPointsMinimum[4] = GameInformation.basePlayer.Resilience;
		primaryPointsToAllocate[5] = GameInformation.basePlayer.Knowledge;
		primaryPointsMinimum[5] = GameInformation.basePlayer.Knowledge;
		primaryPointsToAllocate[6] = GameInformation.basePlayer.Elocution;
		primaryPointsMinimum[6] = GameInformation.basePlayer.Elocution;
		primaryPointsToAllocate[7] = GameInformation.basePlayer.Intellect;
		primaryPointsMinimum[7] = GameInformation.basePlayer.Intellect;
		primaryPointsToAllocate[8] = GameInformation.basePlayer.Focus;
		primaryPointsMinimum[8] = GameInformation.basePlayer.Focus;
		primaryPointsToAllocate[9] = GameInformation.basePlayer.Mockery;
		primaryPointsMinimum[9] = GameInformation.basePlayer.Mockery;
		primaryPointsToAllocate[10] = GameInformation.basePlayer.Malevolant;
		primaryPointsMinimum[10] = GameInformation.basePlayer.Malevolant;
		primaryPointsToAllocate[11] = GameInformation.basePlayer.Unmerciful;
		primaryPointsMinimum[11] = GameInformation.basePlayer.Unmerciful;

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
		
		GameInformation.basePlayer.PrimaryStatPointsToAllocate=	primaryStatPointsToAllocate;
		GameInformation.basePlayer.HeroicStatPointsToAllocate=		heroicStatPointsToAllocate;
		GameInformation.basePlayer.SecondaryStatPointsToAllocate=	secondaryStatPointsToAllocate;



		GameInformation.basePlayer.Strength = 		primaryPointsToAllocate[0];
		GameInformation.basePlayer.Speed = 		primaryPointsToAllocate[1];
		GameInformation.basePlayer.Dexterity = 	primaryPointsToAllocate[2];
		GameInformation.basePlayer.Reflex = 		primaryPointsToAllocate[3];
		GameInformation.basePlayer.Resilience = 	primaryPointsToAllocate[4];
		GameInformation.basePlayer.Knowledge = 	primaryPointsToAllocate[5];
		GameInformation.basePlayer.Elocution = 	primaryPointsToAllocate[6];
		GameInformation.basePlayer.Intellect = 	primaryPointsToAllocate[7];
		GameInformation.basePlayer.Focus =			primaryPointsToAllocate[8];
		GameInformation.basePlayer.Mockery = 		primaryPointsToAllocate[9];
		GameInformation.basePlayer.Malevolant = 	primaryPointsToAllocate[10];
		GameInformation.basePlayer.Unmerciful = 	primaryPointsToAllocate[11];

		GameInformation.basePlayer.Rage = 			heroicPointsToAllocate[0];
		GameInformation.basePlayer.Phase = 		heroicPointsToAllocate[1];

		GameInformation.basePlayer.Momentum = 		secondaryPointsToAllocate[0];
		GameInformation.basePlayer.Balance = 		secondaryPointsToAllocate[1];
		GameInformation.basePlayer.Luck = 			secondaryPointsToAllocate[2];
		GameInformation.basePlayer.Perception = 	secondaryPointsToAllocate[3];
		GameInformation.basePlayer.Judgement = 	secondaryPointsToAllocate[4];
		GameInformation.basePlayer.Chaos = 		secondaryPointsToAllocate[5];
	}








	}


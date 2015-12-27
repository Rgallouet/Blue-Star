
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistorySelectionButtons : MonoBehaviour
{
	
	public static Canvas HistorySelection;
	public static PlayerHistoryStep currentStep;
	public enum PlayerHistoryStep
	{
		START,
		HELLCIRCLE,
		ALLEGIANCE,
		GENUS,
		SPECIES,
		CLASS,
		IMP,
		ORIGIN,
		TEMPER,
		ASTRO,
		AFFINITY,
		END
	}
	
	public static int HistoryChoice;
	public static GridLayoutGroup ChoiceDisplay;
	public static RectTransform HistoChoiceDescription;
	public static Button[] Choice = new Button[10];
	public static Text[] HistoryChoiceDisplay = new Text[10];
	public static Image[] HistoryChoiceImage = new Image[9];
	public static string[] HellCircles = new string[9] {
		"Limbo town",
		"Lust hills",
		"Gluttonbourg",
		"Greedpolis",
		"Capanger",
		"Heresynia",
		"Violocanto",
		"Bolgiafraudis",
		"Traitor's frostgrounds"
	};
	public static string[] HellCirclesDescription = new string[9] {
		"Limbo town is the capital of the first hell circle. Filled with brilliant minds, pacifists and scholars of chaos, the cosmopolite Limbo town is considered as the cultural and knowledge center of hell. \n \nSituated in the most distant circle, it benefits from a low gravity, cold climate and a dim vegetal life. \n \nThe Senate, an immaculate, transparent pentagram-shaped building, made of polished diamond towers, is its decision making organ. Open to all, the Senate often heed the advice of its unofficial triumvirate : Yrsif, Oug and Sutin, with no affiliation to any great demon houses. \n\n Population: Limbo dwellers prefer cooperation and studying the non-physical perks of their existence.",
		"Ah...The windy halls of lust... a sight of wonder renowned in all hell circles. \n\nHome habitat of the great flying jellyfish of the thousands red silk threads, The silvery sky can hardly be seen due to the swarm of dark red hair-looking threads hanging around. \n\nThe land is abusively called halls, but only a few pillars of black marble, hundreds of meters high, are lost on an otherwise red scenery of hills. \n\nThe flying jellyfish have an ever-lasting mating season, and the hills are endlessly covered with a thick layer of... juicy... wiggly... glue-like red jellyfish eggs. Broken eggs emit myst and strong chemicals that tends to disrupt inhibition functions of any species known in hell. \n\nOwned by the Incubus congregation, overseer Harpoc from the house Hardy, established an hourly fee for any demons entering the region to reduce crowdness.\n\nPopulation: Dwellers appreciate contemplation and ... well... chemically induced physical activity...",
		"Gluttonbourg is a suburban town of the Gluttonia Megapolis, in the last region able to arbor both vegetal and animal life. \n\nDry mud roads, little rocky houses and bushy gardens can confuse any sane-minded demon: this city entertained the human dream to its littlest details. \n\nIts mayor, Lord Butchy, is a remote member of the powerful O'prescu family famous for its key role in the war on the Navaties species, and his finances are largely responsible for the town's architectural mimicry perfection. \n\nQuiet town with no particular history except its architecture, the town is well known for its MOREMEAT burgers (mashed merguez, oyster's shell, reindeer ribs, eagle's talons, marmot cheeks, eel, albatross filet and tapir based patty). \n\nPopulation: After eating that everyday, a gluttonbourgeois can withstand pretty much anything",
		"Don Papa, War intendant Da'rhas, Elvish duke Dinu l'escou, so many legends that paved the way for grandeur and the rise of the demonic bourgeoisie. \n\nHeroes of wealth, all were born and raised in the underground city of Greedopolis. Cavernous dark alleys here and there on an otherwise smoky and hectic country-sized bazaar, the city is a lethal maze for any untrained adventurer. \n\nShiny boards of a million light, painting an imaginary sky, sparsely interrupted by casinos so high they literally dig back in the earth from which they rise. \n\nGreedpolis is undisputedly the hell business center. Close your bags, brace yourself to the heavy gravity, and look for enemies everywhere... \n\nPopulation: surprise effect and independence is the only survival factor.",
		"Grey as cinder, spiked fences, edgy houses, Capanger is a silent haven for demons, situated on the edge of the DeepHollow cliff. \n\nThe vast emptiness a few meters away, from which no light or sound seem to ever escape, occupies inhabitant's mind on a daily basis. The sense of gravity, of time, seems always distorted in its vicinity, and an invisible, relentless, yet inexplicable feeling of pull can be felt from the nothingness. \n\nThe city is often described as being rules by the heavy emptiness, and no demon rules has ever wanted to lay claim on these lands.\n\nPopulation:Passive aggressivity is a form of politeness and the occasional heat storms tend to harden the fallen souls of the area.",
		"In the gigantic swamp of Heri, a complex constellation of wooden streets and dry mud back alleys can be spotted in the heavy greenish fog. \n\nThe whole city slowly moves, swims in the hungry swamp, curls, rotates on the whims of the ancient Kraken on which it resides. \n\nThe Gall Pak architect family strangely survived centuries of submersion and challenging reversal of the city, and rule it under the only possibles rules : none. \n\nPopulation: Heriens learn to change their inner beliefs on a daily basis. You never know when you'll wake up upside down, flying or swimming...",
		"Violocanto, the desolate region dominated by the three concentric volcanos erupting massive flows of aluminium and silver, is but sparsely populated. \n\nViolocanto can be found in Violanis, the first hell circle that host no other life than demons due to its proximity to the hell center. Water naturally exists only as a gas form which tends to complicate fancy lifestyles. \n\nThe land is ruled by the nomadic Ani Tribe, merchant of water. \n\nPopulation: living in Violocanto requires a few thing: a strong resistance to elements, and a deft hand for 'picking up' unattended vials of water.",
		"Bolgiafraudis, also called the Red Fan, is an impressive vertical composition of ten vast castles made of copper, gold and red rare stones. \n\nHigh gravity, hot and dry winds, barren waste lands and occasional acid lakes are the only features one can expect here outside the city. \n\nRuled over by the rust dragon Maliborg and his family, the stronghold is the official Deministry of War Waging in times of invasions. Many of the highest and strongest house of hell resides in the top layers of the Red Fan. \n\nThe regional laws follow the strong sense of hierarchy and military disposition put in place by the last dead dragon. \n\nPopulation: The highdead demons are trained to battle for invasion of physical worlds, by mastering non-physical offence skills and physical defence.",
		"The frost grounds lost its original name and purpose in times before any current walking species arrived in the hell circles. \n\nIt is the closest circle, and against all expectation by far the coldest. Not a thing exist here, no wind, no stone, not even a nail's head would dare to challenge the flatness that heavily resides there. \n\nThe ground is a waveless, seemingly endless, pristine mirror: an ice sea with no wrinkles. There is apparently nothing to do or see there, so actually no demon wants to either own it or come here. No demon is known to actually live here. \n\nPopulation: N/A"
	};
	public Sprite[] RightArmSprites = new Sprite[9];
	public static string[] Allegiance = new string[9] {
		"House Da'rhas",
		"House O'prescu",
		"House Maliborgis",
		"The doubt",
		"The Free Market Guild",
		"The Autonomous Senate",
		"The Sheath",
		"The Deministries",
		"None"
	};
	public static string[] AllegianceDescription = new string[9]
	{"House Da'rhas is the perfect exemple of wealth success story, through war and commerce. War intendant Da'Rhas, founder of the wealthiest family and main actor of the rise of Greedopolis, died in battle during the first clashes of the human campaign. The blow was heavy for the demonic community, and even more so on the economy. \n\nHouse Da'rhas has only one motto: Conquer more, to loot more. They will not stop until all discovered species are enslaved and their home world pillaged.",
		"House O'prescu is a stern and old family from Hornidy origins. Cold and rational, they participate in each war with ruthless and controversial methods, even for demons. \n\nThey do not care about enslavement or spoils of war, they live only for sheer domination and victory. They caused the war on the Navaties species to be particularly relentless and effective, to the extinct that none are alive to date and their civilisation is almost forgotten.",
		"House Maliborgis is the most politically influential house in the nine circles, and the oldest still living. Ruled by the last dragon, it holds the current war mandate and controls half of the deministries. \n\nManipulation, blackmailing and display of force are the main leverages to ensure no other family rise to the political spheres, especially the Da'Rhas and the O'prescu.",
		"The doubt is a religious order of demons, doubting about the sense of their existence. The doubt refutes the need for war waging, and acts to uncover pre-demonic artefacts and History. \n\nThe doubt is a very dangerous practise, as faith in its own existence is essential for a demon to stay alive. When the lack of purpose undermines sufficiently the need to exist, then demons may vanish out of existence",
		"The Free Market Guild is an unorganized and frail association of business demons around the world, trying to set themselves free from the political constraints of war and power. \n\nThey assess any items or actions through the impact it may have on their utility function and they abhor any kind of waste. They remain very weak politically, but their ranks grows every day.",		
		"The Autonomous Senate is a collective of demons from the 9th circle who is attempting to replicate the human republic structure.  This political style made the buzz, and is the trend in the last thousands of year.\n\nThe senate grew so much in power that it can be said that the whole 9th circle is now ruled over by democratic votes. \n\nThe Senate still records dozens of deaths per day during its decision making sessions.",		
		"The Sheath is a terrorist organization whose claimed objective is to establish a weapon-free culture among demons and to prevent any unnecessary wars. \n\nThey receive a decent amount of support from the low-level demons, whose lifespan is at its lowest in thousands of years of History. \n\nThe Sheath High council members remain unknown, and some rumors state that the true purpose of the Sheath is to undermine military strength of the government and primary houses, in order to take over the deministries in a bloody coup d'état.",		
		"The deministries are the government organs of the demons. Ranging from the most powerful, the Deministry of War Waging, to the most insignificant such as the Deministry for Demon Social Rights, the Deministries disorganises demons lives and ensures the most chaotic environment which suits bests to demons. \n\nDeministries are the primary source of entropy and absurdity in the demon's world.",		
		"You swore no allegiance to anything or anyone"};
	public Sprite[] LeftImpSprites = new Sprite[9];
	public static string[] Genuses = new string[6] 
	{"Demono","Angelum","Celticus","Nordi","Nyla","Homo"};
	public static string[] GenusesDescription = new string[6] {
		"Natives of the hell circle, the Demono genus, or 'original demon', includes three species: the Hornydi, the inccybi and the Vampyri. \n\nTheir understanding of the fabric of the world allowed them to escape the hell circles and to travel through planes of existence. The term 'demon' was naturally extended to include all species that joined the hell circles after the invasion wars. \n\nSpecificities: Natural leaders of demonic armies, the Demonos are well rounded people with a light orientation to survival skills.",
		"Former inhabitants of the Heaven consortium, Angeli were the first genus to be invaded by the original demons. \n\nThe invasion was a massacre, angels were overwhelmed by a sheer difference in number. \n\nTheir world pillaged a their people enslaved, many millions years passed until their initial frustration disappeared and time reshuffled the cards of fate. Their lobbying is highly responsible for the recent invasions of the Nordi and the current invasion on Homo. \n\nSpecificities: Their natural offensive skills and mastery of non-physical aspects of the universe led them to become great invaders in their turn.",
		"Recluse, cryptic, uncompliant, the celticus people are a force of nature. \n\nWild spirits, they are the only civilisation to have resisted an invasion. The demons proposed a peace treaty which led to, after thousands of years, appeased and economical relationships and eventually to freedom to move in the hell circles. \n\nWith strong independent status, celticus people have nowadays settled in pretty much all of the 8 inhabited circles. \n\nSpecificities: The celticus have a particularly strong resistance to non-physical events",
		"The Nordi people were a primitive yet highly social, diverse and peaceful civilization before encountering the first angels. \n\nMany species of the Nordi are forever lost in what will later be called the Plane War. The invasion highlighted for the first time the major gaps between physical and non-physical entities, and cause innumerable casualties in both sides. \n\nAlmost entirely obliterated by the zealous angels, surviving Nords became enslaved to mostly angelic families. \n\nSpecificities:.",
		"The home of Nylas remain to date a mystery for all other genuses, and it is probably the only reason why demons have not yet openly tried to invade and enslave them. \n\nThey can be seen from time to time passing by in the hell circles and people do not know how they managed to arrive here and there. \n\nDue to the lack of information on them, demons tend not to confront or openly chase them out of their land. They seem to be very few in number and they do not get involved in demon's businesses. \n\nSpecificities: information available on the Nylas is mostly wrong and useless.",
		"The Homo Sapiens species is the latest life form that caught the attention of the angels and original demons. \n\nPlans for the invasion are setting up, and first intelligence stated that the homo sapiens species rely most uniquely on the physical aspect of their existence, and exhibit strong physical resistance. \n\nThrough lessons learned from previous war with the Nordi, the demon federation tried to innovate and create their own genetically designed homo species with physical resistance traits to fight on equal terms. \n\nSpecificities: The Homo genus relies almost uniquely on the physical plane, for both offence and defense."
	};
	public static string[] Species = new string[18] {
		"Hornydi",
		"Succubi",
		"Vampyri",
		"Seraph",
		"Cherubim",
		"Thronoi",
		"Ankou",
		"Cernun",
		"Dagmus",
		"Elfaji",
		"Trolki",
		"Berzica",
		"Hor",
		"Ana",
		"Akep",
		"Spectrum",
		"Parisi",
		"Rex"
	};
	
	public static string[] SpeciesDescription = new string[18]
	{"Hornydi","Succubi","Vampyri","Seraph","Cherubim","Thronoi","Ankou","Cernun","Dagmus","Elfaji","Trolki","Berzica","Hor","Ana","Akep","Spectrum",
		"The Celtica cerna designed a parasitic worm to take over the homo sapiens nervous system. The celticus plan was to produce spies in enemy territory to greatly fasten the invasion. \n\nThe infected homo sapiens have enhanced physical abilities and lowered non-physical affinities. However, the symbiosis sadly produces greener blood, which doomed to failure the original plan for an intelligence faction. \n\nThe project was cancelled and the infected humans were left to die. Sadly for everyone, not all of them did... And in addition to their genetically designed hate to humans, they developed a very legitimate one to the celticus cernum species.",
		"Rex"};
	
	public Sprite[] HeadSprites = new Sprite[18];
	public static string[] Jobs = new string[9] {
		"Ripper",
		"Butcher",
		"Guardian",
		"Lord",
		"Architect",
		"Judge",
		"Painter",
		"Muse",
		"Baker"
	};
	public static string[] JobsDescription = new string[9] {
		"Ripper",
		"Butcher",
		"Guardian",
		"Lord",
		"Architect",
		"Judge",
		"Painter",
		"Muse",
		"Baker"
	};
	public Sprite[] LeftArmSprites = new Sprite[9];
	public static string[] Imp = new string[9] {
		"Imp Maid",
		"Imp Cook",
		"Imp Butler",
		"Imp Nurse",
		"Imp Driver",
		"Imp Cleaner",
		"Imp Builder",
		"Imp Bodyguard",
		"Imp Governess"
	};
	public static string[] ImpDescription = new string[9] 
	{"To be completed.",
		"To be completed.",
		"To be completed.",
		"To be completed.",
		"To be completed.",		
		"To be completed.",		
		"To be completed.",		
		"To be completed.",		
		"To be completed."};
	public Sprite[] RightImpSprites = new Sprite[9];
	public static string[] Origins = new string[9] 
	{"Monkey","Bear","Wolf","Bee","Snail","Ant","Doe","Owl","Turtle"};
	public static string[] OriginsDescription = new string[9] 
	{"Monkey","Bear","Wolf","Bee","Snail","Ant","Doe","Owl","Turtle"};
	public Sprite[] TorsoSprites = new Sprite[9];
	public static string[] DeathStates = new string[9] {
		"Lashing out",
		"Rebellious",
		"Sleepy",
		"Violent",
		"Powerlessness",
		"Unfairness",
		"At peace",
		"Sleepy",
		"Passive"
	};
	public static string[] DeathStatesDescription = new string[9] {
		"Lashing out",
		"Rebellious",
		"Sleepy",
		"Violent",
		"Powerlessness",
		"Unfairness",
		"At peace",
		"Sleepy",
		"Passive"
	};
	public Sprite[] LegsSprites = new Sprite[9];
	public static string[] Astros = new string[9]
	{"Canis","Scuti","Cephei","Wester","Betel","Vulpe","Anta","Gemi","Cygni"};
	public static string[] AstrosDescription = new string[9]
	{"Canis","Scuti","Cephei","Wester","Betel","Vulpe","Anta","Gemi","Cygni"};
	public Sprite[] RightFootSprites = new Sprite[9];
	public static string[] Affis = new string[9] {
		"Organic",
		"Light",
		"Heat",
		"Nuclear",
		"Magneto",
		"Psychic",
		"Gravity",
		"Cold",
		"Shadow"
	};
	public static string[] AffisDescription = new string[9] {
		"Organic",
		"Light",
		"Heat",
		"Nuclear",
		"Magneto",
		"Psychic",
		"Gravity",
		"Cold",
		"Shadow"
	};
	public Sprite[] LeftFootSprites = new Sprite[9];
	
	void Start ()
	{
		
		currentStep = PlayerHistoryStep.HELLCIRCLE;
		HistorySelection = GetComponent<Canvas> ();
		HistoChoiceDescription = HistorySelection.GetComponentInChildren<RectTransform> ();
		ChoiceDisplay = HistoChoiceDescription.GetComponentInChildren<GridLayoutGroup> ();
		
		for (int i=0; i<9; i++) {
			Choice [i] = ChoiceDisplay.GetComponentsInChildren<Button> () [i];
		}
		for (int i=0; i<10; i++) {
			HistoryChoiceDisplay [i] = HistorySelection.GetComponentInChildren<Mask> ().GetComponentsInChildren<Text> () [i];
		}
		for (int i=0; i<9; i++) {
			HistoryChoiceImage [i] = HistorySelection.GetComponentInChildren<Mask> ().GetComponentsInChildren<Image> () [i + 1];
		}
		
		
		GetHistoryUIButtons ();
		
		HistorySelection.enabled = false;
		
	}
	
	
	
	
	
	
	
	// Interaction with UI Buttons
	public void choice_1 ()
	{
		HistoryChoice = 1;
		UpdateDescription ();
	}
	
	public void choice_2 ()
	{
		HistoryChoice = 2;
		UpdateDescription ();
	}
	
	public void choice_3 ()
	{
		HistoryChoice = 3;
		UpdateDescription ();
	}
	
	public void choice_4 ()
	{
		HistoryChoice = 4;
		UpdateDescription ();
	}
	
	public void choice_5 ()
	{
		HistoryChoice = 5;
		UpdateDescription ();
	}
	
	public void choice_6 ()
	{
		HistoryChoice = 6;
		UpdateDescription ();
	}
	
	public void choice_7 ()
	{
		HistoryChoice = 7;
		UpdateDescription ();
	}
	
	public void choice_8 ()
	{
		HistoryChoice = 8;
		UpdateDescription ();
	}
	
	public void choice_9 ()
	{
		HistoryChoice = 9;
		UpdateDescription ();
	}
	
	void UpdateDescription ()
	{
		
		switch (currentStep) {
		case PlayerHistoryStep.HELLCIRCLE: 	
			HistorySelection.GetComponentsInChildren<Text> () [2].text = HellCirclesDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [0].text = HellCircles [HistoryChoice - 1];
			HistoryChoiceImage [0].sprite = RightArmSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.ALLEGIANCE:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = AllegianceDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [1].text = Allegiance [HistoryChoice - 1];
			HistoryChoiceImage [1].sprite = LeftImpSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.GENUS:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = GenusesDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [2].text = Genuses [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.SPECIES:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = SpeciesDescription [HistoryChoice - 1 + 3 * (MenuGUI.genusSelection - 1)];
			HistoryChoiceDisplay [3].text = Species [HistoryChoice - 1 + 3 * (MenuGUI.genusSelection - 1)];
			HistoryChoiceImage [3 - 1].sprite = HeadSprites [HistoryChoice - 1 + 3 * (MenuGUI.genusSelection - 1)];
			break;
		case PlayerHistoryStep.CLASS:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = JobsDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [4].text = Jobs [HistoryChoice - 1];
			HistoryChoiceImage [4 - 1].sprite = LeftArmSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.IMP:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = ImpDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [5].text = Imp [HistoryChoice - 1];
			HistoryChoiceImage [5 - 1].sprite = RightImpSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.ORIGIN:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = OriginsDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [6].text = Origins [HistoryChoice - 1];
			HistoryChoiceImage [6 - 1].sprite = TorsoSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.TEMPER:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = DeathStatesDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [7].text = DeathStates [HistoryChoice - 1];
			HistoryChoiceImage [7 - 1].sprite = LegsSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.ASTRO:		
			HistorySelection.GetComponentsInChildren<Text> () [2].text = AstrosDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [8].text = Astros [HistoryChoice - 1];
			HistoryChoiceImage [8 - 1].sprite = RightFootSprites [HistoryChoice - 1];
			break;
		case PlayerHistoryStep.AFFINITY:	
			HistorySelection.GetComponentsInChildren<Text> () [2].text = AffisDescription [HistoryChoice - 1];
			HistoryChoiceDisplay [9].text = Affis [HistoryChoice - 1];
			HistoryChoiceImage [9 - 1].sprite = LeftFootSprites [HistoryChoice - 1];
			break;
			
		}
	}
	
	public static void GetHistoryUIButtons ()
	{
		
		HistorySelection.GetComponentsInChildren<Text> () [2].text = "";
		
		switch (currentStep) {
			
		case PlayerHistoryStep.HELLCIRCLE: 	
			
			HistorySelection.GetComponentInChildren<Text> ().text = "From which one of my hell circles did you crawl from, my sweet devious child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Hell Circle Lore";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = HellCircles [i];
			}
			break;
			
		case PlayerHistoryStep.ALLEGIANCE: 	
			
			if (MenuGUI.lastActionWasNext == false) {
				for (int i=6; i<9; i++) {
					Choice [i].gameObject.SetActive (true);
				}
			}
			HistorySelection.GetComponentInChildren<Text> ().text = "...And to which demon house or institution have you offered your allegiance, hm?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "House Lore";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Allegiance [i];
			}
			break;
			
		case PlayerHistoryStep.GENUS:		
			
			if (MenuGUI.lastActionWasNext == false) {
				for (int i=3; i<6; i++) {
					Choice [i].gameObject.SetActive (true);
				}
			}
			HistorySelection.GetComponentInChildren<Text> ().text = "My eyes are fading... could you whisper me what's in your genes, child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Genus Lore";
			for (int i=0; i<6; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Genuses [i];
			}
			for (int i=6; i<9; i++) {
				Choice [i].gameObject.SetActive (false);
			}
			break;
			
		case PlayerHistoryStep.SPECIES:		
			
			if (MenuGUI.lastActionWasNext == false) {
				for (int i=6; i<9; i++) {
					Choice [i].gameObject.SetActive (false);
				}
			}
			HistorySelection.GetComponentInChildren<Text> ().text = "My eyes are fading... could you whisper me what's in your genes, child?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Species Lore";
			for (int i=0; i<3; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Species [3 * (MenuGUI.genusSelection - 1) + i];
			}
			for (int i=3; i<6; i++) {
				Choice [i].gameObject.SetActive (false);
			}
			break;
			
		case PlayerHistoryStep.CLASS:		
			
			if (MenuGUI.lastActionWasNext == true) {
				for (int i=3; i<9; i++) {
					Choice [i].gameObject.SetActive (true);
				}
			}
			HistorySelection.GetComponentInChildren<Text> ().text = "Aah... and what did you do back in your hell circle?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Job Description";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Jobs [i];
			}
			break;
			
		case PlayerHistoryStep.IMP:		
			
			HistorySelection.GetComponentInChildren<Text> ().text = "Should we provide passage to a demonic imp of some kind at your service?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Imp Lore";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Imp [i];
			}
			break;
			
		case PlayerHistoryStep.ORIGIN:		
			
			HistorySelection.GetComponentInChildren<Text> ().text = "Hm... That's enough of your demon life for the war register... Now, what were you before coming here?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Origin Influence";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Origins [i];
			}
			break;
			
		case PlayerHistoryStep.TEMPER:		
			
			HistorySelection.GetComponentInChildren<Text> ().text = "Nice... Any specific psychologic state at your time of death?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Psychologic State";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = DeathStates [i];
			}
			break;
			
		case PlayerHistoryStep.ASTRO:		
			
			HistorySelection.GetComponentInChildren<Text> ().text = "Interesting... at time of your death, what was the dominant astrological sign?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Sign Lore";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Astros [i];
			}
			break;
			
		case PlayerHistoryStep.AFFINITY:	
			
			HistorySelection.GetComponentInChildren<Text> ().text = "Right... and from which channel are you planning on passing to the surface?";
			HistorySelection.GetComponentsInChildren<Text> () [1].text = "Primordial Affinity";
			for (int i=0; i<9; i++) {
				Choice [i].GetComponentInChildren<Text> ().text = Affis [i];
			}
			break;
			
		}
		
		
	}
	
	
	
	
	
	
}



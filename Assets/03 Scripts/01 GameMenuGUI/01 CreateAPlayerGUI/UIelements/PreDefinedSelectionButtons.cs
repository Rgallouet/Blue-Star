
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreDefinedSelectionButtons : MonoBehaviour
{
	
	public static Canvas PreDefinedSelection;
	// Selections
	public static int HistoryChoice;
	public static int HellCircleChoice;
	public static int AllegianceChoice;
	public static int GenusChoice;
	public static int SpeciesChoice;
	public static int JobChoice;
	public static int ImpChoice;
	public static int OriginChoice;
	public static int TemperChoice;
	public static int AstroChoice;
	public static int AffinityChoice;
	// UI
	public static GridLayoutGroup ChoiceDisplay;
	public static RectTransform HistoChoiceDescription;
	public static Button[] Choice = new Button[10];
	public static Text[] HistoryChoiceDisplay = new Text[10];
	public static Image[] HistoryChoiceImage = new Image[9];
	// Possible choices
	public static string[] Characters = new string[9] {
		"The Vampire Lord",
		"The Horned Warlock",
		"The Half-Blood Hunter",
		"The Judge of Hearts",
		"The Divine Butcher",
		"The Resident Whisperer",
		"The Ancient Architect",
		"The Warden of the North",
		"The Dead Souls Healer"
	};
	public static string[] CharactersDescription = new string[9] {
		"Brilliant mind and defty hands, the vampire lord excels both with ranged and melee weapons. His mastery of war arts makes him a highly resilient and offensive foe in physical conflicts, and decent resistance to non-physical aggressions.",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	};
	// Spirtes for displaying choices
	public Sprite[] RightArmSprites = new Sprite[9];
	public Sprite[] LeftImpSprites = new Sprite[9];
	public Sprite[] HeadSprites = new Sprite[18];
	public Sprite[] LeftArmSprites = new Sprite[9];
	public Sprite[] RightImpSprites = new Sprite[9];
	public Sprite[] TorsoSprites = new Sprite[9];
	public Sprite[] LegsSprites = new Sprite[9];
	public Sprite[] RightFootSprites = new Sprite[9];
	public Sprite[] LeftFootSprites = new Sprite[9];

	void Start ()
	{
		
		PreDefinedSelection = GetComponent<Canvas> ();
		HistoChoiceDescription = PreDefinedSelection.GetComponentInChildren<RectTransform> ();
		ChoiceDisplay = HistoChoiceDescription.GetComponentInChildren<GridLayoutGroup> ();
		
		for (int i=0; i<9; i++) {
			Choice [i] = ChoiceDisplay.GetComponentsInChildren<Button> () [i];
		}

		for (int i=0; i<9; i++) {
			HistoryChoiceImage [i] = PreDefinedSelection.GetComponentInChildren<Mask> ().GetComponentsInChildren<Image> () [i + 1];
		}

		GetPreDefinedUIButtons ();
		PreDefinedSelection.enabled = false;
		
	}




	public static void GetPreDefinedUIButtons ()
	{
		for (int i=0; i<9; i++) {
			Choice [i].GetComponentInChildren<Text> ().text = Characters [i];
		}
	}
	
	
	// Interaction with UI Buttons
	public void choice (int choice)
	{
		HistoryChoice = choice;
		GetSelectionChoices ();
		UpdateDescription ();
	}




	void GetSelectionChoices ()
	{

		switch (HistoryChoice) {
		case 1:
			HellCircleChoice=7;AllegianceChoice=1;GenusChoice=1;SpeciesChoice=3;JobChoice=4;ImpChoice=2;OriginChoice=3;TemperChoice=4;AstroChoice=1;AffinityChoice=9;
			break;
		case 2:
			HellCircleChoice=2;AllegianceChoice=3;GenusChoice=1;SpeciesChoice=1;JobChoice=7;ImpChoice=8;OriginChoice=1;TemperChoice=7;AstroChoice=6;AffinityChoice=3;
			break;
		case 3:
			HellCircleChoice=3;AllegianceChoice=4;GenusChoice=6;SpeciesChoice=3;JobChoice=1;ImpChoice=4;OriginChoice=6;TemperChoice=1;AstroChoice=4;AffinityChoice=1;
			break;
		case 4:
			HellCircleChoice=9;AllegianceChoice=9;GenusChoice=5;SpeciesChoice=2;JobChoice=6;ImpChoice=1;OriginChoice=4;TemperChoice=9;AstroChoice=3;AffinityChoice=2;
			break;
		case 5:
			HellCircleChoice=6;AllegianceChoice=8;GenusChoice=2;SpeciesChoice=1;JobChoice=2;ImpChoice=3;OriginChoice=5;TemperChoice=2;AstroChoice=9;AffinityChoice=4;
			break;
		case 6:
			HellCircleChoice=5;AllegianceChoice=7;GenusChoice=6;SpeciesChoice=1;JobChoice=8;ImpChoice=9;OriginChoice=7;TemperChoice=5;AstroChoice=7;AffinityChoice=6;
			break;
		case 7:
			HellCircleChoice=1;AllegianceChoice=5;GenusChoice=3;SpeciesChoice=2;JobChoice=5;ImpChoice=7;OriginChoice=9;TemperChoice=3;AstroChoice=8;AffinityChoice=5;
			break;
		case 8:
			HellCircleChoice=4;AllegianceChoice=6;GenusChoice=4;SpeciesChoice=2;JobChoice=3;ImpChoice=5;OriginChoice=2;TemperChoice=8;AstroChoice=5;AffinityChoice=7;
			break;
		case 9:
			HellCircleChoice=8;AllegianceChoice=2;GenusChoice=3;SpeciesChoice=1;JobChoice=9;ImpChoice=6;OriginChoice=8;TemperChoice=6;AstroChoice=2;AffinityChoice=8;
			break;
			
		}

	}
	
	void UpdateDescription ()
	{

		PreDefinedSelection.GetComponentsInChildren<Text> () [2].text = CharactersDescription [HistoryChoice - 1];

		HistoryChoiceImage [0].sprite = RightArmSprites [HellCircleChoice - 1];
		HistoryChoiceImage [1].sprite = LeftImpSprites [AllegianceChoice - 1];
		HistoryChoiceImage [2].sprite = HeadSprites [SpeciesChoice - 1 + 3 * (GenusChoice - 1)];
		HistoryChoiceImage [3].sprite = LeftArmSprites [JobChoice - 1];
		HistoryChoiceImage [4].sprite = RightImpSprites [ImpChoice - 1];
		HistoryChoiceImage [5].sprite = TorsoSprites [OriginChoice - 1];
		HistoryChoiceImage [6].sprite = LegsSprites [TemperChoice - 1];
		HistoryChoiceImage [7].sprite = RightFootSprites [AstroChoice - 1];
		HistoryChoiceImage [8].sprite = LeftFootSprites [AffinityChoice - 1];

	}
	

		
	
	
	
	
	
}



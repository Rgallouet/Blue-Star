
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreDefinedSelectionButtons : MonoBehaviour
{
	
	public static Canvas PreDefinedSelection;
    private PredefinedCharacters data = new PredefinedCharacters();
    public TextAsset CSVSource;




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
	public static string[] Characters = new string[9];
	public static string[] CharactersDescription = new string[9];
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

        data.Load(CSVSource);

        HistoChoiceDescription = PreDefinedSelection.GetComponentInChildren<RectTransform> ();
		ChoiceDisplay = HistoChoiceDescription.GetComponentInChildren<GridLayoutGroup> ();
		
		for (int i=0; i<9; i++) {
			Choice [i] = ChoiceDisplay.GetComponentsInChildren<Button> () [i];
		}

		for (int i=0; i<9; i++) {
			HistoryChoiceImage [i] = PreDefinedSelection.GetComponentInChildren<Mask> ().GetComponentsInChildren<Image> () [i + 1];
		}

        for (int i = 0; i < 9; i++)

        GetPreDefinedUIButtons ();
		PreDefinedSelection.enabled = false;
		
	}




	public void GetPreDefinedUIButtons ()
	{
		for (int i=0; i<9; i++) {
            Debug.Log(data.Find_Id(1).CharactersName);
            Choice[i].GetComponentInChildren<Text> ().text = data.Find_Id(i+1).CharactersName;
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

        HellCircleChoice = data.Find_Id(HistoryChoice).HellCircleChoice;
        AllegianceChoice = data.Find_Id(HistoryChoice).AllegianceChoice;
        GenusChoice = data.Find_Id(HistoryChoice).GenusChoice;
        SpeciesChoice = data.Find_Id(HistoryChoice).SpeciesChoice;
        JobChoice = data.Find_Id(HistoryChoice).JobChoice;
        ImpChoice = data.Find_Id(HistoryChoice).ImpChoice;
        OriginChoice = data.Find_Id(HistoryChoice).OriginChoice;
        TemperChoice = data.Find_Id(HistoryChoice).TemperChoice;
        AstroChoice = data.Find_Id(HistoryChoice).AstroChoice;
        AffinityChoice = data.Find_Id(HistoryChoice).AffinityChoice;


    }
	
	void UpdateDescription ()
	{

		PreDefinedSelection.GetComponentsInChildren<Text> () [3].text = data.Find_Id(HistoryChoice).CharactersDescription;

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



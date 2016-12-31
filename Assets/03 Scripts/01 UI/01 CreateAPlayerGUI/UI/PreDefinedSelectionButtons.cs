using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PreDefinedSelectionButtons : MonoBehaviour
{
    public DataBaseManager dataBaseManager;
    private ArrayList refData = new ArrayList();
    private ArrayList RefErrors = new ArrayList();

    private Canvas PreDefinedSelection;

    //Link to master
    public MenuGUI menuGUI;

    // Selections
    public int HistoryChoice;
	public int HellCircleChoice;
	public int AllegianceChoice;
	public int GenusChoice;
	public int SpeciesChoice;
	public int JobChoice;
	public int ImpChoice;
	public int OriginChoice;
	public int TemperChoice;
	public int AstroChoice;
	public int AffinityChoice;

	// UI
	private Button[] Choice = new Button[10];
    private Image[] HistoryChoiceImage = new Image[9];

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
        PreDefinedSelection.enabled = false;

        refData = dataBaseManager.getArrayData("select * from REF_PredefinedCharacters order by Id asc", "BlueStarDataWarehouse.db");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc", "BlueStarDataWarehouse.db");


        //Link to left side text box for displaying names
        for (int i=0; i<9; i++) { Choice [i] = PreDefinedSelection.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<Button> () [i]; }

        //Link to right side image box for displaying character
        for (int i=0; i<9; i++) { HistoryChoiceImage [i] = PreDefinedSelection.GetComponentInChildren<Mask> ().GetComponentsInChildren<Image> () [i + 1]; }

        GetPreDefinedUIButtons ();
		
	}
    
    // Display names in buttons
	public void GetPreDefinedUIButtons ()
	{
		for (int i=0; i<9; i++) {
            Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)refData[i+1])[1];

        }
    }
	
	// Interaction with UI Buttons
	public void choice (int choice)
	{
        HistoryChoice = choice+1;
        GetSelectionChoices (choice);
		UpdateDescription (choice);
	}


    // Reading the values of sub-choice for a predefined character chosen
	void GetSelectionChoices (int HistoryChoice)
	{

        HellCircleChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[3]);
        AllegianceChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[4]);
        GenusChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[5]);
        SpeciesChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[6]);
        JobChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[7]);
        ImpChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[8]);
        OriginChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[9]);
        TemperChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[10]);
        AstroChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[11]);
        AffinityChoice = System.Convert.ToInt32(((ArrayList)refData[HistoryChoice])[12]);


    }
	
    // Update display of the selected predefined character
	void UpdateDescription (int HistoryChoice)
	{

        PreDefinedSelection.GetComponentsInChildren<Text>()[2].text = ((string)((ArrayList)refData[HistoryChoice])[2]).Replace("<br>", "\n");

        HistoryChoiceImage[0].sprite = RightArmSprites [HellCircleChoice - 1];
		HistoryChoiceImage [1].sprite = LeftImpSprites [AllegianceChoice - 1];
		HistoryChoiceImage [2].sprite = HeadSprites [SpeciesChoice - 1 + 3 * (GenusChoice - 1)];
		HistoryChoiceImage [3].sprite = LeftArmSprites [JobChoice - 1];
		HistoryChoiceImage [4].sprite = RightImpSprites [ImpChoice - 1];
		HistoryChoiceImage [5].sprite = TorsoSprites [OriginChoice - 1];
		HistoryChoiceImage [6].sprite = LegsSprites [TemperChoice - 1];
		HistoryChoiceImage [7].sprite = RightFootSprites [AstroChoice - 1];
		HistoryChoiceImage [8].sprite = LeftFootSprites [AffinityChoice - 1];

	}





    public void Next() {


        if (!(HistoryChoice == 0))
        {
            menuGUI.MenuGoNext(0);
            menuGUI.WasPredefinedPath = true;
            PreDefinedSelection.enabled = false;
        }
        else {
            menuGUI.dialogue.UpdateDialogue(false, (string)((ArrayList)RefErrors[4])[2], (string)((ArrayList)RefErrors[4])[3], (string)((ArrayList)RefErrors[4])[4]);

        }

    }


    public void Back() {
        menuGUI.MenuGoNext(0);
        PreDefinedSelection.enabled = false;
    }


    public void ActivateMenu() {
        PreDefinedSelection.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.PREDEFINEDSELECTION;

    }







}



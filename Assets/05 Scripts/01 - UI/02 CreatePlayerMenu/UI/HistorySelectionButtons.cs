
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HistorySelectionButtons : MonoBehaviour
{
	
	private Canvas HistorySelection;
	public PlayerHistoryStep currentStep;

	public enum PlayerHistoryStep
	{
		START,
		HELLCIRCLE,
		ALLEGIANCE,
		GENUS,
		CLASS,
		IMP,
		ORIGIN,
		TEMPER,
		ASTRO,
		AFFINITY,
		END
	}


    // Gestion données référentielles
    public DataBaseManager dataBaseManager;
    private ArrayList RefHellCircles = new();
    private ArrayList RefAllegiance = new();
    private ArrayList RefGenus = new();
    private ArrayList RefSpecies = new();
    private ArrayList RefClass = new();
    private ArrayList RefImp = new();
    private ArrayList RefOrigin = new();
    private ArrayList RefTemper = new();
    private ArrayList RefAstro = new();
    private ArrayList RefAffinity = new();

    private ArrayList RefQuestions = new();
    private ArrayList RefErrors = new();

    public CharacterDisplay characterDisplay;

    //choices
    public int[] historyChoicesInt;
    public HistoryChoices historyChoices = new();
 

    // Connection vers l'UI
    public MenuGUI menuGUI;
    public int HistoryChoice;
	public GridLayoutGroup ChoiceDisplay;
	public Text CommentText;
    public Text QuestionOnCurrentStep;
    public Text CommentHeader;

    public static Button[] Choice = new Button[10];


    

	void Start ()
	{
        
        // Récupérer les référentiels
        RefHellCircles= dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='HellCircles' order by Id asc");
        RefAllegiance = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Allegiance' order by Id asc");
        RefGenus = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Genus' order by Id asc");
        RefSpecies = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Species' order by Id asc");
        RefClass = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Class' order by Id asc");
        RefImp = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Imp' order by Id asc");
        RefOrigin = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Origin' order by Id asc");
        RefTemper = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Temper' order by Id asc");
        RefAstro = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Astro' order by Id asc");
        RefAffinity = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Affinity' order by Id asc");
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by Id asc");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc");


        //Initialiser le cycle
        currentStep = PlayerHistoryStep.HELLCIRCLE;


        //Connection vers éléments de l'UI
        HistorySelection = GetComponent<Canvas>();


        for (int i = 0; i < 9; i++) 
            {
                // Selecting the button
                Choice[i] = ChoiceDisplay.GetComponentsInChildren<Button>()[i];

                //initialising a list of choices by default at 0
                historyChoicesInt[i] = 0;
            }

		
		
		GetHistoryUIButtons ();
		
		HistorySelection.enabled = false;
		
	}
	
	
	
	// Interaction with UI Buttons
	public void choice (int choice)
	{
		HistoryChoice = choice;
        switch (currentStep)
        {
            case PlayerHistoryStep.HELLCIRCLE:
                CommentText.text = ((string)((ArrayList)RefHellCircles[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[0] = HistoryChoice;
                break;

            case PlayerHistoryStep.ALLEGIANCE:
                CommentText.text = ((string)((ArrayList)RefAllegiance[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[1] = HistoryChoice;
                break;

            case PlayerHistoryStep.GENUS:

                if (HistoryChoice >= 7)
                {
                    historyChoicesInt[3] = 3 * (historyChoicesInt[2] - 1) + HistoryChoice-6;
                    CommentText.text = ((string)((ArrayList)RefSpecies[historyChoicesInt[3]])[3]).Replace("<br>", "\n");
                }
                else
                {
                    // if no choices made for the species yet; then show the buttons
                    if (historyChoicesInt[2] == 0) 
                    { 
                        DisplayButtonsOnUi(6, 9, true,true); 
                    }

                    historyChoicesInt[2] = HistoryChoice;

                    // resetting the Species
                    if(!(historyChoicesInt[3] == 0)) historyChoicesInt[3] = 0;

                    for (int i = 6; i < 9; i++) 
                    {
                        Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefSpecies[3 * (historyChoicesInt[2] - 1) + i -5])[2]; 
                    }
                    CommentText.text = ((string)((ArrayList)RefGenus[HistoryChoice])[3]).Replace("<br>", "\n");
                }
                break;

            case PlayerHistoryStep.CLASS:
                CommentText.text = ((string)((ArrayList)RefClass[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[4] = HistoryChoice;
                break;

            case PlayerHistoryStep.IMP:
                CommentText.text = ((string)((ArrayList)RefImp[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[5] = HistoryChoice;
                break;

            case PlayerHistoryStep.ORIGIN:
                CommentText.text = ((string)((ArrayList)RefOrigin[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[6] = HistoryChoice;
                break;

            case PlayerHistoryStep.TEMPER:
                CommentText.text = ((string)((ArrayList)RefTemper[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[7] = HistoryChoice;
                break;

            case PlayerHistoryStep.ASTRO:
                CommentText.text = ((string)((ArrayList)RefAstro[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[8] = HistoryChoice;
                break;

            case PlayerHistoryStep.AFFINITY:
                CommentText.text = ((string)((ArrayList)RefAffinity[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[9] = HistoryChoice;
                break;

        }

        characterDisplay.UpdateCharacterDisplay(historyChoicesInt, true);

    }


    public void UpdateStageUIButtons(string Question, string TitleLore, int Stage, int Size) {

        QuestionOnCurrentStep.text = Question;
        CommentHeader.text = TitleLore;
        CommentText.text = "<Make a choice>";

        for (int i = 0; i < Size; i++)
        {
            switch (Stage)
            {
                case 1: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefHellCircles[i + 1])[2]; break;
                case 2: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefAllegiance[i + 1])[2]; break;
                case 3: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefGenus[i + 1])[2]; break;
                case 4: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefClass[i + 1])[2]; break;
                case 5: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefImp[i + 1])[2]; break;
                case 6: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefOrigin[i + 1])[2]; break;
                case 7: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefTemper[i + 1])[2]; break;
                case 8: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefAstro[i + 1])[2]; break;
                case 9: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefAffinity[i + 1])[2]; break;

            }
            
        }
        if (Stage==3 & !(historyChoicesInt[2] == 0)) {
            for (int i = Size; i < 9; i++) { Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefSpecies[3 * (historyChoicesInt[2] - 1) + i + 1])[2];  }
        } 

    }
    
    
	public void GetHistoryUIButtons ()
	{
		

		switch (currentStep) {
			
		case PlayerHistoryStep.HELLCIRCLE: UpdateStageUIButtons((string)((ArrayList)RefQuestions[4])[4], "Hell Circle Lore", 1, 9); break;
			
		case PlayerHistoryStep.ALLEGIANCE: 	
			
			if (menuGUI.lastActionWasNext == false) { DisplayButtonsOnUi(6, 9, true); }
            UpdateStageUIButtons((string)((ArrayList)RefQuestions[5])[4], "House Lore", 2, 9);
            break;

		case PlayerHistoryStep.GENUS:
            if (menuGUI.lastActionWasNext == true && historyChoicesInt[2] == 0) { DisplayButtonsOnUi(6, 9, false); }
            if (menuGUI.lastActionWasNext == false ) { DisplayButtonsOnUi(6, 9, true,true); }
            UpdateStageUIButtons((string)((ArrayList)RefQuestions[6])[4], "Genus Lore", 3, 6);
            break;

        case PlayerHistoryStep.CLASS:
            if (menuGUI.lastActionWasNext == true ) { DisplayButtonsOnUi(6, 9, true); }
            UpdateStageUIButtons((string)((ArrayList)RefQuestions[7])[4], "Job Description", 4, 9);
            break;
		case PlayerHistoryStep.IMP: UpdateStageUIButtons((string)((ArrayList)RefQuestions[8])[4], "Imp Lore", 5, 9); break;
		case PlayerHistoryStep.ORIGIN: UpdateStageUIButtons((string)((ArrayList)RefQuestions[9])[4], "Origin Influence", 6, 9); break;
		case PlayerHistoryStep.TEMPER: UpdateStageUIButtons((string)((ArrayList)RefQuestions[10])[4], "Psychologic State", 7, 9); break;
		case PlayerHistoryStep.ASTRO: UpdateStageUIButtons((string)((ArrayList)RefQuestions[11])[4], "Sign Lore", 8, 9); break; 
		case PlayerHistoryStep.AFFINITY: UpdateStageUIButtons((string)((ArrayList)RefQuestions[12])[4], "Primordial Affinity", 9, 9); break;

		}
		
		
	}


    public void HistorySelectionNext()
    {
        switch (currentStep)
        {

            case PlayerHistoryStep.HELLCIRCLE:
                currentStep = PlayerHistoryStep.ALLEGIANCE;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[5])[2], (string)((ArrayList)RefQuestions[5])[3], (string)((ArrayList)RefQuestions[5])[4]);
                break;

            case PlayerHistoryStep.ALLEGIANCE:
                currentStep = PlayerHistoryStep.GENUS;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[6])[2], (string)((ArrayList)RefQuestions[6])[3], (string)((ArrayList)RefQuestions[6])[4]);
                break;

            case PlayerHistoryStep.GENUS:
                currentStep = PlayerHistoryStep.CLASS;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[7])[2], (string)((ArrayList)RefQuestions[7])[3], (string)((ArrayList)RefQuestions[7])[4]);
                break;

            case PlayerHistoryStep.CLASS:
                currentStep = PlayerHistoryStep.IMP;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[8])[2], (string)((ArrayList)RefQuestions[8])[3], (string)((ArrayList)RefQuestions[8])[4]);
                break;

            case PlayerHistoryStep.IMP:
                currentStep = PlayerHistoryStep.ORIGIN;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[9])[2], (string)((ArrayList)RefQuestions[9])[3], (string)((ArrayList)RefQuestions[9])[4]);
                break;

            case PlayerHistoryStep.ORIGIN:
                currentStep = PlayerHistoryStep.TEMPER;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[10])[2], (string)((ArrayList)RefQuestions[10])[3], (string)((ArrayList)RefQuestions[10])[4]);
                break;

            case PlayerHistoryStep.TEMPER:
                currentStep = PlayerHistoryStep.ASTRO;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[11])[2], (string)((ArrayList)RefQuestions[11])[3], (string)((ArrayList)RefQuestions[11])[4]);
                break;

            case PlayerHistoryStep.ASTRO:
                currentStep = PlayerHistoryStep.AFFINITY;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[12])[2], (string)((ArrayList)RefQuestions[12])[3], (string)((ArrayList)RefQuestions[12])[4]);
                break;

            case PlayerHistoryStep.AFFINITY:
                currentStep = PlayerHistoryStep.END;
                break;
        }

        if (!(currentStep == PlayerHistoryStep.END))
        {
            GetHistoryUIButtons();
            HistoryChoice = 0;
        }

    }

    public void HistorySelectionBack()
    {

        switch (currentStep)
        {

            case PlayerHistoryStep.HELLCIRCLE:
                currentStep = PlayerHistoryStep.START;
                break;

            case PlayerHistoryStep.ALLEGIANCE:
                HistoryChoice = historyChoicesInt[0];
                currentStep = PlayerHistoryStep.HELLCIRCLE;
                break;

            case PlayerHistoryStep.GENUS:
                HistoryChoice = historyChoicesInt[1];
                currentStep = PlayerHistoryStep.ALLEGIANCE;
                break;

            case PlayerHistoryStep.CLASS:
                HistoryChoice = historyChoicesInt[3];
                currentStep = PlayerHistoryStep.GENUS;
                break;

            case PlayerHistoryStep.IMP:
                HistoryChoice = historyChoicesInt[4];
                currentStep = PlayerHistoryStep.CLASS;
                break;

            case PlayerHistoryStep.ORIGIN:
                HistoryChoice = historyChoicesInt[5];
                currentStep = PlayerHistoryStep.IMP;
                break;

            case PlayerHistoryStep.TEMPER:
                HistoryChoice = historyChoicesInt[6];
                currentStep = PlayerHistoryStep.ORIGIN;
                break;

            case PlayerHistoryStep.ASTRO:
                HistoryChoice = historyChoicesInt[7];
                currentStep = PlayerHistoryStep.TEMPER;
                break;

            case PlayerHistoryStep.AFFINITY:
                HistoryChoice = historyChoicesInt[8];
                currentStep = PlayerHistoryStep.ASTRO;
                break;
        }
        GetHistoryUIButtons();
    }



    public void Next() {

        menuGUI.lastActionWasNext = true;

        if ( (!(HistoryChoice == 0) && !(currentStep==PlayerHistoryStep.GENUS)) || ((HistoryChoice >= 7) && (currentStep == PlayerHistoryStep.GENUS)))
        {
            HistorySelectionNext();
            if(currentStep == PlayerHistoryStep.END) {
                HistorySelection.enabled = false;
                menuGUI.WasPredefinedPath = false;
                menuGUI.MenuGoNext(0);
            }

        }
        else {
            menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefErrors[1])[2], (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4]);
        }
  
    }

    public void Back() {

        menuGUI.lastActionWasNext = false;

        HistorySelectionBack();
        if(currentStep == PlayerHistoryStep.START)
        {
            menuGUI.MenuGoBack(0);
            HistorySelection.enabled = false;
        }
    }


    public void ActivateMenu() {
        HistorySelection.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.HISTORYSELECTION;

    }
	
	public void DisplayButtonsOnUi(int Start, int End, bool Display, bool RedColor=false)
    {

        for (int i = Start; i < End; i++)
        {
            Choice[i].interactable = Display;
            Choice[i].GetComponentInChildren<Text>().text = "";
            if (RedColor == true) Choice[i].GetComponent<Image>().color = new Color32(255,0,0,255);
            if (RedColor == false) Choice[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }

    }
	
	
}



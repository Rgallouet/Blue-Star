
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
    private ArrayList RefHellCircles = new ArrayList();
    private ArrayList RefAllegiance = new ArrayList();
    private ArrayList RefGenus = new ArrayList();
    private ArrayList RefSpecies = new ArrayList();
    private ArrayList RefClass = new ArrayList();
    private ArrayList RefImp = new ArrayList();
    private ArrayList RefOrigin = new ArrayList();
    private ArrayList RefTemper = new ArrayList();
    private ArrayList RefAstro = new ArrayList();
    private ArrayList RefAffinity = new ArrayList();

    private ArrayList RefQuestions = new ArrayList();
    private ArrayList RefErrors = new ArrayList();

    public CharacterDisplay characterDisplay;

    //choices
    public HistoryChoices historyChoices = new HistoryChoices();
 

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

        //Initialiser les choices à 0
        historyChoices.HellCircleChoice = 0;
        historyChoices.AllegianceChoice = 0;
        historyChoices.GenusChoice = 0;
        historyChoices.SpeciesChoice = 0;
        historyChoices.JobChoice = 0;
        historyChoices.ImpChoice = 0;
        historyChoices.OriginChoice = 0;
        historyChoices.TemperChoice = 0;
        historyChoices.AstroChoice = 0;
        historyChoices.AffinityChoice = 0;

        //Connection vers éléments de l'UI
        HistorySelection = GetComponent<Canvas> ();
		
		for (int i=0; i<9; i++) {
			Choice [i] = ChoiceDisplay.GetComponentsInChildren<Button> () [i];
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
                historyChoices.HellCircleChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.ALLEGIANCE:
                CommentText.text = ((string)((ArrayList)RefAllegiance[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.AllegianceChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.GENUS:

                if (HistoryChoice >= 7)
                {
                    historyChoices.SpeciesChoice = 3 * (historyChoices.GenusChoice - 1) + HistoryChoice-6;
                    CommentText.text = ((string)((ArrayList)RefSpecies[historyChoices.SpeciesChoice])[3]).Replace("<br>", "\n");
                }
                else
                {
                    if (historyChoices.GenusChoice == 0) { DisplayButtonsOnUi(6, 9, true,true); }
                    historyChoices.GenusChoice = HistoryChoice;
                    if(!(historyChoices.SpeciesChoice ==0)) historyChoices.SpeciesChoice = 0;
                    for (int i = 6; i < 9; i++) { Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefSpecies[3 * (historyChoices.GenusChoice - 1) + i -5])[2]; }
                    CommentText.text = ((string)((ArrayList)RefGenus[HistoryChoice])[3]).Replace("<br>", "\n");
                }
                break;

            case PlayerHistoryStep.CLASS:
                CommentText.text = ((string)((ArrayList)RefClass[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.JobChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.IMP:
                CommentText.text = ((string)((ArrayList)RefImp[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.ImpChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.ORIGIN:
                CommentText.text = ((string)((ArrayList)RefOrigin[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.OriginChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.TEMPER:
                CommentText.text = ((string)((ArrayList)RefTemper[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.TemperChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.ASTRO:
                CommentText.text = ((string)((ArrayList)RefAstro[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.AstroChoice = HistoryChoice;
                break;

            case PlayerHistoryStep.AFFINITY:
                CommentText.text = ((string)((ArrayList)RefAffinity[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoices.AffinityChoice = HistoryChoice;
                break;

        }

        characterDisplay.UpdateCharacterDisplay(historyChoices, true);

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
        if (Stage==3 & !(historyChoices.GenusChoice == 0)) {
            for (int i = Size; i < 9; i++) { Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefSpecies[3 * (historyChoices.GenusChoice - 1) + i + 1])[2];  }
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
            if (menuGUI.lastActionWasNext == true && historyChoices.GenusChoice ==0) { DisplayButtonsOnUi(6, 9, false); }
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
                HistoryChoice = historyChoices.HellCircleChoice;
                currentStep = PlayerHistoryStep.HELLCIRCLE;
                break;

            case PlayerHistoryStep.GENUS:
                HistoryChoice = historyChoices.AllegianceChoice;
                currentStep = PlayerHistoryStep.ALLEGIANCE;
                break;

            case PlayerHistoryStep.CLASS:
                HistoryChoice = historyChoices.SpeciesChoice;
                currentStep = PlayerHistoryStep.GENUS;
                break;

            case PlayerHistoryStep.IMP:
                HistoryChoice = historyChoices.JobChoice;
                currentStep = PlayerHistoryStep.CLASS;
                break;

            case PlayerHistoryStep.ORIGIN:
                HistoryChoice = historyChoices.ImpChoice;
                currentStep = PlayerHistoryStep.IMP;
                break;

            case PlayerHistoryStep.TEMPER:
                HistoryChoice = historyChoices.OriginChoice;
                currentStep = PlayerHistoryStep.ORIGIN;
                break;

            case PlayerHistoryStep.ASTRO:
                HistoryChoice = historyChoices.TemperChoice;
                currentStep = PlayerHistoryStep.TEMPER;
                break;

            case PlayerHistoryStep.AFFINITY:
                HistoryChoice = historyChoices.AstroChoice;
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



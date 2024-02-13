
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
		SOCIAL,
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
    private ArrayList RefSocial = new();
    private ArrayList RefClass = new();
    private ArrayList RefImp = new();
    private ArrayList RefOrigin = new();
    private ArrayList RefTemper = new();
    private ArrayList RefAstro = new();
    private ArrayList RefAffinity = new();

    // descriptions
    private ArrayList RefQuestions = new();
    private ArrayList RefErrors = new();

    public CharacterDisplay characterDisplay;

    //choices
    public int[] historyChoicesInt;
    public HistoryChoices historyChoices = new();
 

    // Connection vers l'UI
    public MenuGUI menuGUI;
    public int HistoryChoice;


	public Text CommentText;
    public Text QuestionOnCurrentStep;
    public Text CommentHeader;

    public static Button[] Choice = new Button[10];


    

	void Start ()
	{
        
        // Récupérer les référentiels
        RefHellCircles= dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='HellCircles' order by ChoiceId asc");
        RefAllegiance = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Allegiance' order by ChoiceId asc");
        RefSocial = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Social' order by ChoiceId asc");
        RefClass = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Class' order by ChoiceId asc");
        RefImp = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Imp' order by ChoiceId asc");
        RefOrigin = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Origin' order by ChoiceId asc");
        RefTemper = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Temper' order by ChoiceId asc");
        RefAstro = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Astro' order by ChoiceId asc");
        RefAffinity = dataBaseManager.getArrayData("select * from REF_HistoryChoicesStatistics where ChoiceStage='Affinity' order by ChoiceId asc");
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by DialogueId asc");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by DialogueId asc");


        //Initialiser le cycle
        currentStep = PlayerHistoryStep.HELLCIRCLE;


        //Connection vers éléments de l'UI
        HistorySelection = GetComponent<Canvas>();
        QuestionOnCurrentStep = HistorySelection.GetComponentsInChildren<Text>()[0];
        CommentHeader = HistorySelection.GetComponentsInChildren<Text>()[1];
        CommentText = HistorySelection.GetComponentsInChildren<Text>()[2];

        for (int i = 0; i < 9; i++) 
            {
                // Selecting the button
                Choice[i] = HistorySelection.GetComponentsInChildren<Button>()[i];

            }

		
		
		GetHistoryUIButtons ();
		
		HistorySelection.enabled = false;
		
	}
	
	
	
	// Interaction with UI Buttons
	public void SelectAChoice (int choice)
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

            case PlayerHistoryStep.SOCIAL:
                CommentText.text = ((string)((ArrayList)RefAllegiance[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[2] = HistoryChoice;
                break;

            case PlayerHistoryStep.CLASS:
                CommentText.text = ((string)((ArrayList)RefClass[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[3] = HistoryChoice;
                break;

            case PlayerHistoryStep.IMP:
                CommentText.text = ((string)((ArrayList)RefImp[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[4] = HistoryChoice;
                break;

            case PlayerHistoryStep.ORIGIN:
                CommentText.text = ((string)((ArrayList)RefOrigin[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[5] = HistoryChoice;
                break;

            case PlayerHistoryStep.TEMPER:
                CommentText.text = ((string)((ArrayList)RefTemper[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[6] = HistoryChoice;
                break;

            case PlayerHistoryStep.ASTRO:
                CommentText.text = ((string)((ArrayList)RefAstro[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[7] = HistoryChoice;
                break;

            case PlayerHistoryStep.AFFINITY:
                CommentText.text = ((string)((ArrayList)RefAffinity[HistoryChoice])[3]).Replace("<br>", "\n");
                historyChoicesInt[8] = HistoryChoice;

                break;

        }


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
                case 3: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefSocial[i + 1])[2]; break;
                case 4: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefClass[i + 1])[2]; break;
                case 5: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefImp[i + 1])[2]; break;
                case 6: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefOrigin[i + 1])[2]; break;
                case 7: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefTemper[i + 1])[2]; break;
                case 8: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefAstro[i + 1])[2]; break;
                case 9: Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)RefAffinity[i + 1])[2]; break;

            }
            
        }


    }
    
    
	public void GetHistoryUIButtons ()
	{
		

		switch (currentStep) {
			
		    case PlayerHistoryStep.HELLCIRCLE: UpdateStageUIButtons((string)((ArrayList)RefQuestions[4])[4], "Hell Circle Lore", 1, 9); break;
		    case PlayerHistoryStep.ALLEGIANCE: UpdateStageUIButtons((string)((ArrayList)RefQuestions[5])[4], "House Lore", 2, 9); break;
		    case PlayerHistoryStep.SOCIAL: UpdateStageUIButtons((string)((ArrayList)RefQuestions[6])[4], "Social Lore", 3, 6); break;
            case PlayerHistoryStep.CLASS: UpdateStageUIButtons((string)((ArrayList)RefQuestions[7])[4], "Job Description", 4, 9);  break;
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
                currentStep = PlayerHistoryStep.SOCIAL;
                //menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefQuestions[6])[2], (string)((ArrayList)RefQuestions[6])[3], (string)((ArrayList)RefQuestions[6])[4]);
                break;

            case PlayerHistoryStep.SOCIAL:
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

            case PlayerHistoryStep.SOCIAL:
                HistoryChoice = historyChoicesInt[1];
                currentStep = PlayerHistoryStep.ALLEGIANCE;
                break;

            case PlayerHistoryStep.CLASS:
                HistoryChoice = historyChoicesInt[2];
                currentStep = PlayerHistoryStep.SOCIAL;
                break;

            case PlayerHistoryStep.IMP:
                HistoryChoice = historyChoicesInt[3];
                currentStep = PlayerHistoryStep.CLASS;
                break;

            case PlayerHistoryStep.ORIGIN:
                HistoryChoice = historyChoicesInt[4];
                currentStep = PlayerHistoryStep.IMP;
                break;

            case PlayerHistoryStep.TEMPER:
                HistoryChoice = historyChoicesInt[5];
                currentStep = PlayerHistoryStep.ORIGIN;
                break;

            case PlayerHistoryStep.ASTRO:
                HistoryChoice = historyChoicesInt[6];
                currentStep = PlayerHistoryStep.TEMPER;
                break;

            case PlayerHistoryStep.AFFINITY:
                HistoryChoice = historyChoicesInt[7];
                currentStep = PlayerHistoryStep.ASTRO;
                break;
        }
        GetHistoryUIButtons();
    }



    public void Next() {

        menuGUI.lastActionWasNext = true;

        if (!(HistoryChoice == 0))
        {
            HistorySelectionNext();
            if(currentStep == PlayerHistoryStep.END) {
                HistorySelection.enabled = false;
                menuGUI.WasPredefinedPath = false;
                menuGUI.MenuGoNext(0);
            }

        }
        else {
            menuGUI.dialogue.UpdateDialogue(255, (string)((ArrayList)RefErrors[1])[2], (string)((ArrayList)RefErrors[1])[3]);
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



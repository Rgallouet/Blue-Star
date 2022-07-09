using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PreDefinedSelectionButtons : MonoBehaviour
{
    public DataBaseManager dataBaseManager;
    private ArrayList refData = new ArrayList();
    private ArrayList RefErrors = new ArrayList();


    private Canvas PreDefinedSelection;
    public CharacterDisplay characterDisplay;
    //Link to master
    public MenuGUI menuGUI;

    // Selections
    public HistoryChoices historyChoices = new();
    public DemonPartChoices demonPartsChoices = new();
    public int HistoryChoice;


    // UI
    private Button[] Choice = new Button[10];

    void Start()
    {

        PreDefinedSelection = GetComponent<Canvas>();
        PreDefinedSelection.enabled = false;

        refData = dataBaseManager.getArrayData("select * from REF_PredefinedCharacters order by Id asc");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc");
  

        //Link to left side text box for displaying names
        for (int i = 0; i < 9; i++)
        {
            Choice[i] = PreDefinedSelection.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<Button>()[i];
        }


        GetPreDefinedUIButtons();

    }

    // Display names in buttons
    public void GetPreDefinedUIButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            Choice[i].GetComponentInChildren<Text>().text = (string)((ArrayList)refData[i + 1])[1];

        }
    }

    // Interaction with UI Buttons
    public void MakeChoice(int choice)
    {
        HistoryChoice = choice;
        GetHistorySelectionChoices(choice);
        GetDemonPartsSelectionChoices(choice);
        UpdateDescription(choice);

    }


    // Reading the values of sub-choice for a predefined character chosen
    void GetHistorySelectionChoices(int HistoryChoice)
    {

        historyChoices.HellCircleChoice = (string)((ArrayList)refData[HistoryChoice])[3];
        historyChoices.AllegianceChoice = (string)((ArrayList)refData[HistoryChoice])[4];
        historyChoices.SocialChoice = (string)((ArrayList)refData[HistoryChoice])[5];
        historyChoices.JobChoice = (string)((ArrayList)refData[HistoryChoice])[6];
        historyChoices.ImpChoice = (string)((ArrayList)refData[HistoryChoice])[7];
        historyChoices.OriginChoice = (string)((ArrayList)refData[HistoryChoice])[8];
        historyChoices.TemperChoice = (string)((ArrayList)refData[HistoryChoice])[9];
        historyChoices.AstroChoice = (string)((ArrayList)refData[HistoryChoice])[10];
        historyChoices.AffinityChoice = (string)((ArrayList)refData[HistoryChoice])[11];

        historyChoices.LeadershipCost = 2;


    }

    // Reading the values of sub-choice for a predefined character chosen
    void GetDemonPartsSelectionChoices(int HistoryChoice)
    {

        demonPartsChoices.HeadChoiceID= (int)((ArrayList)refData[HistoryChoice])[12];
        demonPartsChoices.HeadQuality = (int)((ArrayList)refData[HistoryChoice])[13];
        demonPartsChoices.BodyChoiceID = (int)((ArrayList)refData[HistoryChoice])[14];
        demonPartsChoices.BodyQuality = (int)((ArrayList)refData[HistoryChoice])[15];
        demonPartsChoices.RightUpperArmChoiceID = (int)((ArrayList)refData[HistoryChoice])[16];
        demonPartsChoices.RightUpperArmQuality = (int)((ArrayList)refData[HistoryChoice])[17];
        demonPartsChoices.RightLowerArmChoiceID = (int)((ArrayList)refData[HistoryChoice])[18];
        demonPartsChoices.RightLowerArmQuality = (int)((ArrayList)refData[HistoryChoice])[19];
        demonPartsChoices.RightFistChoiceID = (int)((ArrayList)refData[HistoryChoice])[20];
        demonPartsChoices.RightFistQuality = (int)((ArrayList)refData[HistoryChoice])[21];
        demonPartsChoices.RightLegChoiceID = (int)((ArrayList)refData[HistoryChoice])[22];
        demonPartsChoices.RightLegQuality = (int)((ArrayList)refData[HistoryChoice])[23];
        demonPartsChoices.RightFootChoiceID = (int)((ArrayList)refData[HistoryChoice])[24];
        demonPartsChoices.RightFootQuality = (int)((ArrayList)refData[HistoryChoice])[25];
        demonPartsChoices.LeftUpperArmChoiceID = (int)((ArrayList)refData[HistoryChoice])[26];
        demonPartsChoices.LeftUpperArmQuality = (int)((ArrayList)refData[HistoryChoice])[27];
        demonPartsChoices.LeftLowerArmChoiceID = (int)((ArrayList)refData[HistoryChoice])[28];
        demonPartsChoices.LeftLowerArmQuality = (int)((ArrayList)refData[HistoryChoice])[29];
        demonPartsChoices.LeftFistChoiceID = (int)((ArrayList)refData[HistoryChoice])[30];
        demonPartsChoices.LeftFistQuality = (int)((ArrayList)refData[HistoryChoice])[31];
        demonPartsChoices.LeftLegChoiceID = (int)((ArrayList)refData[HistoryChoice])[32];
        demonPartsChoices.LeftLegQuality = (int)((ArrayList)refData[HistoryChoice])[33];
        demonPartsChoices.LeftFootChoiceID = (int)((ArrayList)refData[HistoryChoice])[34];
        demonPartsChoices.LeftFootQuality = (int)((ArrayList)refData[HistoryChoice])[35];

}

    // Update display of the selected predefined character
    void UpdateDescription(int HistoryChoice)
    {

        PreDefinedSelection.GetComponentsInChildren<Text>()[12].text = ((string)((ArrayList)refData[HistoryChoice])[2]).Replace("<br>", "\n");
        characterDisplay.UpdateCharacterDisplay(demonPartsChoices);

    }





    public void Next()
    {


        if (!(HistoryChoice == 0))
        {
            menuGUI.MenuGoNext(0);
            menuGUI.WasPredefinedPath = true;
            PreDefinedSelection.enabled = false;
        }
        else
        {
            menuGUI.dialogue.UpdateDialogue(false, (string)((ArrayList)RefErrors[4])[2], (string)((ArrayList)RefErrors[4])[3], (string)((ArrayList)RefErrors[4])[4]);

        }

    }


    public void Back()
    {
        menuGUI.MenuGoBack(0);
        PreDefinedSelection.enabled = false;
    }


    public void ActivateMenu()
    {
        PreDefinedSelection.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.PREDEFINEDSELECTION;


        if (menuGUI.account.NumberOfDeaths == 0)
        {
            MakeChoice(1);
            Next();
        }

    }







}



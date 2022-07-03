using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PreDefinedSelectionButtons : MonoBehaviour
{
    public DataBaseManager dataBaseManager;
    private ArrayList refData = new ArrayList();
    private ArrayList RefErrors = new ArrayList();
    private ArrayList PlayerAccountStatsBefore;

    private Canvas PreDefinedSelection;
    public CharacterDisplay characterDisplay;
    //Link to master
    public MenuGUI menuGUI;

    // Selections
    public HistoryChoices historyChoices = new();
    public int HistoryChoice;


    // UI
    private Button[] Choice = new Button[10];

    void Start()
    {

        PreDefinedSelection = GetComponent<Canvas>();
        PreDefinedSelection.enabled = false;

        refData = dataBaseManager.getArrayData("select * from REF_PredefinedCharacters order by Id asc");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc");
        PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats");

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
        GetSelectionChoices(choice);
        UpdateDescription(choice);

    }


    // Reading the values of sub-choice for a predefined character chosen
    void GetSelectionChoices(int HistoryChoice)
    {

        historyChoices.HellCircleChoice = (string)((ArrayList)refData[HistoryChoice])[3];
        historyChoices.AllegianceChoice = (string)((ArrayList)refData[HistoryChoice])[4];
        historyChoices.GenusChoice = (string)((ArrayList)refData[HistoryChoice])[5];
        historyChoices.SpeciesChoice = (string)((ArrayList)refData[HistoryChoice])[6];
        historyChoices.JobChoice = (string)((ArrayList)refData[HistoryChoice])[7];
        historyChoices.ImpChoice = (string)((ArrayList)refData[HistoryChoice])[8];
        historyChoices.OriginChoice = (string)((ArrayList)refData[HistoryChoice])[9];
        historyChoices.TemperChoice = (string)((ArrayList)refData[HistoryChoice])[10];
        historyChoices.AstroChoice = (string)((ArrayList)refData[HistoryChoice])[11];
        historyChoices.AffinityChoice = (string)((ArrayList)refData[HistoryChoice])[12];

        historyChoices.LeadershipCost = 2;


    }

    // Update display of the selected predefined character
    void UpdateDescription(int HistoryChoice)
    {

        PreDefinedSelection.GetComponentsInChildren<Text>()[12].text = ((string)((ArrayList)refData[HistoryChoice])[2]).Replace("<br>", "\n");
        characterDisplay.UpdateCharacterDisplay(historyChoices.GetIntListFromStoredChoices(), false);

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



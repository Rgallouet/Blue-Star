using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour {

    // status
	public CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,RESET,MODESELECTION,PREDEFINEDSELECTION,HISTORYSELECTION,STATALLOCATION,FINALSETUP,PLAY}

    // Initiatlisation des calculs
	public HistoryAllocation historyAllocation = new();
    public StatAllocation statAllocation= new();

    // lien vers les UI de perso
    public BackgroundSelectionButtons backgroundSelectionButtons;
    public StatAllocationButtons statAllocationButtons;
    public PreDefinedSelectionButtons preDefinedSelectionButtons;
    public HistorySelectionButtons historySelectionButtons;

    // lien vers les UI menus principaux
    public GameMenuButtons gameMenuButtons;
    public NewGameMenuButtons newGameMenuButtons;
    public ResetGameMenuButtons resetGameMenuButtons;

    // lien vers le background
    public Animator StartScreenAnimation;

    // lien vers dialogue
    public Dialogue dialogue;

    // Variables situationnelles
    public bool lastActionWasNext;

    public string CreationModeSelected;

    // Gestion données référentielles
    public DataBaseManager dataBaseManager;
    public ArrayList RefQuestions = new();

    public SaveAndLoad saveAndLoad;
    public MenuAudio menuAudio;

    public bool WasPredefinedPath;
    public BaseCharacter startingCharacter = new();
    public BaseAccount account;




void Start () {

        //linking the local statAllocation to the statAllocationButtons UI and the historyallocation
        statAllocation.statAllocationButtons = statAllocationButtons;

        // Get objects
        currentState = CreateAPlayerStates.MENU;

		// Initiate transition status
		lastActionWasNext = true;

        // Get the questions strings
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by Id asc");

        // Converting it into the properties
        saveAndLoad.LoadAccountDetails(account);

        dialogue.LoadingScreen(true);

    }



public void MenuGoNext(int Option){
		
        

		lastActionWasNext = true;
        switch (currentState)
        {

            case CreateAPlayerStates.MENU:

                switch (Option)
                {
                    case 1: newGameMenuButtons.ActivateMenu(); break;// I chose "New game" automatically when there is no saved data
                    case 2:
                        dialogue.LoadingScreen(false); 
                        SceneManager.LoadSceneAsync("Undercity"); 
                        break; // I chose "load game" when there is already saved data
                    case 3: resetGameMenuButtons.ActivateMenu(); break; // I chose "New game" when there is already saved data
                }
                break;

            case CreateAPlayerStates.RESET:

                switch (Option)
                {
                    case 0: newGameMenuButtons.ActivateMenu(); break;// I chose to restart a game with saved progress

                }
                break;

            case CreateAPlayerStates.MODESELECTION:

                menuAudio.PlayCreationMenuAudio();
                StartScreenAnimation.SetBool("CharacterCreation", true);

                switch (Option)
                {
                    case 1: // I chose "Guided"
                        CreationModeSelected = "Guided";
                        preDefinedSelectionButtons.ActivateMenu();

                        break;

                    case 2: // I chose "Custom"
                        CreationModeSelected = "Custom";
                        historySelectionButtons.ActivateMenu();
                        break;

                    case 3: // The first time on legacy
                        CreationModeSelected = "Guided direct";
                        preDefinedSelectionButtons.ActivateMenu();
                        break;
                }



                break;



            case CreateAPlayerStates.PREDEFINEDSELECTION:

                // Generate the choices based on the choice made
                startingCharacter.HistoryChoices = preDefinedSelectionButtons.historyChoices;
                startingCharacter.DemonPartChoices = preDefinedSelectionButtons.demonPartsChoices;
                statAllocationButtons.ActivateMenu();

                break;


            case CreateAPlayerStates.HISTORYSELECTION:

                // Generate the choices based on the list of int from history selection
                startingCharacter.HistoryChoices.CreateHistoryChoicesFromInt(historySelectionButtons.historyChoicesInt);
                startingCharacter.DemonPartChoices.DefaultingChoice();

                statAllocationButtons.ActivateMenu();

                    //dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[13])[2], (string)((ArrayList)RefQuestions[13])[3], (string)((ArrayList)RefQuestions[13])[4]);

                break;

            case CreateAPlayerStates.STATALLOCATION:

                startingCharacter.AllocatedStatsModifier = statAllocation.AllocatedStatsModifier;

                backgroundSelectionButtons.ActivateMenu();


                break;

            case CreateAPlayerStates.FINALSETUP:

                dialogue.LoadingScreen(false);

                startingCharacter.characterName = backgroundSelectionButtons.CharacterName; 
                startingCharacter.characterGender = backgroundSelectionButtons.CharacterGender;
                startingCharacter.characterBio = backgroundSelectionButtons.CharacterBio;
                startingCharacter.Experience = 0;
                startingCharacter.characterID = 1;

                // Doing the cleanup in the previous character data and city data
                saveAndLoad.ResetAllCharactersInDataBase();
                saveAndLoad.ResetCityInDataBase();
                saveAndLoad.ResetResourcesInDataBase();

                // Saving updated account records and a new starter demon
                saveAndLoad.SaveCharacterInDataBase(startingCharacter);
                saveAndLoad.SaveCharacterCreationChoicesInDataBase(startingCharacter);
                saveAndLoad.SaveCharacterStatAllocationInDataBase(startingCharacter);

                // Updating account data
                saveAndLoad.SaveAccountDetails(account);


                SceneManager.LoadSceneAsync("Undercity");
                break;
                
        }
	}

public void MenuGoBack(int option){

		lastActionWasNext = false;

		switch (currentState) {
		
		case CreateAPlayerStates.MENU: Application.Quit (); break;
		case CreateAPlayerStates.RESET: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.MODESELECTION: resetGameMenuButtons.ActivateMenu(); break;

		case CreateAPlayerStates.HISTORYSELECTION:
                newGameMenuButtons.ActivateMenu();
                menuAudio.PlayStartGameMenuAudio();
                StartScreenAnimation.SetBool("CharacterCreation", false);
                break;
		case CreateAPlayerStates.PREDEFINEDSELECTION:
                newGameMenuButtons.ActivateMenu();
                menuAudio.PlayStartGameMenuAudio();
                StartScreenAnimation.SetBool("CharacterCreation", false);
                break;

		case CreateAPlayerStates.STATALLOCATION:

			switch (option) {
			case 1: preDefinedSelectionButtons.ActivateMenu(); break;
			case 2: historySelectionButtons.ActivateMenu();	break;}
			break;

		case CreateAPlayerStates.FINALSETUP: statAllocationButtons.ActivateMenu(); break;

		}
	} 
}

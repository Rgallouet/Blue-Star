using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour {

    // status
	public CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,MODESELECTION,PREDEFINEDSELECTION,HISTORYSELECTION,STATALLOCATION,FINALSETUP,SAVE,SAVENAME,PLAY}

    // Initiatlisation des calculs
	public HistoryAllocation historyAllocation = new HistoryAllocation();
    public StatAllocation statAllocation= new StatAllocation();

    // lien vers les UI de perso
    public BackgroundSelectionButtons backgroundSelectionButtons;
    public StatAllocationButtons statAllocationButtons;
    public PreDefinedSelectionButtons preDefinedSelectionButtons;
    public HistorySelectionButtons historySelectionButtons;

    // lien vers les UI menus principaux
    public GameMenuButtons gameMenuButtons;
    public NewGameMenuButtons newGameMenuButtons;
    public SaveGameMenuButtons saveGameMenuButtons;
    public SaveGameNameMenuButtons saveGameNameMenuButtons;
    public LoadGameMenuButtons loadGameMenuButtons;

    // lien vers le background
    public Animator StartScreenAnimation;

    // lien vers dialogue
    public Dialogue dialogue;

    // Variables situationnelles
    public bool lastActionWasNext;
    public string PlayerLastName;
    public string PlayerFirstName;
    public string CreationModeSelected;

    // Gestion données référentielles
    public DataBaseManager dataBaseManager;
    public ArrayList RefQuestions = new ArrayList();
    private ArrayList Names = new ArrayList();
    public ArrayList PlayerAccountStatsBefore;

    public SaveAndLoad saveAndLoad;
    public MenuAudio menuAudio;

    public bool WasPredefinedPath;
    public BasePlayer newPlayer = new BasePlayer();




void Start () {

        //linking the local statAllocation to the statAllocationButtons UI and the historyallocation
        statAllocation.statAllocationButtons = statAllocationButtons;

        // Get objects
        currentState = CreateAPlayerStates.MENU;

		// Initiate transition status
		lastActionWasNext = true;

        // Get the questions strings
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by Id asc");

        // Getting the status
        PlayerAccountStatsBefore = dataBaseManager.getArrayData("select * from PlayerAccountStats", "BlueStarDataWarehouse.db");


    }



public void MenuGoNext(int Option){
		
        

		lastActionWasNext = true;
        switch (currentState)
        {

            case CreateAPlayerStates.MENU:

                switch (Option)
                {
                    case 1: saveGameMenuButtons.ActivateMenu(); break;// I chose "New game"
                    case 2: loadGameMenuButtons.ActivateMenu(); break; // I chose "load game" 
                }
                break;

            case CreateAPlayerStates.LOAD:

                SceneManager.LoadScene("Undercity");

                break;

            case CreateAPlayerStates.SAVE:

                newGameMenuButtons.ActivateMenu();
                
                break;


            case CreateAPlayerStates.MODESELECTION:
                saveGameNameMenuButtons.ActivateMenu();

                switch (Option)
                {
                    case 1: // I chose "Guided"
                        CreationModeSelected = "Guided";
                        break;

                    case 2: // I chose "Custom"
                        CreationModeSelected = "Custom";
                        break;

                    case 3: // The first time on legacy
                        CreationModeSelected = "Guided direct";
                        break;
                }

                break;


            case CreateAPlayerStates.SAVENAME:

                menuAudio.PlayCreationMenuAudio();
                StartScreenAnimation.SetBool("CharacterCreation", true);

                switch (CreationModeSelected)
                {
                    case "Guided": // I chose "Guided"
                        //dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[1])[2], (string)((ArrayList)RefQuestions[1])[3], (string)((ArrayList)RefQuestions[1])[4]);
                        preDefinedSelectionButtons.ActivateMenu();
                        break;

                    case "Custom": // I chose "Custom"
                        //dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[4])[2], (string)((ArrayList)RefQuestions[4])[3], (string)((ArrayList)RefQuestions[4])[4]);
                        CreationModeSelected = "Custom";
                        historySelectionButtons.ActivateMenu();
                        break;

                    case "Guided direct": // The first time on legacy
                        CreationModeSelected = "Guided";
                        preDefinedSelectionButtons.ActivateMenu();
                        break;
                }
                break;


            case CreateAPlayerStates.PREDEFINEDSELECTION:

                newPlayer = historyAllocation.CreateNewPlayer(preDefinedSelectionButtons.historyChoices, dataBaseManager);

                statAllocationButtons.ActivateMenu();

                break;


            case CreateAPlayerStates.HISTORYSELECTION:

                    newPlayer = historyAllocation.CreateNewPlayer(historySelectionButtons.historyChoices, dataBaseManager);

                    statAllocationButtons.ActivateMenu();

                    //dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[13])[2], (string)((ArrayList)RefQuestions[13])[3], (string)((ArrayList)RefQuestions[13])[4]);

                break;

            case CreateAPlayerStates.STATALLOCATION:

                newPlayer.AllocatedStatsModifier = statAllocation.AllocatedStatsModifier;

                backgroundSelectionButtons.ActivateMenu();


                break;

            case CreateAPlayerStates.FINALSETUP:


                newPlayer.PlayerFirstName = PlayerFirstName;
                newPlayer.PlayerLastName = PlayerLastName;
                newPlayer.PlayerGender = backgroundSelectionButtons.PlayerGender;
                newPlayer.PlayerBio = backgroundSelectionButtons.PlayerBio;

                saveAndLoad.SavePlayerChoicesInDataBase(newPlayer, true);
                
                SceneManager.LoadScene("Undercity");
                break;
                
        }
	}

public void MenuGoBack(int option){

		lastActionWasNext = false;

		switch (currentState) {
		
		case CreateAPlayerStates.MENU: Application.Quit (); break;
		case CreateAPlayerStates.LOAD: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.SAVE: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.SAVENAME: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.MODESELECTION: saveGameMenuButtons.ActivateMenu(); break;

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

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

    // lien vers dialogue
    public Dialogue dialogue;

    // Variables situationnelles
    public bool lastActionWasNext;
    public bool isThereAnySavedDataOnTheMachine;
    public string PlayerLastName;
    public string PlayerFirstName;


    // Gestion données référentielles
    public DataBaseManager dataBaseManager;
    private ArrayList RefQuestions = new ArrayList();
    private ArrayList Names = new ArrayList();
    public ArrayList PlayerAccountStatsBefore;

    public SaveAndLoad saveAndLoad;
    public MenuAudio menuAudio;

    public int Slot;
    public bool WasPredefinedPath;
    public BasePlayer newPlayer = new BasePlayer();




void Start () {

        //linking the local statAllocation to the statAllocationButtons UI and the historyallocation
        statAllocation.statAllocationButtons = statAllocationButtons;

        // Get objects
        currentState = CreateAPlayerStates.MENU;

		// Initiate transition status
		lastActionWasNext = true;

        // Checking if there exist a saved game
        Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc");
        if ((string)((ArrayList)Names[1])[2] == null)
        {
            isThereAnySavedDataOnTheMachine = false;
        }

        // Get the questions strings
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by Id asc");

        // Getting the status of each save slots
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

                saveAndLoad.SettingTheCurrentSaveSlot(Slot);
                SceneManager.LoadScene("Undercity");

                break;

            case CreateAPlayerStates.SAVE:

                saveAndLoad.SettingTheCurrentSaveSlot(Slot);
                saveGameNameMenuButtons.ActivateMenu();
                break;

           case CreateAPlayerStates.SAVENAME:
                newGameMenuButtons.ActivateMenu();
                break;

            case CreateAPlayerStates.MODESELECTION:
                //menuAudio.PlayCreationMenuAudio();
                switch (Option)
                {
                    case 1: // I chose "Guided"
                        dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[1])[2], (string)((ArrayList)RefQuestions[1])[3], (string)((ArrayList)RefQuestions[1])[4]);
                        preDefinedSelectionButtons.ActivateMenu();
                        break;

                    case 2: // I chose "Custom"
                        dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[4])[2], (string)((ArrayList)RefQuestions[4])[3], (string)((ArrayList)RefQuestions[4])[4]);
                        historySelectionButtons.ActivateMenu();
                        break;

                    case 3: // The first time on legacy
                        preDefinedSelectionButtons.ActivateMenu();
                        break;
                }
                break;

            case CreateAPlayerStates.PREDEFINEDSELECTION:

                newPlayer = historyAllocation.CreateNewPlayer(preDefinedSelectionButtons.historyChoices, dataBaseManager);
                statAllocationButtons.ActivateMenu();
                if (isThereAnySavedDataOnTheMachine == true)
                        {
                        dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[2])[2], (string)((ArrayList)RefQuestions[2])[3], (string)((ArrayList)RefQuestions[2])[4]);
                        }
                

                break;


            case CreateAPlayerStates.HISTORYSELECTION:

                    newPlayer = historyAllocation.CreateNewPlayer(historySelectionButtons.historyChoices, dataBaseManager);

                    statAllocationButtons.ActivateMenu();

                    dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[13])[2], (string)((ArrayList)RefQuestions[13])[3], (string)((ArrayList)RefQuestions[13])[4]);

                break;

            case CreateAPlayerStates.STATALLOCATION:

                newPlayer.AllocatedStatsModifier = statAllocation.AllocatedStatsModifier;

                backgroundSelectionButtons.ActivateMenu();

                if (isThereAnySavedDataOnTheMachine == true)
                {
                    dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[3])[2], (string)((ArrayList)RefQuestions[3])[3], (string)((ArrayList)RefQuestions[3])[4]);
                }

                break;

            case CreateAPlayerStates.FINALSETUP:


                newPlayer.PlayerFirstName = PlayerFirstName;
                newPlayer.PlayerLastName = PlayerLastName;
                newPlayer.PlayerGender = backgroundSelectionButtons.PlayerGender;
                newPlayer.PlayerBio = backgroundSelectionButtons.PlayerBio;

                saveAndLoad.SavePlayerChoicesInDataBase(newPlayer);



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
				//menuAudio.PlayStartGameMenuAudio();
			break;

		case CreateAPlayerStates.PREDEFINEDSELECTION:
                newGameMenuButtons.ActivateMenu();
                //menuAudio.PlayStartGameMenuAudio();
                break;

		case CreateAPlayerStates.STATALLOCATION:

			switch (option) {
			case 1: preDefinedSelectionButtons.ActivateMenu(); break;
			case 2: historySelectionButtons.ActivateMenu();	break;}
			break;

		case CreateAPlayerStates.FINALSETUP:
                statAllocationButtons.ActivateMenu();
			break;

		

		}
	}

    /*

    void Update ()
    {
        RenderSettings.fogColor = TransformHSV(RenderSettings.fogColor, 0.03f, 1, 1);

    }
    Color TransformHSV(Color Color, float HueShift, float SaturationMultiplier, float ValueMultiplier)
{
    float VSU = ValueMultiplier * SaturationMultiplier * Mathf.Cos(HueShift * Mathf.PI / 180);
    float VSW = ValueMultiplier * SaturationMultiplier * Mathf.Sin(HueShift * Mathf.PI / 180);

    Color ret = new Color();

    ret.r = (.299f* ValueMultiplier + .701f*VSU+.168f*VSW)* Color.r + (.587f* ValueMultiplier - .587f*VSU+.330f*VSW)* Color.g  + (.114f* ValueMultiplier - .114f*VSU-.497f*VSW)* Color.b;

    ret.g = (.299f* ValueMultiplier - .299f*VSU-.328f*VSW)* Color.r + (.587f* ValueMultiplier + .413f*VSU+.035f*VSW)* Color.g + (.114f* ValueMultiplier - .114f*VSU+.292f*VSW)* Color.b;

    ret.b = (.299f* ValueMultiplier - .3f*VSU+1.25f*VSW)* Color.r + (.587f* ValueMultiplier - .588f*VSU-1.05f*VSW)* Color.g + (.114f* ValueMultiplier + .886f*VSU-.203f*VSW)* Color.b;

    return ret;
}


    */
}

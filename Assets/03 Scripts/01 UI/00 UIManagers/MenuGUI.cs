using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour {

    // status
	public CreateAPlayerStates currentState;
	public enum CreateAPlayerStates{MENU,LOAD,MODESELECTION,PREDEFINEDSELECTION,HISTORYSELECTION,STATALLOCATION,FINALSETUP,SAVE,PLAY}


    // Initiatlisation des calculs
	public HistoryAllocation historyAllocation = new HistoryAllocation();
    public StatAllocation statAllocation= new StatAllocation();
    public BackgroundAllocation backgroundAllocation = new BackgroundAllocation();

    // lien vers les UI de perso
    public BackgroundSelectionButtons backgroundSelectionButtons;
    public StatAllocationButtons statAllocationButtons;
    public PreDefinedSelectionButtons preDefinedSelectionButtons;
    public HistorySelectionButtons historySelectionButtons;

    // lien vers les UI menus principaux
    public GameMenuButtons gameMenuButtons;
    public NewGameMenuButtons newGameMenuButtons;
    public SaveGameMenuButtons saveGameMenuButtons;
    public LoadGameMenuButtons loadGameMenuButtons;

    // lien vers dialogue
    public Dialogue dialogue;

    // Variables situationnelles
    public bool lastActionWasNext;


    // Gestion données référentielles
    public DataBaseManager dataBaseManager;
    private ArrayList RefQuestions = new ArrayList();


    public MenuAudio menuAudio;

    public int Slot;
    public bool WasPredefinedPath;




void Start () {

        //linking the local statAllocation to the statAllocationButtons UI
        statAllocation.statAllocationButtons = statAllocationButtons;

        // Get objects
        currentState = CreateAPlayerStates.MENU;

		// Initiate transition status
		lastActionWasNext = true;

        // Get the questions strings
        RefQuestions = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='CharacterCreation' order by Id asc");

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

            case CreateAPlayerStates.LOAD: SceneManager.LoadScene("Underground City"); break;

            case CreateAPlayerStates.SAVE: newGameMenuButtons.ActivateMenu(); break;

            case CreateAPlayerStates.MODESELECTION:
                menuAudio.PlayCreationMenuAudio();
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
                }
                break;

            case CreateAPlayerStates.PREDEFINEDSELECTION:
                    historyAllocation.dataBaseManager = dataBaseManager;

                    historyAllocation.CreateNewPlayer(
                        preDefinedSelectionButtons.HellCircleChoice, 
                        preDefinedSelectionButtons.AllegianceChoice, 
                        preDefinedSelectionButtons.GenusChoice,
                        preDefinedSelectionButtons.SpeciesChoice, 
                        preDefinedSelectionButtons.JobChoice, 
                        preDefinedSelectionButtons.ImpChoice, 
                        preDefinedSelectionButtons.OriginChoice,
                        preDefinedSelectionButtons.TemperChoice, 
                        preDefinedSelectionButtons.AstroChoice, 
                        preDefinedSelectionButtons.AffinityChoice);

                    statAllocationButtons.ActivateMenu();

                    dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[2])[2], (string)((ArrayList)RefQuestions[2])[3], (string)((ArrayList)RefQuestions[2])[4]);

                break;


            case CreateAPlayerStates.HISTORYSELECTION:

                    historyAllocation.CreateNewPlayer(
                        historySelectionButtons.HellCircleChoice,
                        historySelectionButtons.AllegianceChoice,
                        historySelectionButtons.GenusChoice,
                        historySelectionButtons.SpeciesChoice,
                        historySelectionButtons.JobChoice,
                        historySelectionButtons.ImpChoice,
                        historySelectionButtons.OriginChoice,
                        historySelectionButtons.TemperChoice,
                        historySelectionButtons.AstroChoice,
                        historySelectionButtons.AffinityChoice);

                    statAllocationButtons.ActivateMenu();

                    dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[13])[2], (string)((ArrayList)RefQuestions[13])[3], (string)((ArrayList)RefQuestions[13])[4]);

                break;

            case CreateAPlayerStates.STATALLOCATION:

                statAllocation.StoreStatAllocation();
                backgroundSelectionButtons.ActivateMenu();
                dialogue.UpdateDialogue(false, (string)((ArrayList)RefQuestions[3])[2], (string)((ArrayList)RefQuestions[3])[3], (string)((ArrayList)RefQuestions[3])[4]);

                break;

            case CreateAPlayerStates.FINALSETUP:

                backgroundAllocation.StoreLastInfo(
                    backgroundSelectionButtons.PlayerFirstName, 
                    backgroundSelectionButtons.PlayerLastName, 
                    backgroundSelectionButtons.PlayerBio, 
                    backgroundSelectionButtons.PlayerGender);

                SavePlayerChoicesInDataBase(Slot);

                SceneManager.LoadScene("Underground City");
                break;
                
        }

		
	}

public void MenuGoBack(int option){

		lastActionWasNext = false;

		switch (currentState) {
		
		case CreateAPlayerStates.MENU: Application.Quit (); break;
		case CreateAPlayerStates.LOAD: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.SAVE: gameMenuButtons.ActivateMenu(); break;
        case CreateAPlayerStates.MODESELECTION: saveGameMenuButtons.ActivateMenu(); break;

		case CreateAPlayerStates.HISTORYSELECTION:
                newGameMenuButtons.ActivateMenu();
				menuAudio.PlayGameMenuAudio();
			break;

		case CreateAPlayerStates.PREDEFINEDSELECTION:
                newGameMenuButtons.ActivateMenu();
                menuAudio.PlayGameMenuAudio();
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

    void SavePlayerChoicesInDataBase(int Slot)
    {

        string[] PlayerStaticChoicesValues = {

            "FirstName = '" +       backgroundAllocation.PlayerFirstName + "'",
            "LastName = '" +        backgroundAllocation.PlayerLastName + "'",
            "Bio = '" +             backgroundAllocation.PlayerBio + "'",
            "Gender = '" +          backgroundAllocation.PlayerGender + "'",

            "HellCircleChoice = " + historyAllocation.HellCircleChoice,
            "AllegianceChoice = " + historyAllocation.AllegianceChoice,
            "GenusChoice = " +      historyAllocation.GenusChoice,
            "SpeciesChoice = " +    historyAllocation.SpeciesChoice,
            "JobChoice = " +        historyAllocation.JobChoice,
            "ImpChoice = " +        historyAllocation.ImpChoice,
            "OriginChoice = "  +    historyAllocation.OriginChoice,
            "TemperChoice = " +     historyAllocation.TemperChoice ,
            "AstroChoice = " +      historyAllocation.AstroChoice,
            "AffinityChoice = " +   historyAllocation.AffinityChoice

        };

        dataBaseManager.UpdateData("PlayerStaticChoices", "Slot=" + Slot, PlayerStaticChoicesValues);

        string[] PlayerStatsModifiersValues = {

            "Strength = " +     statAllocation.StatModifier[0]  ,
            "Speed = " +        statAllocation.StatModifier[1]  ,
            "Dexterity = " +    statAllocation.StatModifier[2]  ,
            "Embodiment = " +   statAllocation.StatModifier[3]  ,
            "Reflex = " +       statAllocation.StatModifier[4]  ,
            "Resilience = " +   statAllocation.StatModifier[5]  ,
            "Knowledge = " +    statAllocation.StatModifier[6]  ,
            "Elocution = " +    statAllocation.StatModifier[7]  ,
            "Intellect = " +    statAllocation.StatModifier[8]  ,
            "Influence = " +    statAllocation.StatModifier[9]  ,
            "Focus = " +        statAllocation.StatModifier[10]  ,
            "Mockery = " +      statAllocation.StatModifier[11]  ,
            "Malevolent = " +   statAllocation.StatModifier[12]  ,
            "Unmerciful = " +   statAllocation.StatModifier[13]  ,
            "Rage = " +         statAllocation.StatModifier[14]  ,
            "Phase = " +        statAllocation.StatModifier[15]  ,
            "Momentum = " +     statAllocation.StatModifier[16]  ,
            "Balance = " +      statAllocation.StatModifier[17]  ,
            "Chaos = " +        statAllocation.StatModifier[18]  ,
            "Luck = " +         statAllocation.StatModifier[19]  ,
            "Perception = " +   statAllocation.StatModifier[20]  ,
            "Judgement = " +    statAllocation.StatModifier[21]  ,

        };

        dataBaseManager.UpdateData("PlayerStatsModifiers", "Slot=" + Slot + " and ModifierSource='PlayerCreation' ", PlayerStatsModifiersValues);


    }


}

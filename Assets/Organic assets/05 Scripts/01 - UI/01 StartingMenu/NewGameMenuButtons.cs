using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour
{


    public DataBaseManager dataBaseManager;
    public MenuGUI menuGUI;
    private Canvas newGameMenu;

    private Button buttonBack;
    private Button buttonStartDemon;
    private Button buttonSelectDemon;
    private Button buttonCreateDemon;

    private Image areaRequirementSelectDemonForDeath;
    private Image areaRequirementCreateDemonForDeath;

    private Text textRequirementSelectDemonForDeath;
    private Text textRequirementSelectDemonForExperience;
    private Text textRequirementCreateDemonForDeath;
    private Text textRequirementCreateDemonForExperience;

    private Text textStartDemon;
    private Text textSelectDemon;
    private Text textCreateDemon;

    private Color32 colourInactive;
    private Color32 colourActive;

    private Text nameField;

    private ArrayList RefErrors = new();

    void Start()
    {

        newGameMenu = GetComponent<Canvas>();
        newGameMenu.enabled = false;

        buttonBack = newGameMenu.GetComponentsInChildren<Button>()[3];
        buttonStartDemon = newGameMenu.GetComponentsInChildren<Button>()[0];
        buttonSelectDemon = newGameMenu.GetComponentsInChildren<Button>()[1];
        buttonCreateDemon = newGameMenu.GetComponentsInChildren<Button>()[2];

        areaRequirementSelectDemonForDeath = newGameMenu.GetComponentsInChildren<Image>()[3];
        areaRequirementCreateDemonForDeath = newGameMenu.GetComponentsInChildren<Image>()[5];

        textRequirementSelectDemonForDeath = areaRequirementSelectDemonForDeath.GetComponentsInChildren<Text>()[3];
        textRequirementSelectDemonForExperience = areaRequirementSelectDemonForDeath.GetComponentsInChildren<Text>()[4];
        textRequirementCreateDemonForDeath = areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[3];
        textRequirementCreateDemonForExperience = areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[4];

        textStartDemon = newGameMenu.GetComponentsInChildren<Text>()[4];
        textSelectDemon = newGameMenu.GetComponentsInChildren<Text>()[6];
        textCreateDemon = newGameMenu.GetComponentsInChildren<Text>()[13];

        nameField = (newGameMenu.GetComponentsInChildren<Image>()[0]).GetComponentsInChildren<Text>()[1];

        colourInactive = new Color32(255, 255, 255, 125);
        colourActive = new Color32(255, 255, 255, 255);

    }


    public void Update()
    {

        if ((nameField.text == null) || (nameField.text == "") || (nameField.text == " "))
        {

            buttonStartDemon.interactable = false;
            buttonStartDemon.GetComponentInChildren<Text>().color= colourInactive;
            textStartDemon.color = colourInactive;
        }
        else
        {
            buttonStartDemon.interactable = true;
            buttonStartDemon.GetComponentInChildren<Text>().color = colourActive;
            textStartDemon.color = colourActive;

        }


    }



    public void Next(int mode)
    {

        if ((nameField.text == null) || (nameField.text == "") || (nameField.text == " "))
        {
            // Asking player to choose a name
            RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' and Trigger='MissingNameChoice'");
            menuGUI.dialogue.UpdateDialogue(150, (string)((ArrayList)RefErrors[1])[3], (string)((ArrayList)RefErrors[1])[4]);
        }
        else
        {
            // Updating name
            menuGUI.account.AccountName = nameField.text;

            // Resetting the city
            menuGUI.account.CurrentCityTier = 0;

            // Going to next stage
            menuGUI.MenuGoNext(mode);
            newGameMenu.enabled = false;
        }

    }

    public void Back()
    {
        if ((nameField.text == null) || (nameField.text == "") || (nameField.text == " "))
        {
            Application.Quit();

        }
        else
        {
            menuGUI.MenuGoBack(0);
            newGameMenu.enabled = false;

        }

    }

    public void ActivateMenu()
    {

        newGameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.MODESELECTION;

        textRequirementSelectDemonForDeath.text = menuGUI.account.NumberOfDeaths + " / 1";
        textRequirementCreateDemonForDeath.text = menuGUI.account.NumberOfDeaths + " / 2";
        textRequirementSelectDemonForExperience.text = menuGUI.account.MaximumLevelReached + " / 10";
        textRequirementCreateDemonForExperience.text = menuGUI.account.MaximumLevelReached + " / 30";


        if (menuGUI.account.NumberOfDeaths >= 1)
        {
            textRequirementSelectDemonForDeath.color = new Color32(20, 255, 20, 255);
        }


        if (menuGUI.account.MaximumLevelReached >= 10)
        {
            textRequirementSelectDemonForDeath.color = new Color32(20, 255, 20, 255);
        }


        if (menuGUI.account.NumberOfDeaths >= 2)
        {
            textRequirementSelectDemonForDeath.color = new Color32(20, 255, 20, 255);
        }


        if (menuGUI.account.MaximumLevelReached >= 30)
        {
            textRequirementSelectDemonForDeath.color = new Color32(20, 255, 20, 255);
        }

        if (!(menuGUI.account.AccountName == " "))
        {
            nameField.text = menuGUI.account.AccountName;
        }

        if (menuGUI.account.NumberOfDeaths < 1 || menuGUI.account.MaximumLevelReached < 10)
        {

            buttonCreateDemon.interactable = false;
            buttonCreateDemon.GetComponentInChildren<Text>().color = colourInactive;

            buttonSelectDemon.interactable = false;
            buttonSelectDemon.GetComponentInChildren<Text>().color = colourInactive;

            textSelectDemon.color = colourInactive;
            textCreateDemon.color = colourInactive;


            areaRequirementSelectDemonForDeath.GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 50);
            areaRequirementSelectDemonForDeath.GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 50);
            areaRequirementSelectDemonForDeath.GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 50);
            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 50);
            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 50);
            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 50);
               
        
        }


        else if (menuGUI.account.NumberOfDeaths < 2 || menuGUI.account.MaximumLevelReached < 30)
        {
            buttonCreateDemon.interactable = false;
            buttonCreateDemon.GetComponentInChildren<Text>().color = colourInactive;

            textCreateDemon.color = colourInactive;

            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 50);
            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 50);
            areaRequirementCreateDemonForDeath.GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 50);
        }


    }





}

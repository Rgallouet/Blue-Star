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

    private Text textRequirementSelectDemonForDeath;
    private Text textRequirementSelectDemonForExperience;
    private Text textRequirementCreateDemonForDeath;
    private Text textRequirementCreateDemonForExperience;

    private Text nameField;

    private ArrayList RefErrors = new();

    void Start()
    {

        newGameMenu = GetComponent<Canvas>();
        newGameMenu.enabled = false;

        buttonBack = newGameMenu.GetComponentsInChildren<Button>()[0];
        buttonStartDemon = newGameMenu.GetComponentsInChildren<Button>()[1];
        buttonSelectDemon = newGameMenu.GetComponentsInChildren<Button>()[2];
        buttonCreateDemon = newGameMenu.GetComponentsInChildren<Button>()[3];

        textRequirementSelectDemonForDeath = (newGameMenu.GetComponentsInChildren<Image>()[5]).GetComponentsInChildren<Text>()[3];
        textRequirementSelectDemonForExperience = (newGameMenu.GetComponentsInChildren<Image>()[5]).GetComponentsInChildren<Text>()[4];
        textRequirementCreateDemonForDeath = (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[3];
        textRequirementCreateDemonForExperience = (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[4];


        nameField = (newGameMenu.GetComponentsInChildren<Image>()[4]).GetComponentsInChildren<Text>()[1];

    }


    public void Update()
    {

        if ((nameField.text == null) || (nameField.text == "") || (nameField.text == " "))
        {

            buttonStartDemon.interactable = false;
            buttonStartDemon.GetComponentInChildren<Text>().color= new Color32(255, 255, 255, 125);
            newGameMenu.GetComponentsInChildren<Text>()[9].color = new Color32(255, 255, 255, 125);
        }
        else
        {
            buttonStartDemon.interactable = true;
            buttonStartDemon.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
            newGameMenu.GetComponentsInChildren<Text>()[9].color = new Color32(255, 255, 255, 255);

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
            buttonCreateDemon.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 125);

            buttonSelectDemon.interactable = false;
            buttonSelectDemon.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 125);

            newGameMenu.GetComponentsInChildren<Text>()[7].color = new Color32(255, 255, 255, 125);
            newGameMenu.GetComponentsInChildren<Text>()[8].color = new Color32(255, 255, 255, 125);


            (newGameMenu.GetComponentsInChildren<Image>()[5]).GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[5]).GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[5]).GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 125);
               
        
        }


        else if (menuGUI.account.NumberOfDeaths < 2 || menuGUI.account.MaximumLevelReached < 30)
        {
            buttonCreateDemon.interactable = false;
            buttonCreateDemon.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 125);

            newGameMenu.GetComponentsInChildren<Text>()[7].color = new Color32(255, 255, 255, 125);

            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[0].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[1].color = new Color32(0, 0, 0, 125);
            (newGameMenu.GetComponentsInChildren<Image>()[6]).GetComponentsInChildren<Text>()[2].color = new Color32(0, 0, 0, 125);
        }


    }





}

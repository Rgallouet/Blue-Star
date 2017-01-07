using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas NewGameMenu;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();


    public Button CustomButton;
    public Text CustomText;

    void Start(){
		NewGameMenu = GetComponent<Canvas>();
		NewGameMenu.enabled = false;

        Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc", "BlueStarDataWarehouse.db");


    }

    public void Next(int mode)
    {
        menuGUI.MenuGoNext(mode);
        NewGameMenu.enabled = false;
    }

    public void Back(){
        menuGUI.MenuGoBack (0);
        NewGameMenu.enabled = false;

    }

    public void ActivateMenu()
    {
        NewGameMenu.enabled = true;
        if ((string)((ArrayList)Names[menuGUI.Slot])[2] == null)
        {
            CustomButton.GetComponentInChildren<Text>().text = "";
            CustomButton.interactable = false;
            CustomText.text = "";

        }
        else {
            CustomButton.interactable = true;
            CustomButton.GetComponentInChildren<Text>().text = "Custom mode";
            CustomText.text = "For demon rebirths (experienced players)";
        }
       
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.MODESELECTION;
    }





}

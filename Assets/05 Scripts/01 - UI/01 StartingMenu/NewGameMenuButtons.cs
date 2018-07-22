using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas NewGameMenu;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();

    /* Alternative #1 : hiding the second choice
    public Button CustomButton;
    public Text TextCustom;
    */

    void Start(){

    NewGameMenu = GetComponent<Canvas>();
    NewGameMenu.enabled = false;
    Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc");

    }

    public void Next(int mode){
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
    menuGUI.currentState = MenuGUI.CreateAPlayerStates.MODESELECTION;

        /* Alternative #1 : hiding the second choice

        if ((string)((ArrayList)Names[menuGUI.Slot])[2] == null)
        {
            CustomButton.GetComponentInChildren<Text>().text = "";
            CustomButton.interactable = false;
            TextCustom.text = "";
        }
        else {
            CustomButton.interactable = true;
            CustomButton.GetComponentInChildren<Text>().text = "Custom mode";
            TextCustom.text = "For demon rebirths (experienced players)";
             }

        */
        

     if ((string)((ArrayList)Names[menuGUI.Slot])[2] == null)
        {
        Next(1);
        }

}





}

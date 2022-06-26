using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas NewGameMenu;

    void Start(){

    NewGameMenu = GetComponent<Canvas>();
    NewGameMenu.enabled = false;

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


}





}

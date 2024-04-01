using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CityButtons : MonoBehaviour {

    public WindowsCamera windowsCamera;
    public MenuAudio MenuAudio;
    public ExplorationMenu explorationMenu;
    public CharacterMenu characterMenu;
    public SettingsMenu settingsMenu;

    public int MenuOpened;


    private Color32 activeMenuColor = new Color32(100, 100, 255,255);
    private Color32 inactiveMenuColor = new Color32(255, 255, 255, 255);

    void Start(){
        MenuAudio.PlayCityAudio();
        MenuOpened = 1;

        ChangeColourButton(1, false);
        ChangeColourButton(2, false);
        ChangeColourButton(3, false);
        ChangeColourButton(4, false);
        ChangeColourButton(5, false);
        ChangeColourButton(6, false);


    }


    public void ClickMenu(int choice) {

        if (choice == 1 && MenuOpened==1) OpenMenu(choice);
        else if (MenuOpened == choice) CloseMenu();
        else {
            Debug.Log("switching to different menu");
            CloseMenu();
            OpenMenu(choice);
        }
    }

	public void OpenMenu(int choice) {
        MenuOpened = choice;
        MenuAudio.PlayMenuInGameAudio();

        if (choice>1)
        {
            ChangeColourButton(choice, true);
        }

        switch (choice) {
            case 1:
                if (explorationMenu.explorationMenuOpened == true)
                {
                    explorationMenu.DesactivateSubMenu("exploration");
                    ChangeColourButton(choice, false);
                }
                else
                {
                    if (windowsCamera.characterMoving == null) windowsCamera.characterMoving = windowsCamera.cubeManager.playerInstantiated.gameObject;
                    if (explorationMenu.selectionMenuOpened == false) explorationMenu.ActivateSubMenu("selection");
                    explorationMenu.ActivateSubMenu("exploration");
                    ChangeColourButton(choice, true);
                }
                break;
            case 2:
                if (windowsCamera.characterMoving == null) windowsCamera.characterMoving = windowsCamera.cubeManager.playerInstantiated.gameObject;
                characterMenu.ActivateMenu(windowsCamera.characterMoving.GetComponentInChildren<GameObjectInformation>().baseCharacter); 
                break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6:
                settingsMenu.ActivateMenu();
                break;
        }

    }

    public void DoAction(int choice)
    {
        switch (choice)
        {

            case 1:
                // Digging
                if (windowsCamera.characterMoving == null) windowsCamera.characterMoving = windowsCamera.cubeManager.playerInstantiated.gameObject;
                windowsCamera.characterMoving.GetComponent<PlayerController>().actionRequested = true;
                break;

            case 2:
                // Do an action
                break;
        }

    }

    public void CloseMenu()
    {
        MenuAudio.PlayCityAudio();

        ChangeColourButton(MenuOpened, false);

        switch (MenuOpened)
        {
            case 1: explorationMenu.DesactivateMenu(); break;
            case 2: characterMenu.DesactivateMenu(); break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: settingsMenu.DesactivateMenu(); break;
        }

        MenuOpened = 1;

    }

    public void ChangeColourButton(int buttonNumber, bool active) 
    {
        Button button = gameObject.GetComponentsInChildren<Button>()[buttonNumber - 1];

        if (button.interactable == false) button.interactable = true;

        switch (active) 
        {
            case true:
                button.GetComponentInChildren<Text>().color = activeMenuColor;
                button.GetComponentInChildren<Image>().color = activeMenuColor;
                button.GetComponentsInChildren<Image>()[1].color = activeMenuColor;
                break;

            case false:
                button.GetComponentInChildren<Text>().color = inactiveMenuColor;
                button.GetComponentInChildren<Image>().color = inactiveMenuColor;
                button.GetComponentsInChildren<Image>()[1].color = inactiveMenuColor;
                break;

        }

        

    }

}

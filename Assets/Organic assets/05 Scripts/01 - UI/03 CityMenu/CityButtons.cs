using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityButtons : MonoBehaviour {


    public Image[] UIButtons = new Image[3];

    public WindowsCamera windowsCamera;

    public MenuAudio MenuAudio;
    public CharacterMenu characterMenu;
    public SettingsMenu settingsMenu;

	private int MenuOpened;


    private Color32 ActiveMenuColor = new Color32(180, 0, 0,255);
    private Color32 InactiveMenuColor = new Color32(255, 100, 100,100);

    void Start(){
        MenuAudio.PlayCityAudio();
        
    }


    public void ClickMenu(int choice) {

        if (MenuOpened== choice)  CloseMenu();
        else if (MenuOpened == 0) OpenMenu(choice);
        else {
            CloseMenu();
            OpenMenu(choice);
        }


    }

	public void OpenMenu(int choice) {
        MenuOpened = choice;
        MenuAudio.PlayMenuInGameAudio();



        switch (choice) {
            case 1: 
                settingsMenu.ActivateMenu(); 
                break;
            case 2:
                if (windowsCamera.characterSelected == null) windowsCamera.characterSelected = windowsCamera.cubeManager.playerInstantiated.gameObject;
                characterMenu.ActivateMenu(windowsCamera.characterSelected.GetComponentInChildren<GameObjectInformation>().baseCharacter); 
                break;
            case 3: break;
            case 4:
                if (windowsCamera.characterSelected == null) windowsCamera.characterSelected = windowsCamera.cubeManager.playerInstantiated.gameObject;
                windowsCamera.characterSelected.GetComponent<PlayerController>().actionRequested = true;
                break;

        }

    }

    public void DoAction(int choice)
    {
        switch (choice)
        {

            case 1:
                // Digging
                if (windowsCamera.characterSelected == null) windowsCamera.characterSelected = windowsCamera.cubeManager.playerInstantiated.gameObject;
                windowsCamera.characterSelected.GetComponent<PlayerController>().actionRequested = true;
                break;

            case 2:
                // Do an action
                break;
        }

    }

    public void CloseMenu()
    {
        MenuAudio.PlayCityAudio();
        UIButtons[MenuOpened-1].GetComponent<Button>().interactable = false;
        UIButtons[MenuOpened-1].GetComponent<Button>().interactable = true;

        switch (MenuOpened)
        {
            case 1: settingsMenu.DesactivateMenu(); break;
            case 2: characterMenu.DesactivateMenu(); break;
            case 3: break;

        }

        MenuOpened = 0;

    }

}

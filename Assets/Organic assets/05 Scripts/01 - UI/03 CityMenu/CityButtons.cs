using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityButtons : MonoBehaviour {

    public WindowsCamera windowsCamera;
    public MenuAudio MenuAudio;
    public SelectionMenu selectionMenu;
    public CharacterMenu characterMenu;
    public SettingsMenu settingsMenu;


	private int MenuOpened;


    private Color32 ActiveMenuColor = new Color32(255, 255, 255,255);
    private Color32 InactiveMenuColor = new Color32(255, 255, 255,100);

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

        gameObject.GetComponentsInChildren<Button>()[MenuOpened - 1].GetComponentInChildren<Text>().color = ActiveMenuColor;
        gameObject.GetComponentsInChildren<Button>()[MenuOpened - 1].GetComponentInChildren<Image>().color = ActiveMenuColor;

        switch (choice) {
            case 1:
                if (windowsCamera.characterSelected == null) windowsCamera.characterSelected = windowsCamera.cubeManager.playerInstantiated.gameObject;
                windowsCamera.characterSelected.GetComponent<PlayerController>().actionRequested = true;
                break;
            case 2:
                if (windowsCamera.characterSelected == null) windowsCamera.characterSelected = windowsCamera.cubeManager.playerInstantiated.gameObject;
                characterMenu.ActivateMenu(windowsCamera.characterSelected.GetComponentInChildren<GameObjectInformation>().baseCharacter); 
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
        gameObject.GetComponentsInChildren<Button>()[MenuOpened-1].GetComponent<Button>().interactable = false;
        gameObject.GetComponentsInChildren<Button>()[MenuOpened-1].GetComponent<Button>().interactable = true;

        gameObject.GetComponentsInChildren<Button>()[MenuOpened - 1].GetComponentInChildren<Text>().color= InactiveMenuColor;
        gameObject.GetComponentsInChildren<Button>()[MenuOpened - 1].GetComponentInChildren<Image>().color = InactiveMenuColor;

        switch (MenuOpened)
        {
            case 1: break;
            case 2: characterMenu.DesactivateMenu(); break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: settingsMenu.DesactivateMenu(); break;


        }

        MenuOpened = 0;

    }

}

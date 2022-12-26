using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityButtons : MonoBehaviour {

    public Image[] UIButtons = new Image[3];

    public Button ExitMenu;

    public WindowsCamera windowsCamera;

    public MenuAudio MenuAudio;
    public CharacterMenu characterMenu;
    public SettingsMenu settingsMenu;

    public BaseCharacter selectedCharacter;

	private int MenuOpened;


    private Color32 ActiveMenuColor = new Color32(180, 0, 0,255);
    private Color32 InactiveMenuColor = new Color32(255, 100, 100,100);

    void Start(){
        ExitMenu.interactable = false;
        MenuAudio.PlayCityAudio();
        //for (int i = 0; i < 3; i++) UIButtons[i].color = InactiveMenuColor;
        
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

        }
        ExitMenu.interactable = true;

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

        ExitMenu.interactable = false;
        MenuOpened = 0;

    }

}

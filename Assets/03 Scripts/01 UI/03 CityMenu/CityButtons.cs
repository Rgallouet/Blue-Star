using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityButtons : MonoBehaviour {

    public Image[] UIButtons = new Image[3];

    public MenuAudio MenuAudio;

	private bool[] MenuOpenedOrNot = { false,false,false};


    private Color32 ActiveMenuColor = new Color32(180, 0, 0,255);
    private Color32 InactiveMenuColor = new Color32(255, 100, 100,100);

    void Start(){

        MenuAudio.PlayCityAudio();
        //for (int i = 0; i < 3; i++) UIButtons[i].color = InactiveMenuColor;
    }


    public void ClickMenu(int choice) {

        for (int i = 0; i < 3; i++) {
            if (!(i == choice) && (MenuOpenedOrNot[i] == true)) CloseMenu(i);
        }

        if (MenuOpenedOrNot[choice] == true) CloseMenu(choice);
        else if (MenuOpenedOrNot[choice] == false) OpenMenu(choice);

    }

	private void OpenMenu(int choice) {
        MenuOpenedOrNot[choice] = true;
        MenuAudio.PlayMenuInGameAudio();
        //UIButtons[choice].color = ActiveMenuColor;

    }

    private void CloseMenu(int choice)
    {
        MenuOpenedOrNot[choice] = false;
        MenuAudio.PlayCityAudio();
        //UIButtons[choice].color = InactiveMenuColor;
        UIButtons[choice].GetComponent<Button>().interactable = false;
        UIButtons[choice].GetComponent<Button>().interactable = true;

    }

}

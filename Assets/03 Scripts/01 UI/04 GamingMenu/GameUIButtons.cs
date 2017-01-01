using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIButtons : MonoBehaviour {

    public Image Char_button;
    public Image Dungeon_button;
    public Image Settings_button;

    public GameAudio gameAudio;

	private bool CharMenuOpenedOrNot;
    private bool SettingsMenuOpenedOrNot;

    private Color ActiveMenuColor = new Color(150, 0, 0);

    void Start(){
        gameAudio.PlayGameAudio();
        CharMenuOpenedOrNot = false;
        SettingsMenuOpenedOrNot = false;
    }


    public void ClickCharGameMenu() {
        if (SettingsMenuOpenedOrNot == true) CloseSettingsGameMenu();
        if (CharMenuOpenedOrNot == false) OpenCharGameMenu();
        else if (CharMenuOpenedOrNot == true) CloseCharGameMenu();
    }

	private void OpenCharGameMenu() {
        CharMenuOpenedOrNot = true;
        gameAudio.PlayMenuInGameAudio();
        Char_button.color = ActiveMenuColor;
    }
    private void CloseCharGameMenu()
    {
        CharMenuOpenedOrNot = false;
        gameAudio.PlayGameAudio();
        Char_button.color = Color.white;
    }

    public void ClickSettingsGameMenu()
    {
        if (CharMenuOpenedOrNot == true) CloseCharGameMenu();
        if (SettingsMenuOpenedOrNot == false) OpenSettingsGameMenu();
        else if (SettingsMenuOpenedOrNot == true) CloseSettingsGameMenu();

    }
    private void OpenSettingsGameMenu()
    {
            SettingsMenuOpenedOrNot = true;
            gameAudio.PlayMenuInGameAudio();
            Settings_button.color = ActiveMenuColor;
    }
    private void CloseSettingsGameMenu()
    {
            SettingsMenuOpenedOrNot = false;
            gameAudio.PlayGameAudio();
            Settings_button.color = Color.white;
    }
}

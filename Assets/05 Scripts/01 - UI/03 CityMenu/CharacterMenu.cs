using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterMenu : MonoBehaviour {

    public CityGUI cityGUI;
    public CharacterDisplay characterDisplay;

    private Canvas CharacterMenuCanvas;
    private Text CharacterName;

    // Use this for initialization
    void Start () {
        CharacterMenuCanvas = GetComponent<Canvas>();
        CharacterName = CharacterMenuCanvas.GetComponentInChildren<Text>();
        CharacterMenuCanvas.enabled = false;
    }

    public void ActivateMenu(BaseCharacter baseCharacter)
    {
        CharacterMenuCanvas.enabled = true;
        characterDisplay.UpdateCharacterDisplay(baseCharacter.HistoryChoices.GetIntListFromStoredChoices(), false);
        CharacterName.text = baseCharacter.characterName;
    }

    public void DesactivateMenu()
    {
        CharacterMenuCanvas.enabled = false;
    }




}

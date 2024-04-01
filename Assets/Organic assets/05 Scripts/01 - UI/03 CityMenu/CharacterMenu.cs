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
        DesactivateMenu();
    }

    public void ActivateMenu(BaseCharacter baseCharacter)
    {
        CharacterMenuCanvas.enabled = true;

        if (baseCharacter == null)
        {
            CharacterName.text = "No character selected";
        }
        else 
        {
            CharacterName.text = baseCharacter.characterName;
            characterDisplay.UpdateCharacterDisplay(baseCharacter.DemonPartChoices);
            
        }

    }

    public void DesactivateMenu()
    {
        CharacterMenuCanvas.enabled = false;
    }




}

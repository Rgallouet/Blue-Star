using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterDisplay : MonoBehaviour {

    public DataBaseManager dataBaseManager;


    private Image[] HistoryChoiceImage = new Image[9];

    // Sprites for displaying choices
    public Sprite[] RightArmSprites = new Sprite[10];
    public Sprite[] LeftImpSprites = new Sprite[10];
    public Sprite[] HeadSprites = new Sprite[19];
    public Sprite[] LeftArmSprites = new Sprite[10];
    public Sprite[] RightImpSprites = new Sprite[10];
    public Sprite[] TorsoSprites = new Sprite[10];
    public Sprite[] LegsSprites = new Sprite[10];
    public Sprite[] RightFootSprites = new Sprite[10];
    public Sprite[] LeftFootSprites = new Sprite[10];



    // Use this for initialization
    void Start () {

        for (int i = 0; i < 9; i++)  { HistoryChoiceImage[i] = GetComponentsInChildren<Image>()[i + 1]; }
        
    }


    public void UpdateCharacterDisplay(DemonPartChoices demonPartChoices) {



        HistoryChoiceImage[0].sprite = RightArmSprites[demonPartChoices.RightUpperArmChoiceID];
        HistoryChoiceImage[1].sprite = LeftImpSprites[0];
        HistoryChoiceImage[2].sprite = HeadSprites[demonPartChoices.HeadChoiceID];
        HistoryChoiceImage[3].sprite = LeftArmSprites[demonPartChoices.LeftUpperArmChoiceID];
        HistoryChoiceImage[4].sprite = RightImpSprites[0];
        HistoryChoiceImage[5].sprite = TorsoSprites[demonPartChoices.BodyChoiceID];
        HistoryChoiceImage[6].sprite = LegsSprites[demonPartChoices.RightLegChoiceID];
        HistoryChoiceImage[7].sprite = RightFootSprites[demonPartChoices.RightFootChoiceID];
        HistoryChoiceImage[8].sprite = LeftFootSprites[demonPartChoices.LeftFootChoiceID];


    }


}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;
using System.Collections;


public class CharacterDisplay : MonoBehaviour {


    private Image[] images;

    public SpriteLibraryAsset characterInMenuSprites;


    // Use this for initialization
    void Start () {

        images = GetComponentsInChildren<Image>();

    }


    public void UpdateCharacterDisplay(DemonPartChoices demonPartChoices) {



        // Ranks
        images[1].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_"+            demonPartChoices.HeadQuality);
        images[2].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +           demonPartChoices.BodyQuality);
        images[3].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +  demonPartChoices.RightUpperArmQuality);
        images[4].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +  demonPartChoices.RightLowerArmQuality);
        images[5].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +      demonPartChoices.RightFistQuality);
        images[6].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +       demonPartChoices.RightLegQuality);
        images[7].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +      demonPartChoices.RightFootQuality);
        images[8].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +   demonPartChoices.LeftUpperArmQuality);
        images[9].sprite = characterInMenuSprites.GetSprite("Rank", "Rank_" +   demonPartChoices.LeftLowerArmQuality);
        images[10].sprite = characterInMenuSprites.GetSprite("Rank","Rank_" +      demonPartChoices.LeftFistQuality);
        images[11].sprite = characterInMenuSprites.GetSprite("Rank","Rank_" +        demonPartChoices.LeftLegQuality);
        images[12].sprite = characterInMenuSprites.GetSprite("Rank","Rank_" +       demonPartChoices.LeftFootQuality);

        //Characters
        images[13].sprite = characterInMenuSprites.GetSprite("MenuHead",             "MenuHead_" +               demonPartChoices.HeadChoiceID);
        images[14].sprite = characterInMenuSprites.GetSprite("MenuBody",             "MenuBody_" +               demonPartChoices.BodyChoiceID);
        images[15].sprite = characterInMenuSprites.GetSprite("MenuRightUpperArm",    "MenuRightUpperArm_" +      demonPartChoices.RightUpperArmChoiceID);
        images[16].sprite = characterInMenuSprites.GetSprite("MenuRightLowerArm",    "MenuRightLowerArm_" +      demonPartChoices.RightLowerArmChoiceID);
        images[17].sprite = characterInMenuSprites.GetSprite("MenuRightFist",        "MenuRightFist_" +          demonPartChoices.RightFistChoiceID);
        images[18].sprite = characterInMenuSprites.GetSprite("MenuRightLeg",         "MenuRightLeg_" +           demonPartChoices.RightLegChoiceID);
        images[19].sprite = characterInMenuSprites.GetSprite("MenuRightFoot",        "MenuRightFoot_" +          demonPartChoices.RightFootChoiceID);
        images[20].sprite = characterInMenuSprites.GetSprite("MenuLeftUpperArm",     "MenuLeftUpperArm_" +       demonPartChoices.LeftUpperArmChoiceID);
        images[21].sprite = characterInMenuSprites.GetSprite("MenuLeftLowerArm",     "MenuLeftLowerArm_" +       demonPartChoices.LeftLowerArmChoiceID);
        images[22].sprite = characterInMenuSprites.GetSprite("MenuLeftFist",         "MenuLeftFist_" +           demonPartChoices.LeftFistChoiceID);
        images[23].sprite = characterInMenuSprites.GetSprite("MenuLeftLeg",          "MenuLeftLeg_" +            demonPartChoices.LeftLegChoiceID);
        images[24].sprite = characterInMenuSprites.GetSprite("MenuLeftFoot",         "MenuLeftFoot_" +           demonPartChoices.LeftFootChoiceID);


    }


}

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
        images[13].sprite = characterInMenuSprites.GetSprite("Head",             "Head_" +               demonPartChoices.HeadChoiceID);
        images[14].sprite = characterInMenuSprites.GetSprite("Body",             "Body_" +               demonPartChoices.BodyChoiceID);
        images[15].sprite = characterInMenuSprites.GetSprite("RightUpperArm",    "RightUpperArm_" +      demonPartChoices.RightUpperArmChoiceID);
        images[16].sprite = characterInMenuSprites.GetSprite("RightLowerArm",    "RightLowerArm_" +      demonPartChoices.RightLowerArmChoiceID);
        images[17].sprite = characterInMenuSprites.GetSprite("RightFist",        "RightFist_" +          demonPartChoices.RightFistChoiceID);
        images[18].sprite = characterInMenuSprites.GetSprite("RightLeg",         "RightLeg_" +           demonPartChoices.RightLegChoiceID);
        images[19].sprite = characterInMenuSprites.GetSprite("RightFoot",        "RightFoot_" +          demonPartChoices.RightFootChoiceID);
        images[20].sprite = characterInMenuSprites.GetSprite("LeftUpperArm",     "LeftUpperArm_" +       demonPartChoices.LeftUpperArmChoiceID);
        images[21].sprite = characterInMenuSprites.GetSprite("LeftLowerArm",     "LeftLowerArm_" +       demonPartChoices.LeftLowerArmChoiceID);
        images[22].sprite = characterInMenuSprites.GetSprite("LeftFist",         "LeftFist_" +           demonPartChoices.LeftFistChoiceID);
        images[23].sprite = characterInMenuSprites.GetSprite("LeftLeg",          "LeftLeg_" +            demonPartChoices.LeftLegChoiceID);
        images[24].sprite = characterInMenuSprites.GetSprite("LeftFoot",         "LeftFoot_" +           demonPartChoices.LeftFootChoiceID);


    }


}

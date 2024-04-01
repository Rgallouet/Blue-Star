using UnityEngine;
using System.Collections;


public class BodyAppearanceSwapper : MonoBehaviour
{


    public GameObjectInformation gameObjectInformation;

    public void InitialiseSkin()
    {
        RefreshBodySkin(gameObjectInformation.baseCharacter.DemonPartChoices);
        RefreshEquipmentSkin();

    }


    public int CheckAppearrance(string bodyPart)
    {
        // Search for the sprite
        Transform bodySprite = transform.Find(bodyPart).GetChild(0);

        // Update the sprite
        if (bodySprite != null)
        {
            //Debug.Log("Found a body part to swap skin for which currently has "+ bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel());
            //Debug.Log("What I will try to parse is " + bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel().Substring(bodyPart.Length +1, 3));
            return int.Parse(bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel().Substring(bodyPart.Length +1, 3));
        }

        return 0;
    }

    public void UpdateAppearrance(string bodyPart, int skinId)
    {

        // Search for the sprite
        Transform bodySprite = transform.Find(bodyPart).GetChild(0);

        // Update the sprite
        if (bodySprite != null)
        {
            
            // declare a string for checking the label
            string skinLabel = "";

            // checking color of the sprite
            Color color = bodySprite.GetComponent<SpriteRenderer>().color;

            // Creating the skin Id and checking if we need to turn invisible the sprite
            if (skinId > 99) skinLabel = bodyPart + "_" + skinId;
            else if (skinId > 9) skinLabel = bodyPart + "_" + +skinId;
            else skinLabel = bodyPart + "_00" + skinId;

            //Debug.Log("Found a body part to swap skin for which currently has "+ bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel());
            bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().SetCategoryAndLabel(bodyPart, skinLabel);

            // turning the current equipement transparent if skin ID is 0
            if (skinId==0) bodySprite.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
            // if not; and a part was invisible e.G. ID=0, then making it visible again
            else if (color.a == 0) bodySprite.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);
            
        }

    }

    public void RefreshBodySkin(DemonPartChoices demonPartChoices)
    {
        UpdateAppearrance("Head", demonPartChoices.HeadChoiceID);
        UpdateAppearrance("Body", demonPartChoices.BodyChoiceID);
        UpdateAppearrance("RightUpperArm", demonPartChoices.RightUpperArmChoiceID);
        UpdateAppearrance("RightLowerArm", demonPartChoices.RightLowerArmChoiceID);
        UpdateAppearrance("RightFist", demonPartChoices.RightFistChoiceID);
        UpdateAppearrance("RightLeg", demonPartChoices.RightLegChoiceID);
        UpdateAppearrance("RightFoot", demonPartChoices.RightFootChoiceID);
        UpdateAppearrance("LeftUpperArm", demonPartChoices.LeftUpperArmChoiceID);
        UpdateAppearrance("LeftLowerArm", demonPartChoices.LeftLowerArmChoiceID);
        UpdateAppearrance("LeftFist", demonPartChoices.LeftFistChoiceID);
        UpdateAppearrance("LeftLeg", demonPartChoices.LeftLegChoiceID);
        UpdateAppearrance("LeftFoot", demonPartChoices.LeftFootChoiceID);

}

    public void RefreshEquipmentSkin()
    {
        UpdateAppearrance("Helmet", 0);
        UpdateAppearrance("Chest", 1);
        UpdateAppearrance("Weapon", 1);
        UpdateAppearrance("RightWeapon", 2);
        UpdateAppearrance("LeftWeapon", 0);
        UpdateAppearrance("RightShoulderPad", 1);
        UpdateAppearrance("RightWristBand", 0);
        UpdateAppearrance("RightGlove", 0);
        UpdateAppearrance("RightLegging", 1);
        UpdateAppearrance("RightBoot", 0);
        UpdateAppearrance("LeftShoulderPad", 0);
        UpdateAppearrance("LeftWristBand", 1);
        UpdateAppearrance("LeftGlove", 1);
        UpdateAppearrance("LeftLegging", 1);
        UpdateAppearrance("LeftBoot", 1);

    }

    public void SwitchLeftToRight(string bodyPart)
    {
        // Checking the skin Id used on the right and left body parts
        int right = CheckAppearrance("Right"+ bodyPart);
        int left = CheckAppearrance("Left"+ bodyPart);

        // Switching the skin IDs
        UpdateAppearrance("Right" + bodyPart, left);
        UpdateAppearrance("Left" + bodyPart, right);

    }

    public void MirrorSpriteAppearrance()
    {
        SwitchLeftToRight("UpperArm");
        SwitchLeftToRight("LowerArm");
        SwitchLeftToRight("Fist");
        SwitchLeftToRight("Leg");
        SwitchLeftToRight("Foot");
        SwitchLeftToRight("ShoulderPad");
        SwitchLeftToRight("WristBand");
        SwitchLeftToRight("Glove");
        SwitchLeftToRight("Legging");
        SwitchLeftToRight("Boot");
        SwitchLeftToRight("Weapon");

    }






}

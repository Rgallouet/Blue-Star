using UnityEngine;
using System.Collections;


public class BodyAppearanceSwapper : MonoBehaviour
{

    public GameObject bodySprite = default;

    public void UpdateBodyPartAppearrance(string bodyPart, string genderChar, int skinId)
    {
        string skinLabel = "";
        if (skinId > 99) skinLabel = bodyPart + "_" + genderChar + "_" + skinId;
        else if (skinId > 9) skinLabel = bodyPart + "_" + genderChar + "_0" + skinId;
        else skinLabel = bodyPart + "_" + genderChar + "_00" + skinId;
        //Debug.Log("If I find the sprite, will change the skin for "+ skinLabel);


        // Search for the sprite
        bodySprite = transform.Find(bodyPart).GetChild(0).gameObject;

        // Update the sprite
        if (bodySprite != null)
        {
            //Debug.Log("Found a body part to swap skin for which currently has "+ bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel());
            bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().SetCategoryAndLabel(bodyPart, skinLabel);
        }
        
    }

    public string CheckAppearrance(string bodyPart)
    {
        // Search for the sprite
        bodySprite = transform.Find(bodyPart).GetChild(0).gameObject;

        // Update the sprite
        if (bodySprite != null)
        {
            //Debug.Log("Found a body part to swap skin for which currently has "+ bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel());
            return bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel();
        }

        return null;
    }



    public void UpdateEquipmentAppearrance(string bodyPart, int skinId)
    {
        string skinLabel = "";
        if (skinId > 99) skinLabel = bodyPart + "_" + skinId;
        else if (skinId > 9) skinLabel = bodyPart + "_" + +skinId;
        else if (skinId > 0) skinLabel = bodyPart + "_00" + skinId;
        else
        {
            // turning the current equipement transparent
            transform.Find(bodyPart).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            return;
        }
        //Debug.Log("If I find the sprite, will change the skin for "+ skinLabel);


        // Search for the sprite
        bodySprite = transform.Find(bodyPart).GetChild(0).gameObject;

        // Update the sprite
        if (bodySprite != null)
        {
            //Debug.Log("Found a body part to swap skin for which currently has "+ bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().GetLabel());
            bodySprite.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().SetCategoryAndLabel(bodyPart, skinLabel);
        }

    }

    public void RefreshBodySkin(DemonPartChoices demonPartChoices, string genderChar)
    {
        UpdateBodyPartAppearrance("Head", genderChar ,demonPartChoices.HeadChoiceID);
        UpdateBodyPartAppearrance("Body", genderChar, demonPartChoices.BodyChoiceID);
        UpdateBodyPartAppearrance("RightUpperArm", genderChar, demonPartChoices.RightUpperArmChoiceID);
        UpdateBodyPartAppearrance("RightLowerArm", genderChar, demonPartChoices.RightLowerArmChoiceID);
        UpdateBodyPartAppearrance("RightFist", genderChar, demonPartChoices.RightFistChoiceID);
        UpdateBodyPartAppearrance("RightLeg", genderChar, demonPartChoices.RightLegChoiceID);
        UpdateBodyPartAppearrance("RightFoot", genderChar, demonPartChoices.RightFootChoiceID);
        UpdateBodyPartAppearrance("LeftUpperArm", genderChar, demonPartChoices.LeftUpperArmChoiceID);
        UpdateBodyPartAppearrance("LeftLowerArm", genderChar, demonPartChoices.LeftLowerArmChoiceID);
        UpdateBodyPartAppearrance("LeftFist", genderChar, demonPartChoices.LeftFistChoiceID);
        UpdateBodyPartAppearrance("LeftLeg", genderChar, demonPartChoices.LeftLegChoiceID);
        UpdateBodyPartAppearrance("LeftFoot", genderChar, demonPartChoices.LeftFootChoiceID);

}

    public void RefreshEquipmentSkin()
    {
        UpdateEquipmentAppearrance("Helmet", 0);
        UpdateEquipmentAppearrance("Chest", 1);
        UpdateEquipmentAppearrance("Weapon", 1);
        UpdateEquipmentAppearrance("RightShoulderPad", 1);
        UpdateEquipmentAppearrance("RightWristBand", 0);
        UpdateEquipmentAppearrance("RightGlove", 0);
        UpdateEquipmentAppearrance("RightLegging", 1);
        UpdateEquipmentAppearrance("RightBoot", 1);
        UpdateEquipmentAppearrance("LeftShoulderPad", 0);
        UpdateEquipmentAppearrance("LeftWristBand", 1);
        UpdateEquipmentAppearrance("LeftGlove", 1);
        UpdateEquipmentAppearrance("LeftLegging", 1);
        UpdateEquipmentAppearrance("LeftBoot", 1);

    }

    public void SwitchLeftToRight()
    {
        // Shoulders
        string RightShoulder = CheckAppearrance("RightShoulderPad");
        string LeftShoulder = CheckAppearrance("LeftShoulderPad");

        UpdateEquipmentAppearrance("Helmet", 0);


    }




}

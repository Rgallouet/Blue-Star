using UnityEngine;
using System.Collections;


public class BodyAppearanceSwapper : MonoBehaviour
{

    public GameObject bodySprite = default;

    public void UpdateAppearanceSwapper(string bodyPart, string bodyLabel)
    {
        bodySprite.transform.Find(bodyPart).gameObject.GetComponent<UnityEngine.U2D.Animation.SpriteResolver>().SetCategoryAndLabel(bodyPart, bodyLabel);
    }


}

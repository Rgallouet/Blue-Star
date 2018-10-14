using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour {


    public int Sprite;
    public Sprite[] SpritesList;
    private SpriteRenderer image; 

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    public void UpdateSprite(int SpriteReceived) {

        image = transform.GetComponentInChildren<SpriteRenderer>();
        image.color = new Color(100, 100, 100);
        Debug.Log("I changed color ");
        Sprite = SpriteReceived;
        Debug.Log("I choose sprite number " + Sprite);
        image.sprite = SpritesList[Sprite];
        Debug.Log("I've changed the sprite");

    }
}

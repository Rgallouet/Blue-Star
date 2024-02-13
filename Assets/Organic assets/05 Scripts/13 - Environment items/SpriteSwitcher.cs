using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour {


    public int Sprite;
    public int SpriteMirror;

    public Sprite[] SpritesList;
    private SpriteRenderer image; 

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    public void UpdateSprite(int SpriteReceived) {

        image = transform.GetComponentInChildren<SpriteRenderer>();

        image.color = new Color(100, 100, 100);

        Sprite = SpriteReceived/2;
        //Taking the floor of sprite divided by 2

        SpriteMirror = ((SpriteReceived + 1) / 2) - Sprite;
        // if the sprite is not a module of 2, then taking the symetrical sprite

        if (SpriteMirror == 1) { transform.Rotate(0, 180,0 ); }
        image.sprite = SpritesList[Sprite];

    }
}

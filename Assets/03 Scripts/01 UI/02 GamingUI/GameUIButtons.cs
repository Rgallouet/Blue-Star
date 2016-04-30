using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIButtons : MonoBehaviour {


	public static Canvas GameUI;

    public GameAudio gameAudio;

    public Sprite[] HeadSprites = new Sprite[18];
	public Sprite[] GameMenuButtonSprite = new Sprite[2];

	private bool MenuOpenedOrNot;

	
	void Awake(){
        gameAudio.PlayGameAudio();

        Debug.Log ("Specie :" + GameInformation.BasePlayer.PlayerSpecies.Choice);
		Debug.Log ("Genus :" + GameInformation.BasePlayer.PlayerGenus.Choice);
		Debug.Log ("Balance :" + GameInformation.BasePlayer.Balance);
		GameUI = GetComponent<Canvas>();
		GameUI.GetComponentsInChildren<Image> () [0].sprite=HeadSprites [GameInformation.BasePlayer.PlayerSpecies.Choice - 1];
		MenuOpenedOrNot = false;
	}

	public void OpenGameMenu() {


        if (MenuOpenedOrNot == false) {
			MenuOpenedOrNot = true;
            gameAudio.PlayMenuInGameAudio();
            GameUI.GetComponentsInChildren<Image> () [2].sprite = GameMenuButtonSprite [1];
		} else if (MenuOpenedOrNot == true) {
			MenuOpenedOrNot = false;
            gameAudio.PlayGameAudio();
            GameUI.GetComponentsInChildren<Image> () [2].sprite = GameMenuButtonSprite [0];

		}


	}

}

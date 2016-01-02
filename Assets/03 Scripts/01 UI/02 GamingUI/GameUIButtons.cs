using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIButtons : MonoBehaviour {


	public static Canvas GameUI;


	public Sprite[] HeadSprites = new Sprite[18];
	public Sprite[] GameMenuButtonSprite = new Sprite[2];

	private bool MenuOpenedOrNot;

	
	void Awake(){
		GameUI = GetComponent<Canvas>();
		GameUI.GetComponentsInChildren<Image> () [0].sprite=HeadSprites [GameInformation.BasePlayer.PlayerSpecies.Choice - 1 + 3 * (GameInformation.BasePlayer.PlayerGenus.Choice - 1)];
		MenuOpenedOrNot = false;
	}

	public void OpenGameMenu() {

		if (MenuOpenedOrNot == false) {
			MenuOpenedOrNot = true;
			GameUI.GetComponentsInChildren<Image> () [1].sprite = GameMenuButtonSprite [1];
		} else if (MenuOpenedOrNot == true) {
			MenuOpenedOrNot = false;
			GameUI.GetComponentsInChildren<Image> () [1].sprite = GameMenuButtonSprite [0];
		}


	}

}

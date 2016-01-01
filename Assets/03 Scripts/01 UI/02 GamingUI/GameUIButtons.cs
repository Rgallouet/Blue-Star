using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIButtons : MonoBehaviour {


	public static Canvas GameUI;


	public Sprite[] HeadSprites = new Sprite[18];

	
	void Awake(){
		GameUI = GetComponent<Canvas>();
		GameUI.GetComponentsInChildren<Image> () [0].sprite=HeadSprites [GameInformation.BasePlayer.PlayerSpecies.Choice - 1 + 3 * (GameInformation.BasePlayer.PlayerGenus.Choice - 1)];
	}

	

}

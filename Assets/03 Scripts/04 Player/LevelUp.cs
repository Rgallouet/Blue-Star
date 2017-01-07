using UnityEngine;
using System.Collections;

public class LevelUp {
	

	public void levelUpCharacter(){
		// excess of xp
		GameInformation.BasePlayer.CurrentXP -= GameInformation.BasePlayer.RequiredXP;

		//save your ass
	    GameInformation.BasePlayer.CurrentEmbodiment = GameInformation.BasePlayer.Embodiment;
		GameInformation.BasePlayer.CurrentInfluence = GameInformation.BasePlayer.Influence;

		//level up
		GameInformation.BasePlayer.PlayerLevel += 1;

		//give stat points

















		//determine the next amount of require xp
		DetermineRequiredXp ();
	}

	private void DetermineRequiredXp(){
		//GameInformation.BasePlayer.RequiredXP = (int)Mathf.Ceil(100f*Mathf.Pow(1.03f,GameInformation.BasePlayer.PlayerLevel));
	}


}

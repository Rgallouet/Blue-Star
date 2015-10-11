using UnityEngine;
using System.Collections;

public class LevelUp {
	

	public void levelUpCharacter(){
		// excess of xp
		GameInformation.basePlayer.CurrentXP -= GameInformation.basePlayer.RequiredXP;

		//save your ass
		GameInformation.basePlayer.CurrentEmbodiment = GameInformation.basePlayer.Embodiment;
		GameInformation.basePlayer.CurrentInfluence = GameInformation.basePlayer.Influence;

		//level up
		GameInformation.basePlayer.PlayerLevel += 1;

		//give stat points

















		//determine the next amount of require xp
		DetermineRequiredXp ();
	}

	private void DetermineRequiredXp(){
		GameInformation.basePlayer.RequiredXP = (int)Mathf.Ceil(100f*Mathf.Pow(1.03f,GameInformation.basePlayer.PlayerLevel));
	}


}

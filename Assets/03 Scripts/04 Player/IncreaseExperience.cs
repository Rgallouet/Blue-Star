using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

	private static int xpToGive;
	private static LevelUp levelUpScript = new LevelUp();


	public static void AddExperience () {
		xpToGive = 1;
		Debug.Log (xpToGive);
		GameInformation.BasePlayer.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();
	}

	public static void AddExperienceFromBattleLoss(){
		xpToGive = 0;
		Debug.Log (xpToGive);
		GameInformation.BasePlayer.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLeveled ();	
	}


	private static void CheckToSeeIfPlayerLeveled () {
		if (GameInformation.BasePlayer.CurrentXP >= GameInformation.BasePlayer.RequiredXP) {
			levelUpScript.levelUpCharacter();
			// Create lvl up script
		}
	}


}

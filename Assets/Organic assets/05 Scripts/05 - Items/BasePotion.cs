using UnityEngine;
using System.Collections;
[System.Serializable]

public class BasePotion : BaseStatItem {

	public enum PotionTypes {HEALTH,ACTION,EFFECT}
	
	private PotionTypes potionType;
	private int spellEffectID;
	private int potionValue;
	
	public PotionTypes PotionType 	{ get{return potionType;} 		set{potionType = value;} }
	public int 	SpellEffectID 		{ get{return spellEffectID;} 	set{spellEffectID = value;}	}
	public int 	PotionValue 		{ get{return potionValue;} 		set{potionValue = value;}	}
}

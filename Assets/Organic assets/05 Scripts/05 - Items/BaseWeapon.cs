using UnityEngine;
using System.Collections;
[System.Serializable]

public class BaseWeapon : BaseStatItem {

	public enum WeaponTypes {SWORD,AXE,SHIELD}

	private WeaponTypes weaponType;
	private int spellEffectID;
	private int dmg_min;
	private int dmg_max;
	private float frequence;

	public WeaponTypes WeaponType { get{return weaponType;} 		set{weaponType = value;} }
	public int 		Dmg_min 			{ get{return dmg_min;} 		set{dmg_min = value;}	}
	public int 		Dmg_max 			{ get{return dmg_max;} 		set{dmg_max = value;}	}
	public float 	Frequence 			{ get{return frequence;} 	set{frequence = value;}	}
	public int 		SpellEffectID 		{ get{return spellEffectID;} 		set{spellEffectID = value;}	}

}

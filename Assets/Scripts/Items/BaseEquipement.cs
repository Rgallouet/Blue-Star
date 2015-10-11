using UnityEngine;
using System.Collections;
[System.Serializable]

public class BaseEquipment : BaseStatItem {

	public enum EquipmentTypes {CHEST,ARM,LEG}
	
	private EquipmentTypes equipmentType;
	private int spellEffectID;
	private int armor;

	public EquipmentTypes EquipmentType { get{return equipmentType;} 		set{equipmentType = value;} }
	public int 	SpellEffectID 			{ get{return spellEffectID;} 		set{spellEffectID = value;}	}
	public int 	Armor 					{ get{return armor;} 				set{armor = value;}	}


}

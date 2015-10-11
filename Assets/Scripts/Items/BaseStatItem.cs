using UnityEngine;
using System.Collections;
[System.Serializable]

public class BaseStatItem : BaseItem {

	private int size;
	private int durability;
	private int itemlevel;
	private int itemlevelreq;

	public int 	Size 			{ get{return size;} 			set{size = value;}	}
	public int 	Durability 		{ get{return durability;} 		set{durability = value;}	}
	public int 	Itemlevel 		{ get{return itemlevel;} 		set{itemlevel = value;}	}
	public int 	Itemlevelreq 	{ get{return itemlevelreq;} 	set{itemlevelreq = value;}	}
	
}

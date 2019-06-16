using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePotion : BaseStatItem {

	public enum PotionTypes{
		HEALTH,
		ENERGY,
		STRENGTH,
		INTELLECT,
		VITALITY,
		ENDURANCE
	}

	private PotionTypes potionType;

	public PotionTypes PotionType{
		get{return potionType;}
		set{potionType = value;}
	}
		public int SpellEffectID { get; set; }
}

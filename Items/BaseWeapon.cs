using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseWeapon : BaseStatItem {

	// Use this for initialization
	public enum WeaponTypes{
		SWORD,
		STAFF,
		DAGGER,
		BOW,
		SHIELD,
		POLEARM
	}




	public int SpellEffectID { get; set; }

	public WeaponTypes WeaponType { get; set; }

	public int minDamage { get; set; }

	public int maxDamage { get; set; }

	public int range { get; set; }

	public float attackSpeed { get; set; }




}

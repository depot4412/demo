using UnityEngine;
using System.Collections;
using System.Text;

public class CreateNewWeapon {

	private BaseWeapon newWeapon;
	private string[] itemNames = new string[4] {" damaged", " fair", "n exceptional", " perfect"};

	public BaseWeapon CreateWeapon(){

	

		newWeapon = new BaseWeapon();

		newWeapon.itemType = BaseItem.ItemTypes.WEAPON;

		StringBuilder s = new System.Text.StringBuilder(1000);
	

		ChooseWeaponType();
		//spell effect id


		//weapon id
		newWeapon.itemID = Random.Range(1,10133);
		//stats
		newWeapon.Strength = Random.Range(0,11);
		newWeapon.Intellect = Random.Range (0,11);
		newWeapon.Endurance = Random.Range (0,11);
		//choose type
	

		//assign name
		newWeapon.itemName =  "W" + newWeapon.itemID + " the " + newWeapon.WeaponType;

		//make descript
		//newWeapon.itemDescription = "This is a" + itemNames[Random.Range(0,3)] + " weapon.";

		/*
		data = "<color=#00FF00><b>" + item.itemName + "</b></color>\n\n" + item.itemDescription;
			
		if(item.GetType() == typeof(BaseWeapon))
		{
			data += "\nStrength: " +  ((BaseWeapon)item).Strength;
			data += "\nIntellect: " +  ((BaseWeapon)item).Intellect;
		}

		*/	

		
		s.Append("<color=#00FF00><b>" + "W" + newWeapon.itemID + " the " + newWeapon.WeaponType + "</b></color>\n");

		if(newWeapon.minDamage > 0)
		{
			float dps = ((newWeapon.minDamage + newWeapon.maxDamage)/2*newWeapon.attackSpeed);
			s.Append("\nDamage: " + newWeapon.minDamage + " - " + newWeapon.maxDamage + "\nAttack Speed: " + newWeapon.attackSpeed +  "\nDPS: " + dps);

		}

		if(newWeapon.range > 0)
		{
			s.Append("\nRange: " + newWeapon.range );

		}

		if(newWeapon.Strength > 1)
		{
			s.Append("\nStrength: " + newWeapon.Strength);
		}

		if(newWeapon.Intellect > 1)
		{
			s.Append("\nIntellect: " + newWeapon.Intellect);
		}
		if(newWeapon.Endurance > 1)
		{
			s.Append("\nEndurance: " + newWeapon.Endurance);
		}

		newWeapon.SpellEffectID = Random.Range(1,101);

		newWeapon.tooltip = s.ToString();

		newWeapon.sprite = Resources.Load<Sprite>(newWeapon.spriteLocation);

		return newWeapon;


	}

	private void ChooseWeaponType(){
		int randomTemp = Random.Range(1,7);

		switch (randomTemp) {

		case 1:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
			newWeapon.spriteLocation = "Sprites/Items/sword";
			newWeapon.minDamage = 3;
			newWeapon.maxDamage = 8;
			newWeapon.attackSpeed = 2f;
				newWeapon.range = 3;
			break;
			}
		case 2:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
				newWeapon.spriteLocation = "Sprites/Items/staff";
				newWeapon.minDamage = 4;
				newWeapon.maxDamage = 12;
				newWeapon.attackSpeed = 1f;
				newWeapon.range = 4;
			break;
			}
		case 3:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
				newWeapon.spriteLocation = "Sprites/Items/dagger";
				newWeapon.minDamage = 3;
				newWeapon.maxDamage = 6;
				newWeapon.attackSpeed = 2.5f;
				newWeapon.range = 2;
			break;
			}
		case 4:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
				newWeapon.spriteLocation = "Sprites/Items/bow";
				newWeapon.minDamage = 5;
				newWeapon.maxDamage = 8;
				newWeapon.attackSpeed = 1.6f;
				newWeapon.range = 10;
			break;
			}
		case 5:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
				newWeapon.spriteLocation = "Sprites/Items/shield";
				newWeapon.minDamage = 0;
				newWeapon.maxDamage = 0;
				newWeapon.attackSpeed = 0f;
				newWeapon.range = 0;
			break;
			}
		case 6:
			{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.POLEARM;
				newWeapon.spriteLocation = "Sprites/Items/polearm";
				newWeapon.minDamage = 6;
				newWeapon.maxDamage = 14;
				newWeapon.attackSpeed = 1f;
				newWeapon.range = 4;
			break;
			}

		}﻿
	}
}
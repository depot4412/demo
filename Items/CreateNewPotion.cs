using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

	private BasePotion newPotion;
	private string[] itemNames = new string[4] {"Common", "Great", "Amazing", "Insane"};

	public void CreateWeapon(){
		newPotion = new BasePotion();

		//assign name
		newPotion.itemName = itemNames[Random.Range(0,3)] + " Item"; 
		//make descript
		//newPotion.itemDescription = "This is a new POTION.";
		//weapon id
		newPotion.itemID = Random.Range(1,101);
		//stats
		newPotion.Strength = Random.Range(1,11);
		newPotion.Intellect = Random.Range (1,11);
		//choose type
		ChoosePotionType();
		//spell effect id
		newPotion.SpellEffectID = Random.Range(1,101);
	}


	private void ChoosePotionType(){
		int randomTemp = Random.Range(1,6);

		switch (randomTemp) {

		case 1:
			newPotion.PotionType = BasePotion.PotionTypes.ENDURANCE;
			break;
		case 2:
			newPotion.PotionType = BasePotion.PotionTypes.ENERGY;
			break;
		case 3:
			newPotion.PotionType = BasePotion.PotionTypes.HEALTH;
			break;
		case 4:
			newPotion.PotionType = BasePotion.PotionTypes.INTELLECT;
			break;
		case 5:
			newPotion.PotionType = BasePotion.PotionTypes.STRENGTH;
			break;
		case 6:
			newPotion.PotionType = BasePotion.PotionTypes.VITALITY;
			break;


		}﻿
	}
}
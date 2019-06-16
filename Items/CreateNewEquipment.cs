using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;




public class CreateNewEquipment : MonoBehaviour {

	public BaseEquipment newEquipment;
	private string[] itemNames = new string[4] {"Common", "Great", "Amazing", "Insane"};
 
	public BaseEquipment CreateEquipment(){
		newEquipment = new BaseEquipment();



		StringBuilder s = new System.Text.StringBuilder(1000);

		//assign name

		newEquipment.itemName = itemNames[Random.Range(0,3)] + " Item"; 
		//make descript
		//newEquipment.itemDescription = "This is a new EQUIPMENT.";
		//weapon id
		newEquipment.itemID = Random.Range(200,11000);
		//stats
		newEquipment.Strength = Random.Range(1,11);
		newEquipment.Intellect = Random.Range (1,11);
		//choose type
		ChooseEquipmentType();
		//spell effect id
		newEquipment.SpellEffectID = Random.Range(1,101);

		s.Append("<color=#00FF00><b>" + "W" + Random.Range(1,101) + " the " + newEquipment.itemType + "</b></color>\n");



		if(newEquipment.Strength > 1)
		{
			s.Append("\nStrength: " + newEquipment.Strength);
		}

		if(newEquipment.Intellect > 1)
		{
			s.Append("\nIntellect: " + newEquipment.Intellect);
		}

			s.Append("\nTYPE: " + newEquipment.itemType);

		newEquipment.tooltip = s.ToString();


		return newEquipment;
	}


	private void ChooseEquipmentType(){
		int randomTemp = Random.Range(1,8);

		switch (randomTemp) {

		case 1:
			newEquipment.itemType = BaseEquipment.ItemTypes.HELM;
			newEquipment.spriteLocation = "Sprites/Items/hat";
			break;
		case 2:
			newEquipment.itemType = BaseEquipment.ItemTypes.PANTS;
			newEquipment.spriteLocation = "Sprites/Items/pants";
			break;
		case 3:
			newEquipment.itemType = BaseEquipment.ItemTypes.BOOTS;
			newEquipment.spriteLocation = "Sprites/Items/boots";
			break;
		case 4:
			newEquipment.itemType = BaseEquipment.ItemTypes.CHEST;
			newEquipment.spriteLocation = "Sprites/Items/armor";
			break;
		case 5:
			newEquipment.itemType = BaseEquipment.ItemTypes.NECK;
			newEquipment.spriteLocation = "Sprites/Items/amulet";
			break;
		case 6:
			newEquipment.itemType = BaseEquipment.ItemTypes.GLOVE;
			newEquipment.spriteLocation = "Sprites/Items/gloves";
			break;
		case 7:
			newEquipment.itemType = BaseEquipment.ItemTypes.RING;
			newEquipment.spriteLocation = "Sprites/Items/ring";
			break;


		}﻿
	}
}
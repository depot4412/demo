
using UnityEngine;
using System.Collections;

public class CreateNewScroll : MonoBehaviour {

	private BaseScroll newScroll;
	private string[] itemNames = new string[4] {"Common", "Great", "Amazing", "Insane"};

	public void CreateWeapon(){
		newScroll = new BaseScroll();

		//assign name
		newScroll.itemName = itemNames[Random.Range(0,3)] + " Item"; 
		//make descript
		//newScroll.itemDescription = "This is a new EQUIPMENT.";
		//weapon id
		newScroll.itemID = Random.Range(1,101);
		//stats
		newScroll.Strength = Random.Range(1,11);
		newScroll.Intellect = Random.Range (1,11);
		//choose type
		//ChooseScrollType();
		//spell effect id
		newScroll.SpellEffectID = Random.Range(1,101);
	}


	/*
	private void ChooseScrollType(){
		int randomTemp = Random.Range(1,9);

		switch (randomTemp) {

		case 1:
			newScroll.ScrollType = BaseScroll.ScrollTypes.
			break;
		case 2:
			newScroll.ScrollType = BaseScroll.ScrollTypes.SHOULDERS;
			break;
		case 3:
			newScroll.ScrollType = BaseScroll.ScrollTypes.LEGS;
			break;
		case 4:
			newScroll.ScrollType = BaseScroll.ScrollTypes.FEET;
			break;
		case 5:
			newScroll.ScrollType = BaseScroll.ScrollTypes.CHEST;
			break;
		case 6:
			newScroll.ScrollType = BaseScroll.ScrollTypes.NECK;
			break;
		case 7:
			newScroll.ScrollType = BaseScroll.ScrollTypes.EARRING;
			break;
		case 8:
			newScroll.ScrollType = BaseScroll.ScrollTypes.RING;
			break;


		}﻿
	}
	*/  // not yet my dudes
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStats : MonoBehaviour {

	// Use this for initialization

	Text text;
	BaseInventory equipment;

	int totalstr = 0;
	int totalint = 0;

	void Awake()
	{
		equipment = GameObject.Find("GUI/CharacterInventory/EquipmentPanel").GetComponent<BaseInventory>();
		text = GetComponent<Text>();
	}
	void Start () {
		



	}

	public void UpdateStats(){
		/*
		totalstr = 0;
		totalint = 0;
		int i = 0;
		//Debug.Log(equipment.slots.Count);
		while( i < equipment.items.Count )
		{
			//Debug.Log(i);
			BaseStatItem test = equipment.items[i] as BaseStatItem;
			if(test != null)
			{
				//Debug.Log(test.itemName);
				totalstr += test.Strength;
				totalint += test.Intellect;
			}

			i++;

		}

		i=0;
		text.text = "STR: " + totalstr + "\nINT: " + totalint;
		*/
	}
	// Update is called once per frame
	void Update () {

	     
	}
}

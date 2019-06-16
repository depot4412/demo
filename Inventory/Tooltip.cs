using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Tooltip : MonoBehaviour
{
	private BaseItem item;
	private string data;
	private GameObject tooltip;

	void Start()
	{
		tooltip = GameObject.Find("GUI/CharacterInventory/Tooltip2");
		tooltip.SetActive(false);
	}

	void Update()
	{
		/*
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		
			if(Screen.width > Input.mousePosition.x + 150)
			{
			tooltip.transform.position += new Vector3(100,0,0);
			}
			else
			{
				tooltip.transform.position -= new Vector3(100,0,0);
			}

		}
		*/
	}

	public void Activate(BaseItem item)
	{
		this.item = item;
		ConstructDataString();
		tooltip.SetActive(true);

		tooltip.transform.position = Input.mousePosition;

		if(Screen.width > Input.mousePosition.x + 150)
		{
			tooltip.transform.position += new Vector3(100,0,0);
		}
		else
		{
			tooltip.transform.position -= new Vector3(100,0,0);
		}
	}

	public void Deactivate()
	{
		tooltip.SetActive(false);
	}

	public void ConstructDataString()
	{

		/*
		data = "<color=#00FF00><b>" + item.itemName + "</b></color>\n\n" + item.itemDescription;
			
		if(item.GetType() == typeof(BaseWeapon))
		{
			data += "\nStrength: " +  ((BaseWeapon)item).Strength;
			data += "\nIntellect: " +  ((BaseWeapon)item).Intellect;
		}

		*/	
		

		tooltip.transform.GetChild(0).GetComponent<Text>().text = item.GetDescription(item.tooltip);
	}

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;



[System.Serializable]
public class BaseItem {

	public string itemName { get; set; }
	public string tooltip { get; set; }
	public string icon { get; set; }
	public int itemID { get; set; }
	public enum ItemTypes{
		WEAPON,
		SCROLL,
		POTION,
		CHEST,
		OFFHAND,
		HELM,
		GLOVE,
		BOOTS,
		RING,
		EARRING,
		PANTS,
		NECK,
		MATERIAL,
        DEFAULT,
        ALL


	}

	public enum Rarity{
		COMMON,
		MAGIC,
		RARE,
		UNIQUE
	}

	public ItemTypes itemType { get; set; }

	[JsonIgnore]
	public Sprite sprite { get; set; }


	public string spriteLocation { get; set; }

	protected virtual void Awake()
	{
		Debug.Log("DOING THE LOAD");
		sprite = Resources.Load<Sprite>(spriteLocation);
	}

	public BaseItem()
	{
		this.itemID = -1;
        this.itemType = ItemTypes.DEFAULT;
	}

	public virtual string GetDescription(string s)
	{
		return s.ToString();
	}
}

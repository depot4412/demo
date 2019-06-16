using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZ : MonoBehaviour, IInteractable {

	// Use this for initialization

	GameObject player;

	private IEnumerator coroutine;

	bool interacting = false;

	float distance;

	DoingSomething bar;

	void Start () {

//		bar = GameObject.Find("GUI/ProgressBar").GetComponent<DoingSomething>();
		player = GameObject.Find("PersistantData/PlayerParty/Player1");

		coroutine = Interacting(3);


	}
	
	// Update is called once per frame
	void Update () {
		if(interacting && 5 < Vector3.Distance(player.gameObject.transform.position, this.transform.position))
		{
			Debug.Log("stopping routine");
			StopCoroutine(coroutine);
			interacting = false;
		}
	}

	public void Interact()
	{
		Debug.Log("starting routine");
        player = GameObject.Find("PersistantData/PlayerParty/Player1");

        distance = Vector3.Distance(player.gameObject.transform.position, this.transform.position);
        Debug.Log("distance = " + distance);
		coroutine = Interacting(3); // some weird shit to reset coroutine
		//bar.RunProgressBar(3, "CHOPPING WOOD");
		StartCoroutine(coroutine);
		interacting = true;

	}
	public IEnumerator Interacting(int time)
	{

		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
		interacting = false;
		BaseItem loot = new BaseItem();
		loot.itemName = "WOOD";
		loot.itemID	= 69;
		loot.itemType = BaseItem.ItemTypes.DEFAULT;
		//loot.s = new System.Text.StringBuilder(200);
		//loot.s.Append("BIG OLE HUNK OF WOOD");
		loot.tooltip = "Big ole hunk of wood";
		loot.spriteLocation = "Sprites/Items/Log";
   
		player.GetComponentInChildren<CharacterInventory>().AddItemToEmptySlot(loot);

	}
}

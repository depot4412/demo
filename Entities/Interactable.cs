using System;
using UnityEngine;


public class Interactable : MonoBehaviour
	{
	
	public GameObject gameObject;

	public GameObject player;

	public bool interacting { get; set; }

		public Interactable ()
		{
		interacting = false;
	

		//player = GameObject.Find("Capsule").GetComponent<GameObject>();

		//gameObject = this.GetComponentInParent<GameObject>();
		
		}

		public virtual void Interact()
		{
		Debug.Log("Interacting");
		}
	public void activate ()

	{
		Debug.Log("we interactin now");
		interacting = true;
	}
	void Update()
	{
		if(interacting)
		{
			Debug.Log("distance: " + Vector3.Distance(gameObject.transform.position, player.transform.position));
		if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 4f)
			{
			Interact();
			interacting = false;
			}
		}

	}
	}



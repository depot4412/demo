using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


	public class DoorManager : MonoBehaviour
	{
	
	public GameObject oldroom;
	public GameObject destinationRoom;
	DragMouseOrbit camera;
	public PlayerEntity player;

	public Dungeon dungeon;

	Boolean inoldroom = true;

	Interactable selectedTarget;


		public DoorManager ()
		{



		}

	void Start()

	{
		dungeon = GameObject.Find("DungeonStatus").GetComponent<Dungeon>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DragMouseOrbit>();
		player = FindObjectOfType<PlayerEntity>();
	}

	void Update()
	{

		if (Input.GetMouseButtonDown (0)) {
			//Shoot ray from mouse position
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit[] hits = Physics.RaycastAll (ray);
				foreach (RaycastHit hit in hits) { //Loop through all the hits
					if (hit.transform.gameObject.layer == 8) { //Make a new layer for targets}
			
							destinationRoom.SetActive(true);
							camera.target = destinationRoom.transform;
							player.transform.position = destinationRoom.transform.position;
							oldroom.SetActive(false);
							inoldroom = false;
						    dungeon.currentRoom = destinationRoom.GetComponent<Room>();
						    player.active = false;
						    player.nav.ResetPath();

			


	}
	}
			}
		}
	}
}



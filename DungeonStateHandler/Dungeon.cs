using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

	public class Dungeon : MonoBehaviour
	{
	DungeonStateHandler dungeonStateHandler;
	public Room currentRoom;
	public PlayerEntity player;

	public Component[] enemies;

		public Dungeon ()
		{
		

		}

	void Start()
	{
		dungeonStateHandler =  new DungeonStateHandler();
		currentRoom = GameObject.Find("DungeonRoom").GetComponent<Room>();
		player = FindObjectOfType<PlayerEntity>();
		player.InitializeNavMeshAgent();
		player.nav.speed = 5;
		player.GetComponent<CharacterMover2>().enabled = false;
		player.GetComponent<Draggable>().enabled = true;



	}

	void Update()

	{
		enemies = currentRoom.GetComponentsInChildren(typeof(BaseEntity));
		//dungeonStateHandler.Update();
	}

	public void ActivateRoom()
	{
		enemies = currentRoom.GetComponentsInChildren(typeof(BaseEntity));
		foreach (BaseEntity a in enemies)
		{
			a.Activate();
		}

		player.Activate();
	}
	}



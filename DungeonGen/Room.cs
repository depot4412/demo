using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class Room : MonoBehaviour
	{

	public List<Vector3> OpenDoorPositions { get; set; }

	public enum RoomStates {
		Empty,
		Active
	}

	public Component[] enemies;
	public GameObject doors;

	public PlayerEntity player;


		public Room ()
		{
		}

	void Start()
	{
		doors = this.transform.Find("Door").gameObject;
		enemies = GetComponentsInChildren(typeof(BaseEntity));

		player = FindObjectOfType<PlayerEntity>();


		OpenDoorPositions = new List<Vector3>();

		OpenDoorPositions.Add(new Vector3(0,0,15));
		OpenDoorPositions.Add(new Vector3(0,15,0));
		OpenDoorPositions.Add(new Vector3(0,-15,0));
	}


	void Update()
	{
		enemies = GetComponentsInChildren(typeof(BaseEntity));
		if(enemies.Length == 0)
		{
			
			player.active = false;
			player.nav.ResetPath();
			doors.SetActive(true);


		}

	}
	public void CreateAdjacentRoom()
	{

	}
		
	}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Initialize : MonoBehaviour {


	PlayerEntity player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
		player.InitializeNavMeshAgent();
		player.GetComponent<Draggable>().enabled = false;
		player.GetComponent<CharacterMover2>().enabled = true;
		player.nav.speed = 10;
		player.nav.acceleration = 50;

		//player.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void EnterDungeon()

	{
		SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
		player.transform.position = new Vector3(0,0,0);
		player.nav.ResetPath();
		player.ClearTarget();
	}
}

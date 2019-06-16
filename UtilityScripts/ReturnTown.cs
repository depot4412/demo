using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ReturnTown : MonoBehaviour {
	private PlayerEntity player;


	void Awake ()
	{
		player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
	}
	void Start () {
		
	}
	

	void Update () {
		
	}

	public void LeaveDungeon()

	{
		SceneManager.LoadScene("Town", LoadSceneMode.Single);
		player.nav.ResetPath();
		player.active = false;
		player.transform.position = new Vector3(0,0,0);
		player.ClearTarget();
	
	}
}

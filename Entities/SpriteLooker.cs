using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooker : MonoBehaviour {

	private Sprite[] sprites;
	// Use this for initialization
	void Start () {
		var thing = this.gameObject.GetComponent<SpriteRenderer>();
		//thing.sprite = Resources.Load<Sprite>(Game.current.player.Sprite);
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.position = GameObject.Find("Capsule").transform.position;

		var thing = GameObject.Find("Hitbox").transform.position;
		thing.y = thing.y -0.6466f;

		transform.position = thing;

		transform.rotation = Quaternion.LookRotation(Camera.main.transform.position);

		transform.LookAt(Camera.main.transform.position, Vector3.up);

	}
}

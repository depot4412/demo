using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.collider);
		Debug.Log(collision.gameObject);

		if(collision.gameObject.tag == "Enemy")
		{
		collision.gameObject.GetComponent<CharacterEntity>().TakeDamage(15);
			Debug.Log("ATTACKED");
		}


	}
	}

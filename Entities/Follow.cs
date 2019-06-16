using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public RectTransform thing;

	// Use this for initialization
	void Start () {
		thing = GameObject.Find("PlayerParty/Player1").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = thing.transform.position;
	}
}

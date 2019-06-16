using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	private string named { get; set; }
	private string description { get; set; }
	private int level { get; set; }
	private int currentxp { get; set; }
	private int maxxp { get; set; }
	// Use this for initialization
	void Start () {
		name = "Uninitialized";
		description = "Something went wrong";
		level = 1;
		currentxp = 0;
		maxxp = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddXP(int value)
	{

		currentxp += value;

		if(currentxp >= maxxp)
		{
			level++;
			currentxp -= maxxp;
			maxxp += 130*level;
		}


	}
}

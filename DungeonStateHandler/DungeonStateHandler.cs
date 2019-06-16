using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class DungeonStateHandler : DungeonStates
	{

      
		public DungeonStateHandler ()
		{

		State = States.ENTERING;

		}

	public void Update()
	{
		switch(this.State)
		{

		case States.ENTERING:
			Debug.Log(State);
			break;

		case States.PREPARE:
			Debug.Log(State);
			break;

		case States.FIGHT:
			Debug.Log(State);
			break;

		case States.EXPLORE:
			Debug.Log(State);
			break;

		case States.END:
			Debug.Log(State);
			break;
	    default:
			Debug.Log("ERROR");
			break;

		}



	}
	}


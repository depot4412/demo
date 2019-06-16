using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEntity : MonoBehaviour {

	public string Name { get; set; }
	public string Description { get; set; }



	public bool active = false;



	public NavMeshAgent nav;

	private Vector3 entityLocation;



	public enum States {
		MOVING_TO_OBJECT,
		MOVING_TO_ATTACK,
		MOVING_TO_LOCATION,
		ATTACKING,
		DEAD,
		IDLE


	}

	public ParticleSystem particleTest;

	public States CurrentState { get; set; }

	public List<BaseItem> droppableLoot { get; set; }

	// Use this for initialization
	public virtual void Start () {
		this.Name = "Generic Entity";
		this.Description = "Your entity probably didn't work.";




		CurrentState = States.IDLE;

		droppableLoot = new List<BaseItem>();




		particleTest = gameObject.GetComponent<ParticleSystem>();


	}

	// Update is called once per frame
	public virtual void Update () {



	}

	public void Activate ()
	{
        nav = GetComponent<NavMeshAgent>();
        nav.ResetPath();
		active = true;
	}


}




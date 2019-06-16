using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour {

	public string Name { get; set; }
	public string Description { get; set; }
	public int MaxLife { get; set; }
	public int CurrentLife { get; set; }
	public int MaxMana{ get; set; }
	public int CurrentMana{ get; set; }
	public int ExperienceGiven { get; set; }
	public int Level { get; set; }
	public int Endurance { get; set; }
	public int Strength { get; set; }
	public int Intellect { get; set; }
	public int MoveSpeed { get; set; }
	public int Gold { get; set; }
	public int Damage { get; set; }
	public int OptimalRange { get; set; }
	public int MaxRange { get; set; }
	public float AttackSpeed { get; set; }
	public GameObject Target { get; set; }

	private bool attackOnCooldown = false;

	private NavMeshHit there;

	private NavMeshAgent nav;

	private Vector3 playerLocation;
	private GameObject playerObject;

	private float nextActionTime = 0.0f;
	public float period = 0.25f;

	public enum States {
		MOVING_TO_OBJECT,
		MOVING_TO_ATTACK,
		MOVING_TO_LOCATION,
		ATTACKING,
		DEAD,
		IDLE


	}

	private ParticleSystem particleTest;

	public States CurrentState { get; set; }

	public List<BaseItem> Loot { get; set; }

	// Use this for initialization
	void Start () {
		this.Name = "Generic Enemy";
		this.Description = "Just a normal monster";
		this.MaxLife = 30;
		this.CurrentLife = 30;
		this.MaxMana = 30;
		this.CurrentMana = 30;
		this.ExperienceGiven = 100;
		this.Level = 1;
		this.Endurance = 10;
		this.Strength = 10;
		this.Intellect = 10;
		this.MoveSpeed = 10;
		this.Gold = 20;
		this.Damage = 3;
		this.OptimalRange = 1;
		this.MaxRange = 4;
		this.AttackSpeed = 1.5f;



		CurrentState = States.IDLE;
		Loot = new List<BaseItem>();

		CreateNewWeapon thing = new CreateNewWeapon();
		Loot.Add(thing.CreateWeapon());

		nav = GetComponent<NavMeshAgent>();

		playerObject = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CapsuleCollider>().gameObject;

		particleTest = gameObject.GetComponent<ParticleSystem>();


	}
	
	// Update is called once per frame
	public virtual void Update () {

		//playerLocation = playerObject.transform.position;

		//todo limit rate of move

		if (Time.time > nextActionTime ) 
		{ 
		nextActionTime = Time.time + period; 
		MoveToTargetAtOptimalRange(playerObject);
		AttackIfOffCooldown(playerObject);
		}

		if (CurrentLife <= 0)
		{
			DestroyObject(this.gameObject);
		}


		/*
		if(Vector3.Distance(playerLocation, this.gameObject.transform.position) > 2f)
		{

		nav.destination = playerLocation;

		}

		if(Vector3.Distance(playerLocation, this.gameObject.transform.position) < 2f)
		{
			//playerObject.GetComponent<Player>().TakeDamage(this.Damage);
			Game.current.player.TakeDamage(this.Damage);
		}
        */

	}

	public virtual void MoveToLocation(Vector3 v) {
		nav.destination = v;
	}

	public virtual void MoveToTarget(GameObject g) {
		nav.destination = g.transform.position;
	}

	public virtual void MoveToTargetAtOptimalRange(GameObject g) {
		

		NavMesh.SamplePosition(g.transform.position, out there, 15, NavMesh.AllAreas);

		Vector3 boxpos = g.transform.position;
		Vector3 characterpos = nav.transform.position;

		Vector3 spot = boxpos + (characterpos - boxpos) * ((float)(this.OptimalRange*10)) / (characterpos - boxpos).sqrMagnitude;

		NavMesh.SamplePosition(spot, out there, 5, NavMesh.AllAreas);

		nav.destination = there.position;

	}

	public virtual void AttackTarget(CharacterEntity g) {
		if(Vector3.Distance(g.transform.position, this.gameObject.transform.position) < this.MaxRange)
		{
			//playerObject.GetComponent<Player>().TakeDamage(this.Damage);
			g.TakeDamage(this.Damage);
		}
	}

	public virtual void SetTarget(GameObject g) {
		Target = g;
	}

	public virtual void ClearTarget() {
		Target = null;
	}

	public virtual void Attack(CharacterEntity g)
	{
		if(Vector3.Distance(playerObject.transform.position, this.gameObject.transform.position) < this.MaxRange)
		{
		g.TakeDamage(this.Damage);

		}
		    attackOnCooldown = false;
		particleTest.Stop();

	}
	public virtual void AttackIfOffCooldown(GameObject g)
	{
		if(attackOnCooldown == false)
		{
		if(Vector3.Distance(g.transform.position, this.gameObject.transform.position) < this.MaxRange)
		{
			//playerObject.GetComponent<Player>().TakeDamage(this.Damage);
				transform.LookAt(g.transform.position);
			attackOnCooldown = true;
				particleTest.Play();
			Invoke("Attack" , AttackSpeed);
			
			
		
		}

		}

	}

	}




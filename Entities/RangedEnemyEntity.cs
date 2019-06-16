using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyEntity : EnemyEntity
{
	PlayerEntity player;

	public ParticleSystem part;
	public List<ParticleCollisionEvent> collisionEvents;

	public RangedEnemyEntity ()
	{

	}

	public override void Start () {
		this.Name = "Generic Enemy";
		this.Description = "Just a normal monster";
		this.MaxLife = 30;
		this.CurrentLife = 30;
		this.ExperienceGiven = 100;
		this.Level = 1;
		this.MoveSpeed = 10;
		this.Damage = 1;
		this.OptimalRange = 20;
		this.MaxRange = 20;
		this.AttackSpeed = 5f;



		CurrentState = States.IDLE;
		droppableLoot = new List<BaseItem>();

		//CreateNewWeapon thing = new CreateNewWeapon();
		//Loot.Add(thing.CreateWeapon());

		nav = GetComponent<NavMeshAgent>();

		Target = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerEntity>();

		particleTest = gameObject.GetComponent<ParticleSystem>();

		player = GameObject.Find("Player1").GetComponent<PlayerEntity>();

		part = GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();


	}


	public override void Update ()
	{
		if(active)
		{

			if (Time.time > nextActionTime ) 
			{ 
				nextActionTime = Time.time + period; 
				if(Vector3.Distance(Target.transform.position, this.gameObject.transform.position) > this.MaxRange)
				{
				MoveToTargetAtOptimalRange(Target);
				}
				AttackIfOffCooldown(Target);
			}

			if (CurrentLife <= 0)
			{
				CurrentState = States.DEAD;
				this.gameObject.SetActive(false);
				DestroyObject(this.gameObject);
				player.GainExperience(this.ExperienceGiven);
			}
		}

	}


	public override void AttackIfOffCooldown(BaseEntity g)
	{
		
			if(Vector3.Distance(g.transform.position, this.gameObject.transform.position) < this.MaxRange)
			{
				//playerObject.GetComponent<Player>().TakeDamage(this.Damage);
				transform.LookAt(g.transform.position);
				//attackOnCooldown = true;
				CurrentState = States.ATTACKING;
				particleTest.Play();
				//Invoke("Attack" , AttackSpeed);



			}

		 

	}

	void OnParticleCollision(GameObject other)
	{
		int i = 0;
		int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents (particleTest, other, collisionEvents);


		while (i < numCollisionEvents) 
		{
			Debug.Log(collisionEvents[i].ToString());
			i++;
		}

       
	}
}



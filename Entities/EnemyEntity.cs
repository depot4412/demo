using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

	public class EnemyEntity : CharacterEntity
	{
	PlayerEntity player;

		public EnemyEntity ()
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
		this.Damage = 3;
		this.OptimalRange = 1;
		this.MaxRange = 4;
		this.AttackSpeed = 1.5f;



		CurrentState = States.IDLE;
		droppableLoot = new List<BaseItem>();

		//CreateNewWeapon thing = new CreateNewWeapon();
		//Loot.Add(thing.CreateWeapon());

		nav = GetComponent<NavMeshAgent>();

		Target = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerEntity>();

		particleTest = gameObject.GetComponent<ParticleSystem>();

		player = GameObject.Find("Player1").GetComponent<PlayerEntity>();


	}


	public override void Update ()
	{
		if(active)
		{

			if (Time.time > nextActionTime ) 
			{ 
				nextActionTime = Time.time + period; 
				MoveToTargetAtOptimalRange(Target);
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
	}



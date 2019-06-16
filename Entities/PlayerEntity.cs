using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


	public class PlayerEntity : CharacterEntity
	{
	
	public int Experience;		
	private Dungeon dungeonStatus;
	public GameObject basicAttack;
	private bool attacking = false;
	public CharacterEquipment equip;
	public PlayerSave.PlayerInfo current;
	public GameObject saveInfo;
	public CharacterInventory inv;


	public PlayerEntity ()
		{
		}


	public void Awake()
	{
		//obj = GameObject.Find("PlayerParty/Player1/Attacks/Basic");
//		equip = GameObject.Find("GUI/CharacterInventory/EquipmentPanel").GetComponent<CharacterEquipment>();
	//	inv = GameObject.Find("GUI/CharacterInventory/InventoryPanel").GetComponent<CharacterInventory>();

		//current = GameObject.Find("SaveInfo").GetComponent<PlayerSave>().playerInfo;

	}
	public override void Start () {
		//current = GameObject.Find("SaveInfo").GetComponent<PlayerSave>().playerInfo;
		//current = PlayerSave;
		current = saveInfo.GetComponent<PlayerSave>().playerInfo;

		Debug.Log("start happened " + current.CurrentLife);


		this.Name = "Ogre";
		this.Description = "Just a normal monster";
		this.MaxLife = 100;
		this.CurrentLife = 100;;
		this.ExperienceGiven = 100;
		this.Level = 1;
		this.MoveSpeed = 10;
		this.Damage = 15;
		this.OptimalRange = 1;
		this.MaxRange = 5;
		this.AttackSpeed = 1.5f;

		/*
		this.Name = current.Name;
		this.Description = current.Description;
		this.MaxLife = current.MaxLife;
		this.CurrentLife = current.CurrentLife;
		this.MaxMana = current.MaxMana;
		this.CurrentMana = current.CurrentMana;
		this.ExperienceGiven = current.ExperienceGiven;
		this.Level = current.Level;
		this.Endurance = current.Endurance;
		this.Strength = current.Strength;
		this.Intellect = current.Intellect;
		this.MoveSpeed = current.MoveSpeed;
		this.Gold = current.Gold;
		this.Damage = current.Damage;
		this.OptimalRange = current.OptimalRange;
		this.MaxRange = current.MaxRange;
		this.AttackSpeed = current.AttackSpeed;
*/
		CurrentState = States.IDLE;
		droppableLoot = new List<BaseItem>();

		//CreateNewWeapon thing = new CreateNewWeapon();
		//Loot.Add(thing.CreateWeapon());

		//nav = GetComponent<NavMeshAgent>();

		//nav.updateRotation = false;

//		Target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BaseEntity>();

		particleTest = gameObject.GetComponent<ParticleSystem>();


    }

	void UpdateStats()

	{
		//this.MaxLife = 200;
		//this.CurrentLife = 200;
	
			//this.Damage = 10;
	}
	void LevelUp()
	{
		MaxLife += 50;
		CurrentLife = MaxLife;
	}

	public void InitializeNavMeshAgent()
	{
		nav = GetComponent<NavMeshAgent>();
	}
	public void GainExperience(int e)
	{
		Experience += e;

		if(Experience > (100 * Level))
			{
				Level++;
			    LevelUp();
				Experience -= (100*Level);
			}
	}
	public override void Update ()
	{
		//UpdateStats();
			//playerLocation = playerObject.transform.position;

			//todo limit rate of move
		if(active)
		{
				
		/*if(Target == null)
		{
			Target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BaseEntity>();
		}
		*/
			if(Target == null)
			{
				Target = ChooseBestTarget();
			}
		else{
			

			if (Time.time > nextActionTime ) 
			{ 
				nextActionTime = Time.time + period; 
				MoveToTargetAtOptimalRange(Target);
				transform.LookAt(Target.transform.position);
					if(!attacking)
					{
						if(Vector3.Distance(Target.transform.position,  transform.position) < MaxRange)
						{
					StartCoroutine(AttackZ());
						}
					}
				
			}
		}

			if (CurrentLife <= 0)
			{
				DestroyObject(this.gameObject);
			}


		}
	}
	IEnumerator AttackZ()
	{
		attacking = true;
		basicAttack.SetActive(true);
		yield return new WaitForSeconds(0.125f);
		basicAttack.SetActive(false);
		yield return new WaitForSeconds(AttackSpeed);
		attacking = false;
	}


	EnemyEntity ChooseBestTarget()
	{
		RoomTransition();
		EnemyEntity min = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach(Component c in dungeonStatus.enemies)
		{
			if(c != null)
			{
			Vector3 directionToTarget = c.transform.position - currentPos;
			float dist = directionToTarget.sqrMagnitude;
			
			if(dist < minDist)
			{
				min = (EnemyEntity)c;
				minDist = dist;
			}
			}
		}
		return min;
	}

	void RoomTransition()
	{
		dungeonStatus = GameObject.Find("DungeonStatus").GetComponent<Dungeon>();

	}

	public void TakeDamage (int damage)
	{
		damage = 2;

		CurrentLife -= damage;
		if(CurrentLife < 0)
		{
			CurrentLife = 0;
		}
	}


}



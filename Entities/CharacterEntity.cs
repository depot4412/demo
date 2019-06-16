using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterEntity : BaseEntity
	{
	public string Sprite { get; set; }

	public NavMeshHit pointOnNavMesh;

	public BaseClass Class { get; set; }

	public int MaxLife { get; set; }
	public int CurrentLife { get; set; }
	public int ExperienceGiven { get; set; }
	public int Level { get; set; }

	public int MoveSpeed { get; set; }
	public int Damage { get; set; }
	public int OptimalRange { get; set; }
	public int MaxRange { get; set; }
	public float AttackSpeed { get; set; }

	public BaseEntity Target { get; set; }

	private bool attackOnCooldown = false;
	public float nextActionTime = 0.0f;
	public float period = 0.25f;



		public CharacterEntity()
		{
		}

			public void TakeDamage (int damage)
	{

		CurrentLife -= damage;
		if(CurrentLife < 0)
		{
			CurrentLife = 0;
		}
	}

	public virtual void MoveToLocation(Vector3 v) {
		nav.destination = v;
	}

	public virtual void MoveToTarget(BaseEntity g) {
		nav.destination = g.transform.position;
	}

	public virtual void MoveToTargetAtOptimalRange(BaseEntity g) {


		NavMesh.SamplePosition(g.transform.position, out pointOnNavMesh, 15, NavMesh.AllAreas);

		Vector3 boxpos = g.transform.position;
		Vector3 characterpos = nav.transform.position;

		Vector3 spot = boxpos + (characterpos - boxpos) * ((float)(this.OptimalRange*10)) / (characterpos - boxpos).sqrMagnitude;

		NavMesh.SamplePosition(spot, out pointOnNavMesh, 5, NavMesh.AllAreas);

		nav.destination = pointOnNavMesh.position;

		CurrentState = States.MOVING_TO_ATTACK;

	}

	public virtual void AttackTarget(CharacterEntity g) {
		if(Vector3.Distance(g.transform.position, this.gameObject.transform.position) < this.MaxRange)
		{
			g.TakeDamage(this.Damage);
		}
	}

	public virtual void SetTarget(BaseEntity g) {
		Target = g;
	}

	public virtual void ClearTarget() {
		Target = null;
	}

	public virtual void AttackIfOffCooldown(BaseEntity g)
	{
		if(attackOnCooldown == false)
		{
			if(Vector3.Distance(g.transform.position, this.gameObject.transform.position) < this.MaxRange)
			{
				//playerObject.GetComponent<Player>().TakeDamage(this.Damage);
				transform.LookAt(g.transform.position);
				attackOnCooldown = true;
				CurrentState = States.ATTACKING;
				particleTest.Play();
				Invoke("Attack" , AttackSpeed);



			}

		}

	}
	private bool HasTarget()
	{
		if(Target != null)
			return true;
		return false;
	}

	public virtual void Update () {

		//playerLocation = playerObject.transform.position;

		//todo limit rate of move

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
		}
		}



	}

	}



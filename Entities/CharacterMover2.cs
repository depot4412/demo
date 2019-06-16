using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class CharacterMover2 : MonoBehaviour
{

	// Use this for initialization
	NavMeshAgent agent;
	NavMeshHit there;
	public GameObject selectedTarget;
	public bool gotTarget = false;
	//var thing = new Interactable();

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame

	void Update ()
	{
		//Only search if clicked
		if (Input.GetMouseButtonDown (0)) {
			//Shoot ray from mouse position
			if(!EventSystem.current.IsPointerOverGameObject())
			{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll (ray);
		
			foreach (RaycastHit hit in hits) { //Loop through all the hits
				if (hit.transform.gameObject.layer == 8) { //Make a new layer for targets



					print ("targetted: " + hit.transform + " at " + hit.transform.position);



					NavMesh.SamplePosition(hit.transform.gameObject.transform.position, out there, 15, NavMesh.AllAreas);

					Vector3 boxpos = hit.transform.position;
					Vector3 characterpos = agent.transform.position;

					Vector3 spot = boxpos + (characterpos - boxpos) * 3f / (characterpos - boxpos).sqrMagnitude;

					NavMesh.SamplePosition(spot, out there, 5, NavMesh.AllAreas);

					agent.destination = there.position;
					//You hit a target!
					//DeselectTarget(); //Deselect the old target
						selectedTarget = hit.transform.gameObject;
					//Debug.Log(hit.transform.gameObject.GetComponentInParent<Interactable>());
					//SelectTarget(); //Select the new target
					gotTarget = true; //Set that we hit something
					break; //Break out because we don't need to check anymore
				}

						else
					{
						selectedTarget = null;
						gotTarget = false;
					}
				{

				}
			}
			if (!gotTarget) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
					print("normal ray hit");
					agent.destination = hit.point;
				}
			}//DeselectTarget(); //If we missed everything, deselect
		}
		}
		if(gotTarget)
		{
			if(Vector3.Distance(this.gameObject.transform.position, selectedTarget.transform.position) < 4)
			{
				agent.ResetPath();
				selectedTarget.GetComponent<IInteractable>().Interact();
				selectedTarget = null;
				gotTarget = false;


			}
		}

	}
		

}

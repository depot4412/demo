using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public List<Skill> skills;
	// Use this for initialization
	void Start () {
		skills = new List<Skill>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddSkill(Skill skill)
	{
		if(!skills.Contains(skill))
		skills.Add(skill);

		skills.Sort();
	}
		
}

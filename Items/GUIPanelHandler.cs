using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPanelHandler : MonoBehaviour {

	// Use this for initialization

	public GameObject inv;
	public GameObject equip;
	//bool isEnabled = false;


	void Awake (){

	}
	void Start () {
		this.gameObject.SetActive(true);
	}


	void DisableGUI(GameObject g)
	{
		g.SetActive(false);
	}
	void EnableGUI(GameObject g)
	{
		g.SetActive(true);
	}
    void ToggleGUI(GameObject g)
    {
        if (Game.sceneTransitionManager.GetScene() == "Town")
        { 
        if (g.activeSelf)
        {
            g.SetActive(false);
        }
        else
        {
            g.SetActive(true);
        }
    }
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
		{
			ToggleGUI(inv);
		}

		if(Input.GetKeyDown("c"))
		{
			ToggleGUI(equip);
		}
	}
}

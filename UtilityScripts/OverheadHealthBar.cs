using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadHealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/*
	 * 
	 *  Create one normal Screen Space canvas. Add a HealthBar script to the enemy, that does the following: 
1. Instantiate a healthbar UI element (Would be better to pool this)
2. Attach the instantiated UI element to the canvas (hpBar.transform.SetParent(canvas.transform, false);)
3. In the Update loop, update the position of the UI element (hpBar.transform.position = Camera.main.WorldToScreenPoint((Vector3.up * offset) + transform.position);) [offset is a variable that controls how much above the enemy the healthbar should be displayed]
4. Also in the update loop, update the UI health. (Would be more elegant to control this with events)
5. in the OnDestroy() method, don't forget to destroy the UI element.
https://github.com/SebLague/Object-Pooling

*/

}

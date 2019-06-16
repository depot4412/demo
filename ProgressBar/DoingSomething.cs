using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoingSomething : MonoBehaviour {

	Image foregroundImage;
	Text  pText;
	GameObject player;
	float mod = 0;

	// Use this for initialization
	void Awake() {
		foregroundImage = gameObject.GetComponentInChildren<Image>();
		pText = gameObject.GetComponentInChildren<Text>();
		player = GameObject.Find("PlayerParty/Player1");
	}


	public void RunProgressBar(int time, string text){
		mod = time;
		foregroundImage.gameObject.SetActive(true);
		pText.gameObject.SetActive(true);
		this.gameObject.transform.position = player.transform.position;
		pText.text = text;

	}

	void Start () {
		pText.text = "STARTED";
		foregroundImage.fillAmount = 0;
		foregroundImage.gameObject.SetActive(false);
		pText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//this.gameObject.transform.position = player.transform.position;

		if(foregroundImage.fillAmount < 1)
			{
				//Debug.Log(Time.deltaTime);
			foregroundImage.fillAmount += Time.deltaTime/mod;
			}
		else
		{
			foregroundImage.gameObject.SetActive(false);
			pText.gameObject.SetActive(false);
		}
	}
}

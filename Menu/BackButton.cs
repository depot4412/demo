using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	private Button backButton;

	void Awake()
	{
		backButton = GetComponent<Button>();
	}
	void Start()
	{


		backButton.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
        Game.sceneTransitionManager.ChangeScene("Menu");

	}


}

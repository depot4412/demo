using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour {
	
	private Button newGame;

	void Awake()
	{
		newGame = GetComponent<Button>();
	}
	void Start()
	{


		newGame.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
        Game.sceneTransitionManager.ChangeScene("CreateCharacter");

	}


}

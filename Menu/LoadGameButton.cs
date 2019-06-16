using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour {

	private Button loadGame;
	public PlayerSave saveData;

	void Awake()
	{
		loadGame = GetComponent<Button>();
	}
	void Start()
	{


		loadGame.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
        Game.sceneTransitionManager.ChangeScene("LoadGame");

	}


}

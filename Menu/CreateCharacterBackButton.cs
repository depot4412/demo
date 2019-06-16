using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Handles the logic of the Back button while at character creation
/// </summary>
public class CreateCharacterBackButton : MonoBehaviour {

	private Button back;

	void Awake()
	{
		back = GetComponent<Button>();
	}

	 void Start()
	{
		back.onClick.AddListener(OnClick);
	}

	/// <summary>
	/// When clicked, return to base menu
	/// </summary>
	 void OnClick()
	{
        Game.sceneTransitionManager.ChangeScene("Menu");
	}


}

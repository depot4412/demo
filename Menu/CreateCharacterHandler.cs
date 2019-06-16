using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class CreateCharacterHandler : MonoBehaviour {

	public ToggleGroup characterSelection;
	public PlayerEntity player;

	void Awake()
	{
        /*
		characterSelection = GameObject.Find("Boring Man").GetComponent<ToggleGroup>();
		player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
        */
	}

	 void Start()
	{
		

		//toggledSelection.onValueChanged.AddListener((x) => Invoke("SelectedCharacter",0f));

	}

	 void SelectedCharacter()
	{
		//Game.current.player.PlayerClass = characterSelection.ActiveToggles().FirstOrDefault().name;

		print(characterSelection.ActiveToggles().FirstOrDefault());

		/*
		string Class = Game.current.character.PlayerClass;

		switch(Class)
		{
		case "Boring Man":
			Game.current.player.Sprite = "beastmaster";
			break;
		case "Definitely Not Stupid":
			Game.current.player.Sprite = "ogremagi";
			break;
		default:
			Game.current.player.Sprite = "ogremagi";
			break;

		}
*/
		//player.Sprite = "ogremagi";
		//player.Class = new BaseWarriorClass();

	}

}

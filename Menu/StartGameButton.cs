using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class StartGameButton : MonoBehaviour {


	private Button startGame;
	private Canvas canvas;
	private PlayerEntity player;
	private GameObject gui;
	private GameObject inventoryLogic;

	void Awake()
	{
		canvas = (Canvas)GetComponent ("Canvas");
		player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
		startGame = GetComponent<Button>();
	}

	void Start()
	{

		startGame.onClick.AddListener(OnClick);
	}

	public void Enable()
	{
		
			startGame.interactable = true;

			
	}

	private void OnClick()
	{
		Debug.Log(GameObject.Find("InputField").GetComponent<InputField>().text);

		player.Name = GameObject.Find("InputField").GetComponent<InputField>().text.ToString();



        //SaveLoad.Save();
        Game.sceneTransitionManager.ChangeScene("Town");


		player.InitializeNavMeshAgent();



	

	}
}

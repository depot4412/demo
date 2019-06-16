using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Manages which components of the main menu are active
/// </summary>
public class CanvasManager : MonoBehaviour {

	public Button startGame;
    public Canvas canvas;
    public ToggleGroup characterToggle;
    public InputField charName;

	void Awake()

	{
        /*
		canvas = (Canvas)GetComponent ("Canvas");

		characterToggle = GameObject.Find("Boring Man").GetComponent<ToggleGroup>();

		startGame = GameObject.Find("StartGame").GetComponent<Button>();

		charName = GameObject.Find("InputField").GetComponent<InputField>();
        */
	}

		                    
	/// <summary>
	/// Turns on the start game button if a charatcer has been selected and a name input.
	/// </summary>
	void Update()
	{
		if(characterToggle.AnyTogglesOn() && charName.text.Length > 3)
			
		{
			startGame.interactable = true;
		}
		else
		{
			startGame.interactable = false;
		}
	}
}

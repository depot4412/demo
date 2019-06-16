using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameInteractableObject : MonoBehaviour, IInteractable{

    // Use this for initialization

    public GameObject savePanel;
    bool interacting = false;

    void Start()
    {
        savePanel.SetActive(false);

    }

    void Update()
    {
        /*
        if(!interacting && 3 > Vector3.Distance(Game.instance.player.transform.position, this.transform.position))
            {
            interacting = true;
            Interact();
        }
        else
        {
            interacting = false;
        }
        */
    }

    public void Interact()
    {
        savePanel.SetActive(true);
        Time.timeScale = 0;

    }

}

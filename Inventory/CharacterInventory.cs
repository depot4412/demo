using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : BaseInventory
{
    public System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();

        InitializeSlots(36);

        CreateNewWeapon thing = new CreateNewWeapon();
        var obv = thing.CreateWeapon();
        AddItemToEmptySlot(obv);
        obv = thing.CreateWeapon();
        AddItemToEmptySlot(obv);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            CreateNewWeapon thing = new CreateNewWeapon();
            var obv = thing.CreateWeapon();
            AddItemToEmptySlot(obv);
        }
    }
}

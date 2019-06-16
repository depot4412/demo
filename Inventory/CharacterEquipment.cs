using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : BaseInventory
{
    // Start is called before the first frame update
    void Start()
    {
        int slotAmount = 10;

        for (int i = 0; i < slotAmount; i++)
        {
            Slot slot = new Slot();
            slot.allowSlotType(BaseItem.ItemTypes.ALL);
            items.Add(slot);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

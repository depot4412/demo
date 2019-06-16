using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInventory : MonoBehaviour
{
    [SerializeField]
    public List<Slot> items = new List<Slot>();
    public UnityEvent Updated = new UnityEvent();

    public virtual void InitializeSlots(int slotAmount)
    {
        for (int i = 0; i < slotAmount; i++)
        {
            Slot slot = new Slot();
            slot.allowSlotType(BaseItem.ItemTypes.ALL);
            slot.pos = i;
            items.Add(slot);
        }
    }

    public bool IsSlotEmpty(int slot)
    {
       if (items[slot].GetItem().itemID == -1)
            return true;

       return false;


    }
    public bool CheckIfItemIsInInventory(BaseItem item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item.itemID == item.itemID)
            {
                return true;
            }
        }

        return false;
    }

    public bool AddItemToEmptySlot(BaseItem item)
    {
        Debug.Log("Adding " + item.itemName + " the " + item.itemType);
        for (int i = 0; i < items.Count; i++)
            {
                if (IsSlotEmpty(i))
                {
                    items[i].SetItem(item);
                    Debug.Log("Added " + items[i].item.itemName + " the " + items[i].item.itemType);
                Updated.Invoke();
                return true;
                }
            }
        return false;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

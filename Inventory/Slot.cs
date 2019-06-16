using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{

    private List<BaseItem.ItemTypes> allowedItemTypes = new List<BaseItem.ItemTypes>();


    public int pos = -1;
    public BaseItem item = new BaseItem();

    public BaseItem GetItem()
    {
        return item;
    }

    public bool SetItem(BaseItem value)
    {
        //Debug.Log("trying to add " + allowedItemTypes.Count);
        if (doesSlotHoldItemType(value)){
          // Debug.Log(allowedItemTypes.Count);
            item = value;
            return true;
       }
        return false;
    }

    public void denySlotType (BaseItem.ItemTypes type)
    {
        allowedItemTypes.Remove(type);
    }
    public void allowSlotType (BaseItem.ItemTypes type)
    {
        if (!allowedItemTypes.Contains(type))
        {
            allowedItemTypes.Add(type);
            //Debug.Log("Added " + type);
           // Debug.Log("new count = " + allowedItemTypes.Count);
        }
    }
    public bool doesSlotHoldItemType(BaseItem item)
    {
        if (allowedItemTypes.Contains(item.itemType) || allowedItemTypes.Contains(BaseItem.ItemTypes.ALL))
            return true;
        return false;
    }
    void Awake()
    {
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

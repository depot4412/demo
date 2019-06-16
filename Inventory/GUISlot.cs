using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISlot : MonoBehaviour
{
    public int pos;
    public BaseItem item;
    public BaseInventory syncInventory;
    public GameObject itemPrefab;
    public Tooltip tooltip;



    // Start is called before the first frame update
    void Start()
    {
        syncInventory.Updated.AddListener(UpdateSlots);
        if(this.syncInventory.items[pos].item.itemID != -1)
        {
            var obj = Instantiate(itemPrefab);
            obj.transform.position = this.gameObject.transform.position;
            obj.GetComponent<GUIItem>().pos = this.pos;
            obj.GetComponent<GUIItem>().tooltip = tooltip.GetComponent<Tooltip>();
            obj.GetComponent<GUIItem>().syncInventory = this.syncInventory;
            obj.GetComponent<GUIItem>().item = syncInventory.items[pos].GetItem();
            obj.gameObject.transform.SetParent(this.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSlots()
    {
        if(syncInventory.items[pos].item.itemID == -1 && transform.childCount > 0)
        {

            Object.Destroy(transform.GetChild(0).gameObject);
            
        }
        else if (this.syncInventory.items[pos].item.itemID != item.itemID)
        {
            GameObject obj;
            if (gameObject.transform.childCount > 0)
            {
                obj = gameObject.transform.GetChild(0).gameObject;
            }
            else
            {
                obj = Instantiate(itemPrefab);
            }
            obj.GetComponent<GUIItem>().pos = this.pos;
            obj.GetComponent<GUIItem>().tooltip = tooltip.GetComponent<Tooltip>();
            obj.GetComponent<GUIItem>().syncInventory = this.syncInventory;
            obj.GetComponent<GUIItem>().item = syncInventory.items[pos].GetItem();
            obj.gameObject.transform.SetParent(this.transform);
            obj.transform.position = this.gameObject.transform.position;
        }
    }
}

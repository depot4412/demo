using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    public Tooltip tooltip;
    public GameObject itemPrefab;
    public GameObject slotPrefab;
    public BaseInventory syncInventory;

    public List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.tooltip = this.GetComponent<Tooltip>();
        for (int i = 0; i < syncInventory.items.Count; i++)
        {
            slots.Add(Instantiate(slotPrefab));
            slots[i].GetComponent<GUISlot>().pos = i;
            slots[i].GetComponent<GUISlot>().syncInventory = this.syncInventory;
            slots[i].GetComponent<GUISlot>().itemPrefab = this.itemPrefab;
            slots[i].GetComponent<GUISlot>().tooltip = this.tooltip;
            slots[i].transform.SetParent(this.gameObject.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

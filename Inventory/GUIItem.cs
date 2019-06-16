using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    public int pos;
    public BaseItem item;
    public BaseInventory syncInventory;
    public Tooltip tooltip;
    private Vector2 offset;
    private Transform home;
    public GUISlot currentSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentSlot = this.gameObject.GetComponentInParent(typeof(GUISlot)) as GUISlot;
        this.transform.SetParent(gameObject.transform.parent.transform.parent.transform.parent.transform.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.hovered.FindIndex(x => x.name.Contains("Slot(Clone)")) != -1 && eventData.hovered.Count > 0)
        {
            GameObject thisSlot = eventData.hovered.FindLast(x => x.name.Contains("Slot(Clone)")).transform.gameObject;
            Debug.Log("Mouseover slot can hold this " + thisSlot.gameObject.name);

            BaseInventory targetVirtualInventory = (thisSlot.transform.parent.GetComponent(typeof(InventoryGUI)) as InventoryGUI).syncInventory;
            GUISlot targetSlot = thisSlot.gameObject.GetComponent(typeof(GUISlot)) as GUISlot;
            BaseInventory currentInventory = this.syncInventory;
            Debug.Log("we got here3");
            if (thisSlot.transform.childCount > 0)
            {
                
                if(currentSlot.syncInventory.items[currentSlot.pos].doesSlotHoldItemType(targetVirtualInventory.items[targetSlot.pos].item)
                 && targetSlot.syncInventory.items[targetSlot.pos].doesSlotHoldItemType(item))
                {
                    Debug.Log("we got here2");
                    BaseItem temp = new BaseItem();
                    temp = this.item;

                    var targetSlotItem = thisSlot.gameObject.GetComponentInChildren(typeof(GUIItem)) as GUIItem;
                    targetSlotItem.transform.position = currentSlot.transform.position;
                    targetSlotItem.pos = pos;
                    targetSlotItem.home = home;
                    targetSlotItem.transform.SetParent(currentSlot.transform);
                    currentInventory.items[pos].item = targetSlot.item;



                    this.transform.SetParent(thisSlot.transform);
                    this.transform.position = thisSlot.transform.position;
                    this.pos = thisSlot.GetComponent<GUISlot>().pos;
                    targetVirtualInventory.items[pos].item = temp;
                    home = targetSlot.transform;



                }
                else
                {
                    Debug.Log("we got here4");
                    this.transform.SetParent(home);
                    this.transform.position = home.transform.position;
                }

            }
            //bug not working for other inventory
            else if (targetSlot.syncInventory.items[targetSlot.pos].doesSlotHoldItemType(item))
            {
                Debug.Log("we got here");
                syncInventory.items[pos].item = new BaseItem();
                this.transform.SetParent(thisSlot.transform);
                this.transform.position = thisSlot.transform.position;
                this.pos = thisSlot.GetComponent<GUISlot>().pos;
                targetVirtualInventory.items[pos].item = this.item;
                home = targetSlot.transform;
            }
            else
            {
                this.transform.SetParent(home);
                this.transform.position = home.transform.position;
            }
        }
        else
        {
            Debug.Log("we got here5");
            this.transform.SetParent(home);
            this.transform.position = home.transform.position;
        }
        Debug.Log("we got here6");
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    void Start()
    {
        this.item = syncInventory.items[pos].GetItem();

        this.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.spriteLocation);

        home = this.transform.parent;
    }

    void Update()
    {
        
    }
}

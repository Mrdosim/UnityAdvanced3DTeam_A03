using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDragAndDrop : MonoBehaviour
{
    public UIInventory inventory;
    public Transform MakeIconPosition;

    public ItemSlot ItemSlot;
    public ItemData ItemData;

    public Image iconImage;
    public GameObject iconImageObject;

    private void Awake()
    {
        inventory = GetComponentInParent<UIInventory>();
        ItemSlot = GetComponent<ItemSlot>();
        MakeIconPosition = transform.parent.parent.GetComponent<Transform>();
    }


    public void MousePointerUp()
    {
        //Debug.Log("마우스 포인터 업" + ItemSlot.index);
        if (ItemSlot.item != null) //슬롯에 아이템이 있다면
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(iconImage.gameObject);

            if (inventory.isEnter && inventory.isDragging)
            {
                ItemSlot.Clear();
            }

        }
        else //없다면
        {
            transform.GetChild(0).gameObject.SetActive(false);
            inventory.isDragging = false;
        }

    }

    public void MousePointerEnter()
    {
        Debug.Log("마우스 포인터 엔터");
        inventory.isEnter = true;

        if (inventory.isDragging == false)
        {
            if (ItemSlot.item != null)
            {
                ItemInfoUI.Instance.sendItemName = ItemSlot.item.displayName;
                ItemInfoUI.Instance.sendItemInfo = ItemSlot.item.description;

                ItemInfoUI.Instance.UpdateUI();
                ItemInfoUI.Instance.UIOn();
            }
        }

    }

    public void MousePointerExit()
    {
        Debug.Log("마우스 포인터 엑시트" + ItemSlot.index);
        ItemInfoUI.Instance.UIOff();
        ItemInfoUI.Instance.ClearUI();
        inventory.isEnter = false;
    }
    public void MousePointerDown()
    {
        //Debug.Log("마우스 포인터 다운");

        if (ItemSlot.item != null)
        {
            ItemInfoUI.Instance.UIOff();

            inventory.DraggingItem = ItemSlot.item;
            iconImage = Instantiate(ItemSlot.Icon, MakeIconPosition);
            iconImage.color = new Color(iconImage.color.r, iconImage.color.g, iconImage.color.b, 80);
            iconImage.gameObject.layer = 2;
            iconImage.raycastTarget = false;
            iconImage.transform.SetParent(MakeIconPosition);

            transform.GetChild(0).gameObject.SetActive(false);
            iconImage.transform.position = Input.mousePosition;
        }
        
    }

    public void MousePointerDrag()
    {
        if (ItemSlot.item != null)
        {
            inventory.isDragging = true;
            iconImage.transform.position = Input.mousePosition;
        }
    }

    public void MousePointerDrop()
    {
        Debug.Log("마우스 포인터 드롭" + ItemSlot.index);
        if(inventory.isDragging == true)
        {
            inventory.isDragging = false;
            ItemSlot.item = inventory.DraggingItem;
            Debug.Log("왜 안됨?");
            ItemSlot.Set();

            inventory.DraggingItem = null;
            inventory.isInvenMove = true;
        }
    }
}

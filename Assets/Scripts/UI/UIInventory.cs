using System.Collections.Generic;
using System;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIInventory : MonoBehaviour
{
	public ItemSlot[] slots;
	public GameObject inventoryWindow;
	public Transform slotPanel;
    public Transform handSlotPanel;
    public Transform dropPosition;

	[Header("Select Item")]
	public TextMeshProUGUI selectedItemName;
	public TextMeshProUGUI selectedItemDescription;
	public TextMeshProUGUI selectedItemStatName;
	public TextMeshProUGUI selectedItemStatValue;
	public GameObject useButton;
	public GameObject equipButton;
	public GameObject unequipButton;
	public GameObject dropButton;
	public GameObject SlotPrefab;
	public Outline outline;
	int slotNum = 19;

	private PlayerController controller;
	private PlayerCondition condition;
	private BuildingSystem buildingSystem;
	private Equipment equip;

	ItemData selectedItem;
	int selectedItemIndex = 0;

	int curEquipIndex;

	public List<ItemData> TestItems;

	public void Initialize()

    [Header("Drag And Drop")]
    public ItemData DraggingItem;
	public int DeletSlotIndex;
	public bool isInvenMove;
	public bool isDragging;
    public bool isEnter;

    private void Start()
	{
		controller = CharacterManager.Instance.Player.Controller;
		condition = CharacterManager.Instance.Player.Condition;
		dropPosition = CharacterManager.Instance.Player.dropPosition;
		buildingSystem = CharacterManager.Instance.Player.buildingSystem;
		buildingSystem.inventory = this;

		CharacterManager.Instance.Player.addItem += AddItem;
		equip = CharacterManager.Instance.Player.equip;

		controller.inventory += Toggle;
		equip.handInven += OnEquipButton;

        CharacterManager.Instance.Player.addItem += AddItem;

		for (int i = 0; i < slotNum; i++)
		{
			if (i < 14)
			{
                Instantiate(SlotPrefab, slotPanel).transform.SetParent(slotPanel);
			}
			else
			{
                Instantiate(SlotPrefab, handSlotPanel).transform.SetParent(handSlotPanel);
            }
			
		}

        slots = new ItemSlot[slotPanel.childCount + handSlotPanel.childCount];

		for (int i = 0; i < slots.Length; i++)
		{
			if(i < 14)
			{
                slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
			}
			else
			{
                slots[i] = handSlotPanel.GetChild(i-14).GetComponent<ItemSlot>();
            }

			slots[i].index = i;
			slots[i].inventory = this;
		}

		AddTestItem();
	
        // handSlots = 14 ~ 18

        UpdateUI();
        ClearSelectedItemWindow();

    }

	void ClearSelectedItemWindow()
	{
		useButton.SetActive(false);
		equipButton.SetActive(false);
		unequipButton.SetActive(false);
		dropButton.SetActive(false);
	}

	public bool IsOpen()
	{
		return inventoryWindow.activeInHierarchy;
	}

	void AddItem()
	{
		ItemData data = CharacterManager.Instance.Player.itemData;

		if (data.canStack)
		{
			ItemSlot slot = GetItemStack(data);
			if(slot != null)
			{
				slot.quantity++;
				UpdateUI();
				CharacterManager.Instance.Player.itemData = null;
				return;
			}
		}

		ItemSlot emptySlot = GetEmptySlot();

		if(emptySlot != null)
		{
			emptySlot.item = data;
			emptySlot.quantity = 1;
			UpdateUI();
			CharacterManager.Instance.Player.itemData = null;
			return;
		}

		ThrowItem(data);
		CharacterManager.Instance.Player.itemData = null;
	}

	void UpdateUI()
	{
		for(int i = 0;i<slots.Length;i++)
		{
			if (slots[i].item != null)
			{
				slots[i].Set();
			}
			else
			{
				slots[i].Clear();
			}
		}
	}

	ItemSlot GetItemStack(ItemData data)
	{
		for(int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item == data && slots[i].quantity < data.maxStackAmount)
			{
				return slots[i];
			}
		}
		return null;
	}

	ItemSlot GetEmptySlot()
	{
		for(int i = 0; i<slots.Length; i++)
		{
			if (slots[i].item == null)
			{
				return slots[i];
			}
		}
		return null;
	}

	void ThrowItem(ItemData data)
	{
		Instantiate(data.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
	}

	public void SelectItem(int index)
	{
		if (slots[index].item == null) { return; }

		selectedItem = slots[index].item;
        selectedItemIndex = index;

		for(int i = 0; i<selectedItem.consumables.Length; i++)
		{
			selectedItemStatName.text += selectedItem.consumables[i].type.ToString() + "\n";
			selectedItemStatValue.text += selectedItem.consumables[i].value.ToString() + "\n";
		}


		useButton.SetActive(selectedItem.type == ItemType.Consumable || selectedItem.type == ItemType.Buildable);

		equipButton.SetActive(!slots[index].equipped);
		unequipButton.SetActive(slots[index].equipped);
		dropButton.SetActive(true);
	}

	public void OnUseButton()
	{
		if(selectedItem.type == ItemType.Consumable)
		{
			for(int i = 0; i< selectedItem.consumables.Length;i++)
			{
				switch(selectedItem.consumables[i].type)
				{
					case ConsumableType.Health:
						condition.Heal(selectedItem.consumables[i].value);
						break;
					case ConsumableType.Hunger:
						condition.Eat(selectedItem.consumables[i].value);
						break;
					case ConsumableType.Thirst:
						condition.Drink(selectedItem.consumables[i].value);
						break;
					case ConsumableType.Warmth:
						condition.Heated(selectedItem.consumables[i].value);
						break;
				}
			}
			RemoveSelectedItem();
		}
		else if(selectedItem.type == ItemType.Buildable)
		{
			buildingSystem.isBuilding = true;
            buildingSystem.selectedItem = selectedItem;
            buildingSystem.ChangeCurrentBuilding(selectedItem); // ���� ���� ��ü ����
			RemoveSelectedItem();
			controller.ToggleCursor();
            inventoryWindow.SetActive(false);
		}
	}

	public void OnDropButton()
	{
		ThrowItem(selectedItem);
		RemoveSelectedItem();
	}

	public void RemoveSelectedItem()
	{
		slots[selectedItemIndex].quantity--;
		if(slots[selectedItemIndex].quantity <= 0)
		{
			selectedItem = null;
            slots[selectedItemIndex].item = null;
			selectedItemIndex = -1;
			ClearSelectedItemWindow();
		}

		UpdateUI();
	}

    public void RestoreSelectedItem()
    {
        if (selectedItemIndex >= 0 && selectedItemIndex < slots.Length)
        {
            slots[selectedItemIndex].quantity++;
            UpdateUI();
        }
    }

    public void OnEquipButton()
	{
		if (slots[equip.selectInvenNum].equipped)
		{
			UnEquip(curEquipIndex);
		}

		slots[equip.selectInvenNum].equipped = true;
		curEquipIndex = equip.selectInvenNum;
		equip.EquipNew(selectedItem);
		UpdateUI();

		SelectItem(selectedItemIndex);
	}

	void UnEquip(int index)
	{
		slots[index].equipped = false;
		CharacterManager.Instance.Player.equip.UnEquip();
		UpdateUI();
		if(selectedItemIndex == index)
		{
			SelectItem(selectedItemIndex);
		}
	}

	public void OnUnEquipButton()
	{
		UnEquip(selectedItemIndex);
	}

	void AddTestItem()
	{
		foreach (ItemData item in TestItems)
		{
			ItemSlot emptySlot = GetEmptySlot();

			if (emptySlot != null)
			{
				emptySlot.item = item;
				emptySlot.quantity = 10;
			}
		}
		UpdateUI();
	}
}

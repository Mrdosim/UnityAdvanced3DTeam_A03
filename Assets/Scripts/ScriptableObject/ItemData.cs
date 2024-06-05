using System;
using UnityEngine;

public enum ItemType
{
	Equipable, //���
	Consumable, //�Ҹ�ǰ
	Resource //�ڿ�
}

public enum ConsumableType
{
	Health, //ü��
	Hunger //���
}

[Serializable]
public class ItemDataConsumable
{
	public ConsumableType type; //ȸ�� Ÿ��
	public float value; //ȸ�� ��
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
	[Header("Info")]
	public string displayName; // ���÷��̿� �ߴ� �̸�
	public string description; // ����
	public ItemType type;
	public Sprite icon;
	public GameObject dropProefab; 

	[Header("Stacking")]
	public bool canStack; //�ߺ� ������ �����Ѱ�?
	public int maxStackAmount; //�ѹ��� ��� ���� �� �ִ°�

	[Header("Consumable")]
	public ItemDataConsumable[] consumables; //�Ҹ�ǰ�� ��� �迭�� ü��, �����

	[Header("Equip")]
	public GameObject equipPrefab; //��� ������

}

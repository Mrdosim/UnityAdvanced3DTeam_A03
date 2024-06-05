using System;
using UnityEngine;

public enum ItemType
{
	Equipable, //장비
	Consumable, //소모품
	Resource //자원
}

public enum ConsumableType
{
	Health, //체력
	Hunger //허기
}

[Serializable]
public class ItemDataConsumable
{
	public ConsumableType type; //회복 타입
	public float value; //회복 값
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
	[Header("Info")]
	public string displayName; // 디스플레이에 뜨는 이름
	public string description; // 설명
	public ItemType type;
	public Sprite icon;
	public GameObject dropProefab; 

	[Header("Stacking")]
	public bool canStack; //중복 소유가 가능한가?
	public int maxStackAmount; //한번에 몇개나 지닐 수 있는가

	[Header("Consumable")]
	public ItemDataConsumable[] consumables; //소모품일 경우 배열로 체력, 배고픔

	[Header("Equip")]
	public GameObject equipPrefab; //장비 프리팹

}

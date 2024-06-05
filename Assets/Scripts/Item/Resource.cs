using UnityEngine;

public class Resource : MonoBehaviour, IDamagable
{
	public ItemData itemToGive;
	public int woodSpawnHealth;
	private int CurrentHealth;
	public int MaxHealth;

	private void Start()
	{
		CurrentHealth = MaxHealth;
	}

	public void TakePhysicalDamage(int damage)
	{
		int beforeHealth = CurrentHealth;
		CurrentHealth -= damage;
		if(beforeHealth/woodSpawnHealth - CurrentHealth/woodSpawnHealth > 0)
		{
			Instantiate(itemToGive.dropPrefab, transform.position + new Vector3(1, 1), Quaternion.identity);
		}
		if(CurrentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public float GetHealthRatio()
	{
		return CurrentHealth / (float)MaxHealth;
	}
}

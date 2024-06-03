using System;
using UnityEngine;

public interface IDamagable
{
	void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
	public UICondition uiCondition;

	Condition health { get { return uiCondition.health; } }
	Condition hunger { get { return uiCondition.hunger; } }
	Condition stamina { get { return uiCondition.stamina; } }
	Condition thirst { get {  return uiCondition.thirst; } }
	Condition warmth { get { return uiCondition.warmth; } }

	public float noHungerHealthDecay;
	public float noThirstHealthDecay;
	public float noWarmthHealthDecay;
	public event Action onTakeDamage;
	public DayNightCycle DayNightCycle;

	void Update()
	{
		hunger.Subtract(hunger.passiveValue * Time.deltaTime);
		thirst.Subtract(thirst.passiveValue * Time.deltaTime);
		if(DayNightCycle.time < 0.2f || DayNightCycle.time > 0.8f)
		{
			warmth.Subtract(warmth.passiveValue * Time.deltaTime * 2);
		}
		else
		{
			warmth.Subtract(warmth.passiveValue * Time.deltaTime);
		}

		health.Add(health.passiveValue * Time.deltaTime);
		stamina.Add(stamina.passiveValue * Time.deltaTime);

		if (hunger.curValue == 0f)
		{
			health.Subtract(noHungerHealthDecay * Time.deltaTime);
		}
		if (thirst.curValue == 0f)
		{
			health.Subtract(noThirstHealthDecay * Time.deltaTime);
		}
		if (warmth.curValue == 0f)
		{
			health.Subtract(noWarmthHealthDecay * Time.deltaTime);
		}
		if (health.curValue == 0f)
		{
			Die();
		}
	}

	public void Heal(float amount)
	{
		health.Add(amount);
	}

	public void Eat(float amount)
	{
		hunger.Add(amount);
	}

	public void Drink(float amount)
	{
		thirst.Add(amount);
	}

	public void Heated(float amount)
	{
		warmth.Add(amount);
	}

	private void Die()
	{
		Debug.Log("Die");
	}

	public void TakePhysicalDamage(int damage)
	{
		health.Subtract(damage);
		onTakeDamage?.Invoke();
	}

	public bool UseStamina(float amount)
	{
		if (stamina.curValue - amount < 0f)
		{
			return false;
		}

		stamina.Subtract(amount);
		return true;
	}
}

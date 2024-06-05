using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EquipTool : Equip
{
	public float attackRate;
	private bool attacking;
	public float useStamina;

	[Header("Combat")]
	public int onCreatureDamage;
	public int onWoodDamage;
	public int onMineralDamage;
	private bool isAttack = false;

	private Animator animator;
	private new Camera camera;
	private int _creatureLayer;
	private int _woodLayer;
	private int _mineralLayer;

	private void Start()
	{
		animator = GetComponent<Animator>();
		camera = Camera.main;
		_creatureLayer = LayerMask.NameToLayer("Creature");
		_woodLayer = LayerMask.NameToLayer("Wood");
		_mineralLayer = LayerMask.NameToLayer("Mineral");
	}

	public override void OnAttackInput()
	{
		base.OnAttackInput();
		if(!attacking)
		{
			isAttack = true;
			if (CharacterManager.Instance.Player.Condition.UseStamina(useStamina))
			{
				attacking = true;
				animator.SetTrigger("Attack");
				Invoke("OnCanAttack", attackRate);
			}
		}
	}

	void OnCanAttack()
	{
		attacking = false;
		isAttack = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isAttack)
		{
			other.TryGetComponent(out IDamagable target);
			int targetLayer = other.gameObject.layer;
			if (target != null)
			{
				OnHit(target, targetLayer);
			}
			isAttack = false;
		}
	}

	public  void OnHit(IDamagable target, int targetLayer)
	{
		if (targetLayer == _creatureLayer)
		{
			target.TakePhysicalDamage(onCreatureDamage);
		}
		else if (targetLayer == _woodLayer)
		{
			target.TakePhysicalDamage(onWoodDamage);
		}
		else if (targetLayer == _mineralLayer)
		{
			target.TakePhysicalDamage(onMineralDamage);
		}

		//적 체력 UI에 표시
		CharacterManager.Instance.Player.Condition.EnemyHealthUIUpdate(target.GetHealthRatio());
	}

}

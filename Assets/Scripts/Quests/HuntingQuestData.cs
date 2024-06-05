using System;
using UnityEngine;

[Serializable]
public class HuntingTargets
{
	public NPC Enemy;
	public int TargetAmount;
}

// ��� ����Ʈ ������
// ����� ��ǥ ���� ��ǥ �������� �����Ѵ�.
[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/GatheringQuestData")]
public class HuntingQuestData : QuestData
{
	[Header("QuestObjectives")]
	public HuntingTargets[] questObjectives;
}

using TMPro;
using UnityEngine;
using UnityEngine.Playables;

//�ڸ� �ý��ۿ� ���۹���� �����Ѵ�.
//������Ʈ�� ���� TMP�ڸ��� �־��� text ���� �־��ش�
//������ ���ϰ� �� ��� ������ ������ ���ϰ� ���ֱ⵵ �ߴ�.
//������ �̴� �ͼ����� �۾��ϸ� ������ �����ϰ� �Ǿ���.
public class SubtitleBehaviour : PlayableBehaviour
{
	public string subtitleText;
	//public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	//{
	//	TextMeshProUGUI text = playerData as TextMeshProUGUI;
	//	text.text = subtitleText;
	//	text.color = new Color(1, 1, 1, info.weight);
	//} 
}

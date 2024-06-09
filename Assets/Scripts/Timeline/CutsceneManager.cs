using UnityEngine;
using UnityEngine.Playables;

//�ƾ����� �����ϴ� �Ŵ����� �ƾ��� �����Ű�� ����Ʈ�� �����߿��� �÷��̾� �Է��� ��ȿȭ�ϴ� bool���� �������ش�.
public class CutsceneManager : MonoBehaviour
{
	public PlayableDirector[] Directors;
	private PlayableDirector _director;
	public GameObject QuestUI;
	public GameObject Subtitle;
	Vector3 playerPos;

	private void Start()
	{
		StartNewCutScene(0);
	}

	private void Director_Stopped(PlayableDirector director)
	{
		CharacterManager.Instance.Player.Controller.ChangeControlable(true);
		if(QuestUI != null)
			QuestUI.SetActive(true);
		if(Subtitle != null) Subtitle.SetActive(false);
		
	}

	private void Director_Played(PlayableDirector director)
	{
		CharacterManager.Instance.Player.Controller.ChangeControlable(false);
		QuestUI.SetActive(false);
		Subtitle.SetActive(true);
	}

	public void StartNewCutScene(int index)
	{
		PlayableDirector cutscene = Directors[index];
		_director = cutscene;
		_director.played += Director_Played;
		_director.stopped += Director_Stopped;
		_director.Play();
	}

	public void StopCutScene()
	{
		_director.Stop();
	}
}

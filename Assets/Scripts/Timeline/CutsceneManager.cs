using UnityEngine;
using UnityEngine.Playables;

//�ƾ����� �����ϴ� �Ŵ����� �ƾ��� �����Ű�� ����Ʈ�� �����߿��� �÷��̾� �Է��� ��ȿȭ�ϴ� bool���� �������ش�.
public class CutsceneManager : MonoBehaviour
{
	public PlayableDirector[] Directors;
	private PlayableDirector _director;

	private void Start()
	{
		StartNewCutScene(Directors[0]);
	}

	private void Director_Stopped(PlayableDirector director)
	{
		CharacterManager.Instance.Player.Controller.ChangeControlable(true);
	}

	private void Director_Played(PlayableDirector director)
	{
		CharacterManager.Instance.Player.Controller.ChangeControlable(false);
	}

	private void StartNewCutScene(PlayableDirector cutscene)
	{
		_director = cutscene;
		_director.played += Director_Played;
		_director.stopped += Director_Stopped;
		_director.Play();
	}
}

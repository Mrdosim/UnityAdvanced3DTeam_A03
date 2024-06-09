using UnityEngine;
using UnityEngine.Playables;

//컷씬들을 관리하는 매니저로 컷씬을 실행시키고 퀘스트가 진행중에는 플레이어 입력을 무효화하는 bool값을 변형해준다.
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

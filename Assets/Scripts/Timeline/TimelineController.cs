using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class TimelineController : MonoBehaviour
{
	public PlayableDirector playableDirector;
	public PlayerInput playerInput;

	private void Start()
	{
		
	}

	private void OnEnable()
	{
		playableDirector.played += OnPlayableDirectorPlayed;
		playableDirector.stopped += OnPlayableDirectorStopped;
	}

	private void OnDisable()
	{
		playableDirector.played -= OnPlayableDirectorPlayed;
		playableDirector.stopped -= OnPlayableDirectorStopped;
	}

	private void OnPlayableDirectorPlayed(PlayableDirector director)
	{
		playerInput.enabled = false;
	}

	private void OnPlayableDirectorStopped(PlayableDirector director)
	{
		playerInput.enabled = true;
	}
}

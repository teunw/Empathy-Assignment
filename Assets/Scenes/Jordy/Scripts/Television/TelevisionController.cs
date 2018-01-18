using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class TelevisionController : MonoBehaviour {

	public Task task;
	public Renderer screenRenderer;
	public Material offMaterial;

    private VideoPlayer tv;
    private AudioSource audioSource;

    private float minDelay = 0.5f;
    private float nextAvailableTime = 0f;

    private void Start()
    {
	    tv = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;

	    if (StateManager.Instance.CurrentState == State.FIRST_HOMESCENE)
	    {
		    TurnOn();
	    }
    }

    public void ToggleOnOff()
    {
        if (Time.time < nextAvailableTime) return;

		if (tv.isPlaying) {
			tv.Stop ();
			if (task)
				task.Complete ();
		}
        else
            tv.Play();

        nextAvailableTime = Time.time + minDelay;
    }

	public void TurnOn()
	{
		if (!tv.isPlaying) {
			tv.Play();
		}
	}

	public void TurnOff()
	{
		if (tv.isPlaying) {
			tv.Stop ();
			if (task) 
			{
				task.Complete ();
				screenRenderer.material = offMaterial;
			}
		}
	}

    public void IncreaseVolume()
    {
        if (Time.time < nextAvailableTime) return;

        float volume = audioSource.volume + 0.2f;
        volume = Mathf.Clamp(volume, 0, 1f);
        audioSource.volume = volume;
    }

    public void LowerVolume()
    {
        if (Time.time < nextAvailableTime) return;

        float volume = audioSource.volume - 0.2f;
        volume = Mathf.Clamp(volume, 0, 1f);
        audioSource.volume = volume;
    }
}

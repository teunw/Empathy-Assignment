using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class TelevisionController : MonoBehaviour {

	public Task task;
	public Renderer screenRenderer;
	public Material offMaterial;

    private VideoPlayer tv;

    private float minDelay = 1f;
    private float nextAvailableTime = 0f;

    private void Start()
    {
        tv = GetComponent<VideoPlayer>();
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
}

using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class TelevisionController : MonoBehaviour {

	public Task task;

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
			tv.time = 0;
			tv.Stop ();
			if (task)
				task.Complete ();
		}
        else
            tv.Play();

        nextAvailableTime = Time.time + minDelay;
    }


}

using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class TelevisionController : MonoBehaviour {

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

        if (tv.isPlaying)
            tv.Stop();
        else
            tv.Play();

        nextAvailableTime = Time.time + minDelay;
    }
}

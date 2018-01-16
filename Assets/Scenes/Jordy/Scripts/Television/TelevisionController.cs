using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class TelevisionController : MonoBehaviour {

    private VideoPlayer tv;

    private void Start()
    {
        tv = GetComponent<VideoPlayer>();
    }

    public void ToggleOnOff()
    {
        if (tv.isPlaying)
            tv.Stop();
        else
            tv.Play();
    }
}

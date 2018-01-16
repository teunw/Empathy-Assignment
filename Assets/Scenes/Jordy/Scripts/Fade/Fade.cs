using System;
using UnityEngine;

public class Fade : MonoBehaviour {

    public GameObject PairedObject { get; set; }
    public float MinDelay { get; set; }

    private float nextTimeToFade = 0f;

    private bool shouldFade = false;
    public bool ShouldFade {
		get {
			return shouldFade;
		}
		set {
			shouldFade = value;
			enabled = shouldFade;
		}
	}

	void Start()
	{
		ShouldFade = false;
	}

    internal void OnFaded(FadedEvent e)
    {
        nextTimeToFade = e.NextTimeToFade;
    }

    private void FadeNow()
    {
        transform.gameObject.SetActive(false);
        PairedObject.gameObject.SetActive(true);
		PairedObject.GetComponent<Fade> ().ShouldFade = false;
		ShouldFade = false;
        EventManager.Instance.Invoke(new FadedEvent() { NextTimeToFade = Time.time + MinDelay });
    }

    // Update is called once per frame
    void Update () {
		if (shouldFade && Time.time > nextTimeToFade && Camera.main != null && !VisibilityCheck.IsVisible(Camera.main, gameObject, true, false))
        {
            FadeNow();
        }
	}
}

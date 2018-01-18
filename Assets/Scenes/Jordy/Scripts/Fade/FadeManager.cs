using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FadeManager : EventHandler {

    [Tooltip("The minimum delay between each fade.")]
    public float MinDelay = 5f;

    public FadePair[] pairs;

    private List<Fade> fadeableObjects = new List<Fade>();

    private float lastFadeTime = 0f;

	void Awake()
	{
		if (StateManager.Instance.CurrentState == State.MID_STORY) {
			StateManager.Instance.SetState (State.SECOND_HOMESCENE);
			Invoke ("FadeToHospital", 5f); // start fading after 3 seconds
		} else {
			StateManager.Instance.SetState (State.FIRST_HOMESCENE);
		}
	}

	// Use this for initialization
	void Start () {
		InitializePairs();
    }

    private void LateUpdate()
    {
        if (fadeableObjects.Count < 1 || Time.time < lastFadeTime + MinDelay) return;
        
        FadeHighestPriority();
    }

    public void InitializePairs()
    {
        foreach (FadePair pair in pairs)
        {
            pair.homeObject.PairedObject = pair.hospitalObject.gameObject;
            pair.hospitalObject.PairedObject = pair.homeObject.gameObject;
			pair.hospitalObject.gameObject.SetActive (false);
            pair.homeObject.Priority = pair.priority;
            pair.hospitalObject.Priority = pair.priority;
        }
    }

    public override void SubscribeEvents()
    {
        EventManager.Instance.AddListener<CanFadeEvent>(OnCanFade);
    }

    public override void UnsubscribeEvents()
    {
    }

    public void FadeToHome()
    {
        foreach(FadePair pair in pairs)
        {
            pair.hospitalObject.ShouldFade = true;
        }
    }

    public void FadeToHospital()
    {
        foreach (FadePair pair in pairs)
        {
            pair.homeObject.ShouldFade = true;
        }
    }

    private void AddFadableObject(Fade fade)
    {
        if (!fadeableObjects.Contains(fade))
            fadeableObjects.Add(fade);
    }

    private void FadeHighestPriority()
    {
        int maxPriority = fadeableObjects.Max(x => x.Priority);
        Fade fade = fadeableObjects.First(x => x.Priority == maxPriority);
        FadeObject(fade);
        lastFadeTime = Time.time;
        fadeableObjects.Clear();
    }

    private void FadeObject(Fade fade)
    {
        fade.transform.gameObject.SetActive(false);
        fade.PairedObject.gameObject.SetActive(true);
        fade.PairedObject.GetComponent<Fade>().ShouldFade = false;
        fade.ShouldFade = false;
        //EventManager.Instance.Invoke(new FadedEvent() { NextTimeToFade = Time.time + MinDelay });
    }

    private void OnCanFade(CanFadeEvent e)
    {
        AddFadableObject(e.FadeableObject);
    }
}

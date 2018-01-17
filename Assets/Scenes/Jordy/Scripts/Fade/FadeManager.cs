using UnityEngine;

public class FadeManager : EventHandler {

    [Tooltip("The minimum delay between each fade.")]
    public float MinDelay = 3f;

    public FadePair[] pairs;


	void Awake()
	{
		if (StateManager.Instance.CurrentState == State.MID_STORY) {
			StateManager.Instance.SetState (State.SECOND_HOMESCENE);
			Invoke ("FadeToHospital", 3f); // start fading after 3 seconds
		} else {
			StateManager.Instance.SetState (State.FIRST_HOMESCENE);
		}
	}

	// Use this for initialization
	void Start () {
		InitializePairs();
    }

    public void InitializePairs()
    {
        foreach (FadePair pair in pairs)
        {
            pair.homeObject.PairedObject = pair.hospitalObject.gameObject;
            pair.hospitalObject.PairedObject = pair.homeObject.gameObject;
			pair.hospitalObject.gameObject.SetActive (false);
			pair.homeObject.MinDelay = MinDelay;
			pair.hospitalObject.MinDelay = MinDelay;
            EventManager.Instance.AddListener<FadedEvent>(pair.homeObject.OnFaded);
            EventManager.Instance.AddListener<FadedEvent>(pair.hospitalObject.OnFaded);
        }
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

    public override void SubscribeEvents()
    {
        
    }

    public override void UnsubscribeEvents()
    {
        foreach (FadePair pair in pairs)
        {
            EventManager.Instance.RemoveListener<FadedEvent>(pair.homeObject.OnFaded);
            EventManager.Instance.RemoveListener<FadedEvent>(pair.hospitalObject.OnFaded);
        }
    }
}

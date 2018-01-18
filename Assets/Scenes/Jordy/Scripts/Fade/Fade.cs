using System;
using UnityEngine;

public class Fade : MonoBehaviour {

    public GameObject PairedObject { get; set; }
    public int Priority { get; set; }

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

    // Update is called once per frame
    void Update () {
	    
		if (shouldFade && Camera.main != null && !VisibilityCheck.IsVisible(Camera.main, gameObject, true, false))
        {
	        FadeManager.Instance.AddFadableObject(this);
            //EventManager.Instance.Invoke(new CanFadeEvent() { FadeableObject = this });
        }
	}
}

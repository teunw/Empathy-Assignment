using UnityEngine;

public class KeyController : MonoBehaviour {

    [Tooltip("The new location the key should move to when out of sight.")]
    public Transform newLocation;

    public bool ShouldDissapear {
        get
        {
            return shouldDissapear;
        }
        set
        {
            if (value)
            {
                shouldDissapear = true;
                enabled = true; // enable Update() method
            }
            else
            {
                shouldDissapear = false;
                enabled = false; // disable Update() method
            }
        }
    }

    private bool shouldDissapear;

	// Use this for initialization
	void Start () {
        ShouldDissapear = false;
	}

    public void OnGrab()
    {
        ShouldDissapear = true;
    }

    private void Update()
    {
        if (Camera.main != null && shouldDissapear && !VisibilityCheck.IsVisible(Camera.main, gameObject, true, false))
        {
            enabled = false;
            shouldDissapear = false;
            transform.position = newLocation.position;
            transform.rotation = newLocation.rotation;
        }
    }
}

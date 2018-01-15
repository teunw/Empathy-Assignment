using UnityEngine;
using VRTK;

[RequireComponent(typeof(VRTK_InteractableObject))]
public class KeyController : MonoBehaviour {

    [Tooltip("The new location the key should move to when out of sight.")]
    public Transform newLocation;

	private VRTK_InteractableObject interactableObject;

	private bool shouldDissapear;
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

	private int dissapearCounter = 0;
	   

	// Use this for initialization
	void Start () {
		interactableObject = GetComponent<VRTK_InteractableObject> ();
        ShouldDissapear = false;
		enabled = false;
	}

    public void OnGrab()
    {
		if (dissapearCounter < 1) 
		{
			ShouldDissapear = true;
			enabled = true;
		}
    }

	private void Dissapear()
	{
		enabled = false;
		shouldDissapear = false;
		interactableObject.ForceStopInteracting ();
		transform.position = newLocation.position;
		transform.rotation = newLocation.rotation;
		dissapearCounter++;
	}

    private void Update()
    {
        if (Camera.main != null && shouldDissapear && !VisibilityCheck.IsVisible(Camera.main, gameObject, true, false))
        {
			Dissapear ();
        }
    }
}

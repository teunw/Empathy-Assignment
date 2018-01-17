using UnityEngine;
using VRTK;

[RequireComponent(typeof(VRTK_InteractableObject))]
public class KeyController : MonoBehaviour {

    [Tooltip("The possible new locations the key should move to when out of sight.")]
    public Transform[] newLocations;

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

    private void Update()
    {
        if (Camera.main != null && shouldDissapear && !VisibilityCheck.IsVisible(Camera.main, gameObject, true, false))
        {
            Dissapear();
        }
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
        Transform location = GetRandomLocation();
		transform.position = location.position;
		//transform.rotation = location.rotation;
		dissapearCounter++;
	}

    public Transform GetRandomLocation()
    {
        if (newLocations.Length < 1)
        {
            Debug.LogError("There should be atleast 1 possible location");
            return null;
        }

        if (newLocations.Length == 1) return newLocations[0];

        return newLocations[Random.Range(0, newLocations.Length - 1)];
    }
}

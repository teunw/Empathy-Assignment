using UnityEngine;

public class KeyController : MonoBehaviour {


    public float minAllowedDistance = 2f;

    private bool canDisappear;
    private bool shouldDisappear;

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        if (Camera.main != null)
            Debug.Log("Is visible: " + VisibilityCheck.IsVisible(Camera.main, gameObject));
    }


}

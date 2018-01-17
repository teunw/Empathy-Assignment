using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSetActiveSelf : MonoBehaviour {

	public State state;
	public bool isActive = false;

	// Use this for initialization
	void Start () {
		if (StateManager.Instance.CurrentState == state)
			gameObject.SetActive (isActive);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSetter : MonoBehaviour {

	public State state;

	// Use this for initialization
	void Awake () {
		StateManager.Instance.SetState (state);
	}
}


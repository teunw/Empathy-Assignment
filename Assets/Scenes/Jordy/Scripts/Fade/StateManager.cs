using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
	INTRO,
	STORY,
	MID_STORY,
	FIRST_HOMESCENE,
	SECOND_HOMESCENE
}

public class StateManager {

	private static StateManager instance = new StateManager ();

	public static StateManager Instance {
		get {
			return instance;
		}
	}

	public State PreviousState { get; private set; }
	public State CurrentState { get; private set; }

	public void SetState(State state)
	{
		PreviousState = CurrentState;
		CurrentState = state;
	}
}

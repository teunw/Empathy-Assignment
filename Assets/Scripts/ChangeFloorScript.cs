using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorScript : MonoBehaviour
{

	public GameObject floor;

	public Material material;
	
	// Use this for initialization
	void Start () {
		if (StateManager.Instance.CurrentState == State.SECOND_HOMESCENE)
		{
			floor.GetComponent<Renderer>().material = material;
		}
	}
}

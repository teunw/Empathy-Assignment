using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChangeScript : MonoBehaviour
{

	public GameObject Floor;
	public Material Material;

	// Use this for initialization
	void Start()
	{
		if (StateManager.Instance.CurrentState == State.SECOND_HOMESCENE && Floor.GetComponent<Renderer>() != null && Material !=null)
		{
			Floor.GetComponent<Renderer>().material = Material;
		}
	}
}

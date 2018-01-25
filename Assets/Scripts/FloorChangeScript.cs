using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

	public void ChangeFloorDelayed(float delay =0)
	{
		if (Material != null)
		{
			StartCoroutine(ChangeFloor(delay));
		}
	}

	IEnumerator ChangeFloor(float delay)
	{
		yield return new WaitForSeconds(delay);
		Floor.GetComponent<Renderer>().material = Material;
	}
}

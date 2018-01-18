using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseManager : MonoBehaviour {

	public void InitiateEndFase()
	{
		EventManager.Instance.Invoke(new EndFaseEvent());
	}
}

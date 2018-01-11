using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotDepositDetector : MonoBehaviour
{
	public GameObject ObjectToDetect;
	public UnityEvent ActionsOnDetection;
	public UnityEvent ActionsOnLeave;

	private bool _hasKeyBeenPlaced = false;
	
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals(ObjectToDetect) && !this._hasKeyBeenPlaced)
		{
			ActionsOnDetection.Invoke();
			this._hasKeyBeenPlaced = true;
			Debug.Log("Key placed");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.Equals(ObjectToDetect) && this._hasKeyBeenPlaced)
		{
			ActionsOnLeave.Invoke();
			this._hasKeyBeenPlaced = false;
			Debug.Log("Key left");
		}
	}
}

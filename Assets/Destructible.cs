using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Destructible : MonoBehaviour
{
	
	public GameObject DestructibleObject;

	public virtual void Destroy()
	{
		var dest = Instantiate(this.DestructibleObject, transform.position, transform.rotation, transform.parent);
		
		this.gameObject.SetActive(false);
	}
}

public class WaitUntilHitsGround : CustomYieldInstruction
{
	private bool _keepWaiting = true;

	public override bool keepWaiting
	{
		get { return _keepWaiting; }
	}

	public void TriggerHitGround()
	{
		this._keepWaiting = false;
		Debug.Log("Triggered");
	}
}

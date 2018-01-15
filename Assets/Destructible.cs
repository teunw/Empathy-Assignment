using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Destructible : MonoBehaviour
{

	public GameObject DestructibleObject;

	public void Destroy()
	{
		var dest = Instantiate(this.DestructibleObject, transform);
		dest.transform.parent = this.transform.parent;
		Destroy(this.gameObject);
	}
}

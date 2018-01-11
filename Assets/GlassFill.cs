using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class GlassFill : MonoBehaviour
{
	public GameObject[] Fills;
	public float TimeBetweenFills = 0.5f;
	public UnityEvent OnFillEvent;
        
	private bool _isFilling = false;
        
	/// <summary>
	/// Empies one of the fills in the glass
	/// </summary>
	/// <returns>True if glass was emptied, false otherwise</returns>
	public bool Empty()
	{
		var f = this.Fills.FirstOrDefault(o => o.activeSelf);
		if (f != null)
		{
			f.SetActive(false);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Fills one of the fills in the glass
	/// </summary>
	/// <returns>True if glass was filled, false otherwise</returns>
	public bool Fill()
	{
		var f = this.Fills.LastOrDefault(o => !o.activeSelf);
		if (f != null)
		{
			f.SetActive(true);
			return true;
		}
		return false;
	}

	private IEnumerator FillWait()
	{
		yield return new WaitForSeconds(this.TimeBetweenFills);
		Debug.Log("Filling");
		this._isFilling = false;
		if (!Fill())
		{
			this.OnFillEvent.Invoke();
		}
	}
        
	public void OnParticleCollision(GameObject other)
	{
		if (!this._isFilling)
		{
			this._isFilling = true;
			Debug.Log("Detected fill");
			StartCoroutine(this.FillWait());
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MilkKarton : MonoBehaviour
{
	public ParticleSystem MilkParticle;
	
	// Use this for initialization
	void Start () {
		if (this.MilkParticle == null)
		{
			this.MilkParticle = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Dot(transform.up, Vector3.down) > 0)
		{
			this.ActivateParticle();
		}
		else
		{
			this.DeactivateParticle();
		}
	}

	public void ActivateParticle()
	{
		MilkParticle.Play();
	}

	public void DeactivateParticle()
	{
		MilkParticle.Stop();
	}
}

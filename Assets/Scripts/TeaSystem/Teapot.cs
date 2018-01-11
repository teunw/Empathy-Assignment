using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using VRTK;

public class Teapot : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public float HotTime = 20f;
    public float DropTime = 2f;
    public bool ShouldBeDropped = true;

    // Use this for initialization
    void Start()
    {
        if (ParticleSystem == null) ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void SetBoiling()
    {
        StartCoroutine(this.SetBoilingEnum());
    }

    public IEnumerator SetDropTimer(float time)
    {
        yield return new WaitForGrab(this.GetComponent<VRTK_InteractableObject>());
        Debug.Log("Grabbed");
        yield return new WaitForSeconds(time);
        Debug.Log("Dropped");
        DropTea();
    }

    public void DropTea()
    {
        var obj = this.GetComponent<VRTK_InteractableObject>();
        obj.ForceStopInteracting();
        obj.isGrabbable = false;
    }

    public IEnumerator SetBoilingEnum()
    {
        this.ParticleSystem.Play();

        if (this.ShouldBeDropped) StartCoroutine(SetDropTimer(this.DropTime));

        yield return new WaitForSeconds(HotTime);
        this.ParticleSystem.Stop();
    }
}
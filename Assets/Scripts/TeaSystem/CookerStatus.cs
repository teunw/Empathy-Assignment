using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CookerStatus : MonoBehaviour
{
    public Color ReadyColor = Color.green;
    public Color BusyColor = Color.yellow;
    public float TimeToBoil = 20.0f;
    public Cookpad Cookpad;

    private Material _material;
    
    public void Start()
    {
        if (!this.HasComponent<Renderer>()) throw new Exception("No renderer present!");
        this._material = GetComponent<Renderer>().material;
        SetReady();
    }

    public void SetBoilingSync()
    {
        Debug.Log("Started tea");
        StartCoroutine(this.SetBoiling());
    }

    public IEnumerator SetBoiling()
    {
        this.SetBusy();
        yield return new WaitForSeconds(this.TimeToBoil);
        this.SetReady();
        StartCoroutine(this.Cookpad.Teapot.SetBoilingEnum());
    }

    public void SetReady()
    {
        this._material.color = this.ReadyColor;
    }

    public void SetBusy()
    {
        this._material.color = this.BusyColor;
    }
}
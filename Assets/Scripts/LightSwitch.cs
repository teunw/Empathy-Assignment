using System;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

[RequireComponent(typeof(VRTK_Button_UnityEvents))]
public class LightSwitch : MonoBehaviour {

    public Light[] lights;
    private bool isOn = false;

    private VRTK_Button_UnityEvents buttonEvents;

    // Initialize
    private void Start()
    {
        buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
        buttonEvents.OnPushed.AddListener(handlePush);

        // Lights
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = isOn;
        }
    }

    private void handlePush(object sender, Control3DEventArgs e)
    {
        ToggleLights();
    }

    public void ToggleLights()
    {
        isOn = !isOn;
        
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = isOn;
        }
    }
}

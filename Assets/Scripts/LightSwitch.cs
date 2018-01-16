using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light[] lights;
    private bool isOn = true;

    private float minDelay = 0.5f;
    private float nextAvailableTime = 0f;

    // Initialize
    private void Start()
    {
        // Lights
        SetEnabled(isOn);
    }

    public void ToggleLights()
    {
        if (Time.time < nextAvailableTime) return;

        isOn = !isOn;

        SetEnabled(isOn);
    }

    public void TurnOn()
    {
        if (isOn) return;

        isOn = true;

        SetEnabled(isOn);
    }

    public void TurnOff()
    {
        if (!isOn) return;

        isOn = false;

        SetEnabled(isOn);
    }

    private void SetEnabled(bool state)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = state;
        }

        nextAvailableTime = Time.time + minDelay;
    }
}

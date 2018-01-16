using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light[] lights;
    private bool isOn = true;

    // Initialize
    private void Start()
    {
        // Lights
        SetEnabled(isOn);
    }

    public void ToggleLights()
    {
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
    }
}

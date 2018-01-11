using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GlowObjectCmd : MonoBehaviour
{
    public Color GlowColor;
    public float LerpFactor = 10;
    public bool blink = false;

    public float onTime = 1.0f;
    public float offTime = 0.5f;

    public bool Glow { get { return isGlowing; } set { SetGlow(value); } }

    private bool isGlowing = false;
    private bool shouldBlink = false;
    private bool shouldGlow = false;

    public Renderer[] Renderers
    {
        get;
        private set;
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
    }

    private Color _currentColor;
    private Color _targetColor;

    void Start()
    {
        Renderers = GetComponentsInChildren<Renderer>();
        GlowController.RegisterObject(this);
        Glow = true;
    }

    private void SetGlow(bool value)
    {
        if (shouldGlow == value) return;

        if (value)
        {
            EnableGlow();
        }
        else
        {
            DisableGlow();
        }

        isGlowing = value;
    }

    private void SetOnColor()
    {
        _targetColor = GlowColor;
        enabled = true;
    }

    private void SetOffColor()
    {
        _targetColor = Color.black;
        enabled = true;
    }

    private void EnableGlow()
    {
        if (blink)
        {
            shouldBlink = true;
            StopAllCoroutines();
            StartCoroutine(Blink());
        }
        else
        {
            SetOnColor();
        }
        shouldGlow = true;
    }

    private void DisableGlow()
    {
        if (!blink) shouldGlow = false;
        shouldBlink = false;
        SetOffColor();
    }


    IEnumerator Blink()
    {
        SetOnColor();
        yield return new WaitForSeconds(onTime);
        SetOffColor();
        yield return new WaitForSeconds(offTime);

        if (shouldBlink)
        {
            StopCoroutine(Blink());
            StartCoroutine(Blink());
        }
        else
        {
            shouldGlow = false;
        }
    }

    /// <summary>
    /// Update color
    /// </summary>
    private void Update()
    {
        if (shouldGlow)
            _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);
    }
}

using System;
using System.Collections;
using UnityEngine;

public class MiddleFadeScript : MonoBehaviour
{
    public bool IsActive;
    public int MaxIndex;

    private void Start()
    {
        AddAllChildFade();
        SetIsActive(IsActive);
    }

    private void AddAllChildFade(Transform current = null)
    {
        if (current == null)
        {
            current = transform;
        }
        foreach (Transform child in current)
        {
            AddAllChildFade(child);
            var fadeScript = child.GetComponent<ChildFadeScript>();
            if (fadeScript != null && fadeScript.Index > MaxIndex)
            {
                MaxIndex = fadeScript.Index;
            }
            //todo collider word niet toegvoegd
            if (fadeScript == null && child.GetComponent<Renderer>() != null)
            {
                child.gameObject.AddComponent<ChildFadeScript>();
            }
            if (child.gameObject.GetComponent<Collider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    public void SetIsActive(bool setActive, Transform current = null)
    {
        if (current == null)
        {
            current = transform;
        }

        foreach (Transform child in current)
        {
            if (child.childCount > 0)
            {
                SetIsActive(setActive, child);
            }
            if (child.GetComponent<Renderer>() != null)
            {
                child.GetComponent<Renderer>().enabled = setActive;
            }
        }
    }


    private const int Seconds = 10;

    private IEnumerator WaitForSet(bool setActive, Transform current, int index)
    {
        yield return new WaitForSeconds(Seconds);
        Set(setActive, current, index + 1);
    }

    public void Set(bool active, Transform current = null, int index = 0)
    {
        IsActive = active;

        if (current == null)
        {
            current = transform;
        }
        foreach (Transform child in current)
        {
            Set(active, child, index);
            var childFadeScript = child.GetComponent<ChildFadeScript>();
            if (childFadeScript != null && childFadeScript.Index == index)
            {
                child.GetComponent<ChildFadeScript>().Called(active);
            }
        }

        if (index < MaxIndex)
        {
            StartCoroutine(WaitForSet(active, current, index));
        }
    }
}
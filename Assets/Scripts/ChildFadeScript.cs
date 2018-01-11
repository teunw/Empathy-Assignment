using System;
using System.ComponentModel.Design;
using DefaultNamespace;
using UnityEngine;

public class ChildFadeScript : MonoBehaviour
{
    public Transform Parent;

    public bool NeedsToChange;
    public bool OutOfSight = true;

    public bool ShouldAppear;
    private const int Seconds = 5;
    
    public int Index = 0;
    
    private Camera _camera;

    private void Start()
    {
        Parent = gameObject.transform.parent;
    }

    // todo : rename this
    /// <summary>
    /// Used to signal if it needs to start fading objects.
    /// </summary>
    /// <param name="active">used to signal if it needs to be set to active or inactive</param>
    public void Called(bool active)
    {
        ShouldAppear = active;
        NeedsToChange = true;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(i);
            if (child.GetComponent<ChildFadeScript>() != null)
            {
                child.GetComponent<ChildFadeScript>().Called(active);
            }
        }
    }

    void Update()
    {
        OutOfSight = !IsSeen();
        if (NeedsToChange && OutOfSight)
        {
            SetRenderer(gameObject);
            NeedsToChange = false;
        }
    }

    private void SetRenderer(GameObject current)
    {
        foreach (Behaviour component in current.GetComponents<Behaviour>())
        {
            if (component is ChildFadeScript) continue;
            component.enabled = ShouldAppear;
        }
        foreach (Renderer rend in current.GetComponents<Renderer>())
        {
            rend.enabled = ShouldAppear;
        }
        foreach (Collider col in current.GetComponents<Collider>())
        {
            // todo : check this again
//            col.enabled = ShouldAppear
            col.isTrigger = false;
        }
//        if (current.GetComponent<Renderer>() != null )
//        {
//            current.GetComponent<Renderer>().enabled = ShouldAppear;
//            return;
//        }
        if (current.transform.childCount == 0)
        {
            return;
        }
        for (int i = 0; i < current.transform.childCount; i++)
        {
            var child = current.transform.GetChild(i);
            SetRenderer(child.gameObject);
        }
    }

    private bool IsSeen()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.Log("camera is null");
            return true;
        }

        if (!gameObject.HasComponent<Collider>())
        {
            return true;
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        return GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider>().bounds);
    }
}
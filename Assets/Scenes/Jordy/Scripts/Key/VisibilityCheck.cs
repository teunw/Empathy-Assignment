using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisibilityCheck {

    public static bool IsVisible(Camera camera, GameObject go, bool includeChildren = false, bool includeTriggers = false)
    {
        List<Collider> colliders = GetCollidersToCheck(go, includeChildren, includeTriggers);

        if (colliders.Count == 0) Debug.LogWarning("VisibilityCheck: No collider(s) present on GameObject");

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        foreach (Collider col in colliders)
        {
            if (GeometryUtility.TestPlanesAABB(planes, col.bounds))
                return true;
        }

        return false;
    }

    private static List<Collider> GetCollidersToCheck(GameObject go, bool includeChildren, bool includeTriggers)
    {
        List<Collider> colliders = new List<Collider>();

        if (includeChildren)
        {
            if (includeTriggers)
                colliders.AddRange(go.GetComponentsInChildren<Collider>());
            else
                colliders.AddRange(go.GetComponentsInChildren<Collider>().Where(x => x.isTrigger == false));
        }
        else
        {
            if (includeTriggers)
                colliders.AddRange(go.GetComponents<Collider>());
            else
                colliders.AddRange(go.GetComponents<Collider>().Where(x => x.isTrigger == false));
        }

        return colliders;
    }
}

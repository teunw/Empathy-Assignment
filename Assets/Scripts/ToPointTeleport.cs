using UnityEngine;
using VRTK;

namespace DefaultNamespace
{
    public class ToPointTeleport : VRTK_BasicTeleport
    {
        public GameObject TeleportComponent;

        public void Start()
        {
            playArea.LookAt(TeleportComponent.transform);
            Debug.Log("Tset");
            DoTeleport(this, BuildTeleportArgs(TeleportComponent.transform, new Vector3(0f, 0f, 0f)));
        }
    }
}
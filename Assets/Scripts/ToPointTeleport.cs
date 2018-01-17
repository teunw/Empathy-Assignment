using System.Net.Sockets;
using UnityEngine;
using VRTK;

namespace DefaultNamespace
{
    public class ToPointTeleport : VRTK_BasicTeleport
    {
        public GameObject TeleportComponent;
        public float AddRotation = 0f;

        public void Update()
        {
            //find the vector pointing from our position to the target
            var direction = (TeleportComponent.transform.position - transform.position).normalized;
 
            //create the rotation we need to be in to look at the target
            var lookRotation = Quaternion.LookRotation(direction);
            lookRotation.z += AddRotation;
            DoTeleport(this, BuildTeleportArgs(TeleportComponent.transform, new Vector3(), lookRotation, true));
        }
        
        
    }
}
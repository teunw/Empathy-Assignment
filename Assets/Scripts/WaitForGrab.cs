using UnityEngine;
using VRTK;

namespace DefaultNamespace
{
    public class WaitForGrab : CustomYieldInstruction
    {
        private readonly VRTK_InteractableObject _interactableObject;
        
        public override bool keepWaiting
        {
            get { return !this._interactableObject.IsGrabbed(); }
        }

        public WaitForGrab(VRTK_InteractableObject interactable)
        {
            this._interactableObject = interactable;
        }
    }
}
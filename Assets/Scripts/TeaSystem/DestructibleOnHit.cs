using System.Collections;
using UnityEngine;

namespace TeaSystem
{
    public class DestructibleOnHit : Destructible
    {
        public GameObject ObjectToHit;
        protected WaitUntilHitsGround HitGroundYield;

        public override void Destroy()
        {
            base.Destroy();
            this.HitGroundYield = new WaitUntilHitsGround();
            StartCoroutine(this.DestroyEnumerator());
        }

        protected IEnumerator DestroyEnumerator()
        {
            Debug.Log("Waiting");
            yield return HitGroundYield;
            Debug.Log("Destroying object!");
            base.Destroy();
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            if (HitGroundYield == null) return;
            if (!other.gameObject.Equals(ObjectToHit)) return;
            HitGroundYield.TriggerHitGround();
        }
    }
}
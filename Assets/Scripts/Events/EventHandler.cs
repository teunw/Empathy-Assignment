using UnityEngine;

public abstract class EventHandler : MonoBehaviour {

    public abstract void SubscribeEvents();
    public abstract void UnsubscribeEvents();

    protected virtual void OnEnable()
    {
        SubscribeEvents();
    }

    protected virtual void OnDisable()
    {
        UnsubscribeEvents();
    }
}

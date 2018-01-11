using UnityEngine;

public class Key : EventHandler {

    [Tooltip("The minimum distance the new location must be from the key's location.")]
    public float minDistance = 1f;
    [Tooltip("The possible new locations for the key.")]
    public Transform[] locations;

    private int randomTryCount = 0;
    private int maxRandomTries = 5;

    public override void SubscribeEvents()
    {
        EventManager.Instance.AddListener<KeyChangingLocationEvent>(OnKeyChangingLocation);
    }

    public override void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<KeyChangingLocationEvent>(OnKeyChangingLocation);
    }

    private void OnKeyChangingLocation(KeyChangingLocationEvent e)
    {
        // get new random position
        Vector3 newPosition = GetRandomValidLocation(e.key.transform.position);
        // when valid, change key's position
        if (newPosition != Vector3.negativeInfinity) e.key.transform.position = newPosition;
    }

    private Vector3 GetRandomValidLocation(Vector3 currentLocation)
    {
        Vector3 invalidValue = Vector3.negativeInfinity;

        if (locations.Length == 0) return invalidValue;
        else if (locations.Length == 1) return locations[0].position;

        // index of random new location
        int index = Random.Range(0, locations.Length - 1);

        // random new location
        Vector3 newPosition = locations[index].position;

        // distance between position of the key and the new position
        float distance = Vector3.Distance(currentLocation, newPosition);

        // try another random location when the new location is too close to the current position
        if (distance < minDistance) {

            if (randomTryCount > maxRandomTries)
            {
                randomTryCount = 0;
                return invalidValue;
            }

            randomTryCount++;
            GetRandomValidLocation(currentLocation);
        }

        randomTryCount = 0;
        return newPosition;
    }
}

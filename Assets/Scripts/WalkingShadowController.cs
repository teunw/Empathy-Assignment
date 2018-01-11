using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingShadowController : EventHandler {

    public GameObject characterPrefab;
    public Transform startTransform;
    public Transform destinationTransform;
    public float speed = 5f;

    private GameObject character;
    private Vector3 startPosition;
    private Vector3 destination;

    public override void SubscribeEvents()
    {
        //throw new System.NotImplementedException();
    }

    public override void UnsubscribeEvents()
    {
        //throw new System.NotImplementedException();
    }

    public void Start()
    {
        if (startTransform) SetStartPosition(startTransform.position);
        if (destinationTransform) SetDestination(destinationTransform.position);

        SpawnWalkingShadow();
    }

    public void SpawnWalkingShadow()
    {
        character = Instantiate(characterPrefab, startPosition, Quaternion.identity);
        Renderer[] renderers = character.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }

        StartCoroutine(MoveToDestination());
    }

    public void SetStartPosition(Vector3 startPos)
    {
        startPosition = startPos;
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
    }

    public void SetStartAndDestination(Vector3 startPos, Vector3 dest)
    {
        SetStartPosition(startPos);
        SetDestination(dest);
    }

    IEnumerator MoveToDestination()
    {
        character.transform.LookAt(destination);
 
        while(Vector3.Distance(character.transform.position, destination) > 0.01f)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        Destroy(character);
    }
}

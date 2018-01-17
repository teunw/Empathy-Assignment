using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour {

    public int activate;
    public int deactivate;
    public GameObject thisObject;

    private Renderer renderer;

    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        StartCoroutine(ShowObject());

    }

    // Update is called once per frame
    void Update ()
    {
        renderer.enabled = true;
    }

    IEnumerator ShowObject()
    {
        renderer.enabled = false;
        yield return new WaitForSeconds(activate);
        renderer.enabled = true;
        yield return new WaitForSeconds(deactivate);
        renderer.enabled = false;
    }
}

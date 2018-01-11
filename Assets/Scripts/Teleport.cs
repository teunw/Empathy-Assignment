using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public string levelToLoad;
    public int wait;

	// Use this for initialization
	void Start () {
        StartCoroutine(TeleportAvailable());
	}
	
	// Update is called once per frame
	IEnumerator TeleportAvailable () {

        yield return new WaitForSeconds(wait);

        while(true)
        {
            //Debug.Log("teleport available now");
            if (Input.anyKey)
                Application.LoadLevel(levelToLoad);
            yield return null;
        }     
	}
}

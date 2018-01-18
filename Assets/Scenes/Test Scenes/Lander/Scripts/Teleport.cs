using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public string levelToLoad;
    public int wait;

	private bool canTeleport = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(TeleportAvailable());
	}

	public void SwitchScene()
	{
		Debug.Log ("TRIGGER PRESSED");

		if (canTeleport)
		{
			Application.LoadLevel(levelToLoad);
		}
	}

	public void ExitGame()
	{
		if (canTeleport)
		{
			Application.Quit();
		}
	}
	
	// Update is called once per frame
	IEnumerator TeleportAvailable () {

        yield return new WaitForSeconds(wait);
		canTeleport = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour {

    public AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
        

    }
	
	// Update is called once per frame
	IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(4);
        audio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotFade : MonoBehaviour {

    public Light lt;
    public int wait;
    private int angle = 0;

    // Use this for initialization
    void Start () {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        StartCoroutine(StartFade());
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator StartFade()
    {

        yield return new WaitForSeconds(wait);
        for(int angle = 0; angle < 243; angle++)
        {
            lt.spotAngle = angle / 3 * 2;
            angle++;
            yield return null;
        }
    }
}

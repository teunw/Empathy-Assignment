using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BlinkUtility : MonoBehaviour {

	private float defaultDuration = 1.0f;

	public void Blink(float duration)
	{
		VRTK_SDK_Bridge.HeadsetFade(Color.black, 0f, true);
		StartCoroutine(BlinkReset(duration));
	}

	public void BlinkDelayed(float delay)
	{
		StartCoroutine (BlinkDelayed (defaultDuration, delay));
	}

	private IEnumerator BlinkDelayed(float duration, float delay)
	{
		yield return new WaitForSeconds (delay);
		Blink (duration);
	}

	private IEnumerator BlinkReset(float dur)
	{
		yield return new WaitForSeconds(dur);
		VRTK_SDK_Bridge.HeadsetFade(Color.clear, 0f, true);
	}
}

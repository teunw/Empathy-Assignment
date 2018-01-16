using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BlinkUtility : MonoBehaviour {

	public void Blink(float duration)
	{
		VRTK_SDK_Bridge.HeadsetFade(Color.black, 0f, true);
		StartCoroutine(BlinkReset(duration));
	}

	private IEnumerator BlinkReset(float dur)
	{
		yield return new WaitForSeconds(dur);
		VRTK_SDK_Bridge.HeadsetFade(Color.clear, 0f, true);
	}
}

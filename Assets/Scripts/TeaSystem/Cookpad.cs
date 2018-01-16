using UnityEngine;

public class Cookpad : MonoBehaviour
{
	public CookerStatus CookerStatus;
	public Teapot Teapot;
	
	// Use this for initialization
	void Start ()
	{
		if (CookerStatus == null)
		{
			CookerStatus = gameObject.GetComponentInChildren<CookerStatus>();
			CookerStatus.Cookpad = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

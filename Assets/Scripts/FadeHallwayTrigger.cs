using UnityEngine;

public class FadeHallwayTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        var fade = GameObject.Find("Fade");
        fade.GetComponent<TopFadeScript>().ChangeHospitalRoom();
    }
}

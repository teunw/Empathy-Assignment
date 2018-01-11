using System;
using System.Collections;
using UnityEngine;

public class TopFadeScript : MonoBehaviour
{
    public Transform Home;
    private MiddleFadeScript _homeFadeScript;

    public Transform Hospital;
    private MiddleFadeScript _hospitalFadeScript;

    public Transform Hospital2;
    private MiddleFadeScript _hospital2FadeScript;

    public int SecondsToWait = 5;

    void Start()
    {
        if (Home == null || Hospital == null)
        {
            throw new NullReferenceException("null referecnce in the topfade script");
        }
        _homeFadeScript = Home.GetComponent<MiddleFadeScript>() ?? Home.gameObject.AddComponent<MiddleFadeScript>();
        _homeFadeScript.IsActive = true;
        _homeFadeScript.SetIsActive(Home);


        _hospitalFadeScript = Hospital.GetComponent<MiddleFadeScript>() ??
                              Hospital.gameObject.AddComponent<MiddleFadeScript>();
        _hospitalFadeScript.IsActive = false;
        _hospitalFadeScript.SetIsActive(Hospital);

        if (Hospital2 != null)
        {
            _hospital2FadeScript = Hospital2.GetComponent<MiddleFadeScript>() ??
                                    Hospital2.gameObject.AddComponent<MiddleFadeScript>();
            _hospital2FadeScript.IsActive = false;
            _hospital2FadeScript.SetIsActive(Hospital2);
        }

        StartCoroutine(Hold(SecondsToWait));
    }

    private IEnumerator Hold(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        CallHospital();
    }

    /// <summary>
    /// Changes the home to the hospital.
    /// </summary>
    void CallHospital()
    {
        if (_hospital2FadeScript != null)
        {
            _hospitalFadeScript.Set(false);
        }
        _homeFadeScript.Set(false);
        _hospitalFadeScript.Set(true);
    }

    /// <summary>
    /// Changes the hospital room to a different hospital room 
    /// when yo go to the hallway
    /// </summary>
    public void ChangeHospitalRoom()
    {
        _homeFadeScript.Set(false);
        _hospitalFadeScript.Set(false);
        _hospital2FadeScript.Set(true);
    }
}
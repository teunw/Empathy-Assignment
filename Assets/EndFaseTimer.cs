using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EndFaseTimer : EventHandler
{
	public string scene;
	public float duration = 30f;
	private float endTime = 0f;
	private bool isActive = false;
	private SceneChangerEmpathy _sceneChangerEmpathy;
	
	// Use this for initialization
	void Start ()
	{
		_sceneChangerEmpathy = FindObjectOfType<SceneChangerEmpathy>();
		_sceneChangerEmpathy.SetScene(scene);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive && Time.time >= endTime)
		{
			_sceneChangerEmpathy.ChangeToSceneAfter(0f);
		}
	}

	public override void SubscribeEvents()
	{
		EventManager.Instance.AddListener<EndFaseEvent>(StartTimer);
	}

	public override void UnsubscribeEvents()
	{
		EventManager.Instance.RemoveListener<EndFaseEvent>(StartTimer);
	}

	private void StartTimer(EndFaseEvent e)
	{
		isActive = true;
		endTime = Time.time + duration;
	}
}

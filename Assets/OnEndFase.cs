using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndFase : EventHandler {

	public override void SubscribeEvents()
	{
		EventManager.Instance.AddListener<EndFaseEvent>(DestroySelf);
	}

	public override void UnsubscribeEvents()
	{
		EventManager.Instance.AddListener<EndFaseEvent>(DestroySelf);
	}

	private void DestroySelf(EndFaseEvent e)
	{
		gameObject.SetActive(false);
		//Destroy(gameObject);
	}
}

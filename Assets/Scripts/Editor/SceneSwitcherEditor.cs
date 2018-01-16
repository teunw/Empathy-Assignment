using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneSwitcher))]
public class SceneSwitcherEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var switcher = target as SceneSwitcher;
		if (switcher == null) throw new Exception("SceneSwitcherEditor not attached to SceneSwitcher");
		
		if (GUILayout.Button("Switch scenes"))
		{
			switcher.Home.SetActive(!switcher.Home.activeSelf);
			switcher.Hospital.SetActive(!switcher.Hospital.activeSelf);
		}
	}
}

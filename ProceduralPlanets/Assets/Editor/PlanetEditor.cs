﻿using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
	private Planet planet;
	private Editor shapeEditor;
	private Editor colorEditor;

	public override void OnInspectorGUI()
	{
		using (var check = new EditorGUI.ChangeCheckScope())
		{
			base.OnInspectorGUI();
			if (check.changed)
			{
				planet.GeneratePlanet();
			}
		}

		if (GUILayout.Button("Generate Planet"))
		{
			planet.GeneratePlanet();
		}

		DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
		DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout, ref colorEditor);
	}

	private void DrawSettingsEditor(Object settings, Action onSettingsUpdated, ref bool foldout, ref Editor editor)
	{

		if (settings != null)
		{
			foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

			using (var check = new EditorGUI.ChangeCheckScope())
			{
				if (foldout)
				{
					CreateCachedEditor(settings, null, ref editor);
					editor.OnInspectorGUI();

					if (check.changed)
					{
						onSettingsUpdated?.Invoke();
					}
				}
			}
		}
	}
	
	private void OnEnable()
	{
		planet = (Planet) target;
	}
}

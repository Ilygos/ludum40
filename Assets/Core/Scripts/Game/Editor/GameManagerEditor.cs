﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor {
		
	public override void OnInspectorGUI() {
		// Grabbing the object this inspector is editing.
		GameManager gameManager = (GameManager)target;

		base.OnInspectorGUI();

		if (GUILayout.Button("New Game")) {
			gameManager.NewGame();
		}

		if (GUILayout.Button("Clean")) {
			gameManager.Clean();
		}

		if (GUILayout.Button("Go To Title Screen")) {
			gameManager.GoToTitleScene();
		}
	}

}

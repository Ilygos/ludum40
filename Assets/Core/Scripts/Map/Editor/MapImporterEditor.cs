using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapImporter))]
public class MapImporterEditor : Editor {

	public override void OnInspectorGUI() {
		MapImporter mapImporter = (MapImporter)target;

		base.OnInspectorGUI();

		if (GUILayout.Button("Import")) {
			mapImporter.Import();
		}
	}

}

using UnityEngine;

public class MouseCursorManager : MonoBehaviour {

	public Texture2D normalCursor;
	public Vector2 normalHotspot;

	void Start () {
		Cursor.SetCursor(normalCursor, normalHotspot, CursorMode.ForceSoftware);
	}

}

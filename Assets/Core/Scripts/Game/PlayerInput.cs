using UnityEngine;
using XboxCtrlrInput;

public class PlayerInput : MonoBehaviour {


    public int playerIndex = 1;

    [Header("button")]
    public string horizontalMove;
    public string verticalMove;
    public string fireButton;
    public string horizontalAim;
    public string verticalAim;
    public string dashInput;
    public string parryInput;
    public Color bulletColor;

	bool isWindow;
	bool isXboxPlugged;

	void Start() {
		isWindow = Application.platform == RuntimePlatform.WindowsPlayer;
		isXboxPlugged = isWindow ? XCI.IsPluggedIn(playerIndex) : false;
	}

	public Vector2 moveAxis
    {
        get { return new Vector2(Input.GetAxis(horizontalMove+ playerIndex), Input.GetAxis(verticalMove + playerIndex)); }
    }
    public Vector2 aimAxis
    {
        get {
			float xValue = isXboxPlugged ? -XCI.GetAxis(XboxAxis.RightStickX) : Input.GetAxis(horizontalAim + playerIndex);
			float yValue = isXboxPlugged ? XCI.GetAxis(XboxAxis.RightStickY) : Input.GetAxis(verticalAim + playerIndex);
            return new Vector2(xValue, yValue); }
    }
    public float fire
    {
        get
        {
			float xValue = isXboxPlugged ? XCI.GetAxis(XboxAxis.RightTrigger) : Input.GetAxis(fireButton + playerIndex);
            return xValue;
        }
    }
    public bool dash
    {
        get {
			bool xValue = isXboxPlugged ? XCI.GetButton(XboxButton.RightBumper) : Input.GetButton(dashInput + playerIndex);
            return xValue;
        }
    }

    public bool parry
    {
        get {
			float xValue = isXboxPlugged ? XCI.GetAxis(XboxAxis.LeftTrigger) : Input.GetAxis(parryInput + playerIndex);
            return xValue > 0.2; }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {


    public int playerIndex = 1;

    [Header("button")]
    public string horizontalMove;
    public string verticalMove;
    public string fireButton;
    public string horizontalAim;
    public string verticalAim;
    public Color color;

	public Vector2 moveAxis
    {
        get { return new Vector2(Input.GetAxis(horizontalMove+ playerIndex), Input.GetAxis(verticalMove + playerIndex)); }
    }
    public Vector2 aimAxis
    {
        get { return new Vector2(Input.GetAxis(horizontalAim + playerIndex), Input.GetAxis(verticalAim + playerIndex)); }
    }
    public float fire
    {
        get { return Input.GetAxis(fireButton + playerIndex); }
    } 
}

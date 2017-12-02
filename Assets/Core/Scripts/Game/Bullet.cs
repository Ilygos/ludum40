using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private int SPEED = 10;
    

    private Vector3 velocity;
    private object index;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void initialize(Vector3 pForwardSource, int playerId)
    {
        float lVelocityX = -pForwardSource.x * SPEED;
        float lVelocityY = -pForwardSource.z * SPEED;
        velocity = new Vector3(lVelocityX, 0,lVelocityY);
        GetComponent<Rigidbody>().velocity = velocity;
        index = playerId;
        var tr = GetComponent<TrailRenderer>();
    }
}

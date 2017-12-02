using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private int SPEED = 10;
    [SerializeField]
    private int MAX_BOUNCE = 3;

    [HideInInspector]
    public int bouncingLeft;


    private Vector3 velocity;
    private object index;



    // Use this for initialization
    void Start ()
    {
        bouncingLeft = MAX_BOUNCE;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), true);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            DestroyObject(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), false);
            bouncingLeft--;
            if (bouncingLeft <= 0) DestroyObject(gameObject);
        }
    }

    public void initialize(Vector3 pForwardSource, int playerId)
    {
        float lVelocityX = -pForwardSource.x * SPEED;
        float lVelocityY = -pForwardSource.z * SPEED;
        velocity = new Vector3(lVelocityX, 0,lVelocityY);
        transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
        GetComponent<Rigidbody>().velocity = velocity;
        index = playerId;
        var tr = GetComponent<TrailRenderer>();
    }
}

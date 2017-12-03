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
	private Rigidbody rbody;

    void Start ()
    {
		rbody = GetComponent<Rigidbody>();
        bouncingLeft = MAX_BOUNCE;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), true);
		rbody.velocity = transform.forward * SPEED;
	}
	
	void LateUpdate() {
		rbody.velocity = SPEED * rbody.velocity.normalized;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), false);
            bouncingLeft--;
            if (bouncingLeft <= 0) DestroyObject(gameObject);
        }
    }
}

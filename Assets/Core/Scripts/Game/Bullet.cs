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
	private Rigidbody rigidbody;

    void Start ()
    {
		rigidbody = GetComponent<Rigidbody>();
        bouncingLeft = MAX_BOUNCE;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), true);
		rigidbody.velocity = transform.forward * SPEED;
	}
	
	void LateUpdate() {
		rigidbody.velocity = SPEED * rigidbody.velocity.normalized;
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
}

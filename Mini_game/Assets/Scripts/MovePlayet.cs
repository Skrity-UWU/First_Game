using UnityEngine;

public class MovePlayet : MonoBehaviour
{
    public float speed;

    public float speed_rotation;

    public GameObject finish;

    private Rigidbody rigidbody;

    private int money;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rigidbody.velocity = transform.TransformDirection(new Vector3(v, rigidbody.velocity.y, -h));

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -speed_rotation, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, speed_rotation, 0);
        }

        if (money == 5)
        {
            Destroy(finish);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            Destroy(other.gameObject);
            money++;
        }
    }
}


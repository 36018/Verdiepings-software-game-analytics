using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class D3PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent tipping over
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z).normalized;
        Vector3 moveVelocity = move * speed;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}



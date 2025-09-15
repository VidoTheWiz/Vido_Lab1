using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;

    Rigidbody rb;
    bool isGrounded = true;

    public int hitCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevents tipping over
        PrintInstruction();
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move using the arrow keys or WASD!");
        Debug.Log("Press SPACE to jump!");
        Debug.Log("Don't bump into the objects!");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // Keep existing velocity, but update horizontal movement
        Vector3 velocity = new Vector3(xValue, 0f, zValue) * moveSpeed;
        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hitCount++;
        }
    }
}
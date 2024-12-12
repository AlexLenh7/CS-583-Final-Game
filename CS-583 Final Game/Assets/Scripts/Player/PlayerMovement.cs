using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -30f;
    public LayerMask groundLayer;
    public GameObject camera;
    public GameObject playerObj;

    private Vector3 velocity;
    private bool isGrounded;

    [Header("Audio")]
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip jumpSound; // Assign your jump audio clip in the Inspector

    void Update()
    {
        Movement();
        Jump();

        // Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }

    void Movement()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void Jump()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;

            // Play jump sound
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        transform.Translate(Vector3.up * velocity.y * Time.deltaTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * velocity.y * Time.fixedDeltaTime);
        Movement();
    }
}

using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float jumpForce = 10f;
   public float gravity = -30f;
   public LayerMask groundLayer;


   private Vector3 velocity;
   private bool isGrounded;


   void Update()
   {
       Movement();
       Jump();
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

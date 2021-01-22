using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;

    public float playerSpeed;
    public float gravity = -19.62f;
    public float groundDistance = 0.1f;
    public float jumpHeight = 2f; 

    public Transform groundCheck;

    public LayerMask groundMask;

    bool isGrounded = true;

    Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(true && velocity.y < 0)
        {
            playerSpeed = 8f;
            velocity.y = -2f;
        }
        
        else
        {
            playerSpeed = 4.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if ((x > 0) && (z > 0) || (x < 0) && (z < 0) || (x > 0) && (z < 0) || (x < 0) && (z > 0))
        {
            x = x / 2;
            z = z / 2;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private Animator animator;
    private float rotationY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * moveZ + transform.right * moveX).normalized * moveSpeed;

        Vector3 newPosition = rb.position + movement * Time.deltaTime;
        rb.MovePosition(newPosition);

        float speed = new Vector3(moveX, 0, moveZ).magnitude;
        animator.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            animator.SetBool("IsJumping", false);
        }
    }
}

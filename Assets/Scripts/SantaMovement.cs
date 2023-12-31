using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public float speed;
    private float move;
    public Animator animator;
    [SerializeField] private float jumpForce = 18f;
    private float gravityScaleValue = 8.0f;
    public bool isJumping;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = gravityScaleValue;
        Debug.Log("Jump Force on Start: " + jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", move);
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Use jump force
            isJumping = true;
        }

        animator.SetBool("IsLaunching", Input.GetMouseButton(0));
    }
    public void PopAnimation()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Santa_Popped"))
        {
            animator.SetBool("IsPopped", true);
            animator.SetBool("IsLaunching", false);
        }
    }

    public void ResetAnimations()
    {
        animator.SetBool("IsLaunching", false);
        animator.SetBool("IsPopped", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float speed;
    float move;
    [SerializeField]float jumpForce;
    [SerializeField] bool Isjumping;

    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        // move = Input.GetAxis("Horizontal");
        // rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if(Input.GetButtonDown("Jump")&& !Isjumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Isjumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Isjumping = true;
        }
    }
}

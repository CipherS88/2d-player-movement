using UnityEngine;

// anim down 
public class playerMovement : MonoBehaviour
{
    [Header("some d0g shit ")]
    private float xais;
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 8;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private bool facingRight = true;

    [Header("fixing the double tryToJump shit")]
    [SerializeField] private float groundDistance;
    [SerializeField] private bool isGround;
    [SerializeField] private LayerMask whatsTheLayer;

    private bool canJump = true;
    private bool canMove = true;

    // enable jump & movement from other scripts
    public void enableJumpMove(bool enable)
    {
        canJump = enable;
        canMove = enable;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        rb.gravityScale = 2;
        moveSpeed = 4.5f;
        jumpForce = 8.5f;
    }

    private void Update()
    {
        handleCollision();
        handleinput();
        horizontalmove();
        handleanimation();
        handleflip();
    }

    // ----------------- Animation -----------------
    private void handleanimation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetBool("isGround", isGround);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    // ----------------- Input -----------------
    private void handleinput()
    {
        xais = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            tryToJump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tryToATT();
            Debug.Log("mouse0 press");
        }

    }

    private void tryToATT()
    {
        if (isGround)
        {
            anim.SetTrigger("att");
            Debug.Log("att worked");
            //rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    private void tryToJump()
    {
        if (isGround && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // ----------------- Movement -----------------
    private void horizontalmove()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(xais * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    private void handleflip()
    {
        if (rb.linearVelocity.x > 0 && !facingRight ||
            rb.linearVelocity.x < 0 && facingRight)
        {
            flip();
        }
    }

    private void flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    // ----------------- Collision -----------------
    private void handleCollision()
    {
        isGround = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundDistance,
            whatsTheLayer
        );
    }

    // ----------------- Gizmos -----------------
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(
            transform.position,
            transform.position + new Vector3(0, -groundDistance)
        );
    }
}

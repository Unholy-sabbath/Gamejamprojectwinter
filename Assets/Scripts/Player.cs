using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public float Jumpforce = 10f;
    float Vm;
    public float speed = 10;
    public float climbspeed = 7f;
    public int curHealth;
    public int maxHealth;
    Rigidbody2D rb;
    private Vector2 moveInput, pointerInput;
    private Playercontroller playercontroller;
    public float groundCheckDistance = 100f;
    public LayerMask GroundLayer;
    private BoxCollider2D Pc;
    private bool isonLadder = false;
    private bool isclimbing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Awake()
{
    playercontroller = new Playercontroller();
}
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        Pc = GetComponent<BoxCollider2D>();
        playercontroller.Player.Move.performed += OnMove;
        playercontroller.Player.Move.canceled += OnMove;
        playercontroller.Player.Jump.performed += OnJump;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        Vm = Input.GetAxis("Vertical");
      Move();
      if (isonLadder)
      {
        Climb();
      }
      else
      {Move();}
    }
    
    private void Climb()
    {
        float Vm = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveInput.x * speed, Vm * climbspeed);

        rb.gravityScale = 0;

        if(Vm == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isonLadder = true;
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {
            isonLadder = false;
            rb.gravityScale = 1;
        }
    }
   public void OnMove(InputAction.CallbackContext context)
    {
    moveInput = context.ReadValue<Vector2>();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumpforce);
        }
    }
    private bool IsGrounded()
    {
        Collider2D collider = GetComponent<Collider2D>();
        Vector2 rayStart = (Vector2)transform.position - new Vector2(0, collider.bounds.extents.y);
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, groundCheckDistance, GroundLayer);
        return hit.collider != null;
    }
    private void Move()
    {
        Vector2 velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = velocity;
    }
    private void OnEnable()
    {
        playercontroller.Enable();
    }
    private void OnDisable()
    {
        playercontroller.Player.Move.performed -= OnMove;
        playercontroller.Player.Move.canceled -= OnMove;
        playercontroller.Player.Jump.performed -= OnJump;
        playercontroller.Disable();
    }
    void OnDrawGizmos()
    {
        Collider2D collider = GetComponent<Collider2D>();
        // For debugging: visualize the ground check ray in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawRay((Vector2)transform.position - new Vector2(0, collider.bounds.extents.y), Vector2.down * groundCheckDistance);
    }

}

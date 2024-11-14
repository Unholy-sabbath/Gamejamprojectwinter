using UnityEngine;
using UnityEngine.InputSystem;

public class Weaponmove : MonoBehaviour
{
    public Transform gunMove;
    public Transform GunDaddyrot;
    public float rotSpeed = 5f;

    public bool isRightfacing = false;
    private Playercontroller playercontroller;
    public Vector2 moveInput;
    public Transform Firepoint;
    public GameObject Bulletprefab;
    public float BulletSpeed = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playercontroller = new Playercontroller();
    }
    void Start()
    {
        playercontroller.Player.Move.performed += OnMoverPerformed;
        playercontroller.Player.Move.performed += OnMoverCanceled;
    }

    // Update is called once per frame
    void Update()
    {
        Playdir();
        Aim();
        if (playercontroller.Player.Fire.triggered)
        {
            Fire();
        }
        
    }
    void Fire()
    {
        GameObject Bullet = Instantiate(Bulletprefab, Firepoint.position, Firepoint.rotation);

        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
    
    if (rb != null)
    {
        rb.velocity = Firepoint.TransformDirection(Vector2.left) * BulletSpeed;
    }
}
    private void OnMoverPerformed(InputAction.CallbackContext context)
    {
    moveInput = context.ReadValue<Vector2>();
    }
    private void OnMoverCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }
    private void Playdir()
    {
        

        if (moveInput.x > 0)
        {
            isRightfacing = true;
        }
        else if (moveInput.x < 0)
        {
            isRightfacing = false;
        }
    }
    private void Aim()
    {
        Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mosPos - gunMove.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
if (!isRightfacing)
{
    angle += 180f;
}
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        gunMove.rotation = Quaternion.Lerp(gunMove.rotation, targetRotation, rotSpeed * Time.deltaTime);
        
    }

 private void OnEnable()
 {
    playercontroller.Enable();
 }

 private void OnDisable()
 {
    playercontroller.Player.Move.performed -= OnMoverPerformed;
    playercontroller.Player.Move.canceled -= OnMoverCanceled;
    playercontroller.Disable();
 }
}

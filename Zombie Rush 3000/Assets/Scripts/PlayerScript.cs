using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator animator;
    private float MovementSpeed = 4;
    private Vector2 lastMovement = Vector2.zero;
    [SerializeField] private float DashDistance = 8f;
    [SerializeField] private float DashDuration = 0.2f;
    private float DashSpeed;
    private bool isDashing;
    private float DashTime;
    private float DashCooldown = 3f;
    private float cooldownTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DashSpeed = DashDistance / DashDuration / 2;
        movement = new Vector2();
        lastMovement = Vector2.up;
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
        // Get WASD or arrow key input
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1f;
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1f;
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1f;
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1f;
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        movement = movement.normalized;
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            isDashing = true;
            DashTime = DashDuration;
            cooldownTimer = DashCooldown;
        }
        if (cooldownTimer >= 0)
        {
            Debug.Log(Mathf.CeilToInt(cooldownTimer));
        }
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            // Dash in current movement direction
            rb.MovePosition(rb.position + movement * DashSpeed * Time.fixedDeltaTime);
            DashTime -= Time.fixedDeltaTime;
            if (DashTime <= 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            // Player movement
            Vector2 offset = movement * MovementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + offset);

        }
        cam.transform.position = new Vector3(rb.position.x, rb.position.y, cam.transform.position.z);
    }
}
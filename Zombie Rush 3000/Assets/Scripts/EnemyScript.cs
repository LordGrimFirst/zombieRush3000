using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int MovementSpeed = 3;
    [SerializeField] private Rigidbody2D Player;
    public Rigidbody2D rb;

    
    // store background offset passed in from Background
    private Vector2 backgroundOffset = Vector2.zero;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 targetPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        // Enemy chases origin (0,0)
        Vector2 chaseMove = Vector2.MoveTowards(rb.position, targetPosition, MovementSpeed * Time.fixedDeltaTime);

        // Apply both chase movement + background offset
        Vector2 finalPosition = chaseMove;

        rb.MovePosition(finalPosition);

        // Reset offset (so it only applies once per frame)
        backgroundOffset = Vector2.zero;
    }
}

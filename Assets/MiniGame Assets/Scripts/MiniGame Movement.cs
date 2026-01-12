using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private float moveInput;
    public GameObject ObstacleSpawn;

    MiniGameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = MiniGameManager.instance;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Arrow_Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            ObstacleSpawn.SetActive(false);
            manager.TriggerGameOver();
            Destroy(gameObject);
        }
    }
}
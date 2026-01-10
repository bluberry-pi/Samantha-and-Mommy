using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private float moveInput;
    public GameObject ObstacleSpawn;

    GameObject gameOverUI;

    void Awake()
    {
        gameOverUI = FindInactiveByTag("MiniGameOver");

        if (!gameOverUI)
            Debug.LogError("❌ MiniGameOver object not found (even inactive)");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (gameOverUI)
                gameOverUI.SetActive(true);

            Destroy(gameObject);
        }
    }

    // Finds disabled OR enabled objects by tag
    GameObject FindInactiveByTag(string tag)
    {
        GameObject[] all = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in all)
        {
            if (obj.CompareTag(tag) && obj.hideFlags == HideFlags.None)
                return obj;
        }
        return null;
    }
}
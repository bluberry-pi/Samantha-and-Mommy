using UnityEngine;

public class TeddyPickup : MonoBehaviour
{
    public SpriteRenderer Teddy;
    public GameObject TeddyOnHand;

    public Collider2D clickCollider;

    bool playerNear = false;
    bool holdingTeddy = false;

    void Update()
    {
        if (!holdingTeddy && playerNear && Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (clickCollider.OverlapPoint(mouseWorld))
            {
                Teddy.enabled = false;          // hide sprite
                TeddyOnHand.SetActive(true);
                holdingTeddy = true;
            }
        }

        if (holdingTeddy && playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Teddy.enabled = true;               // show sprite
            TeddyOnHand.SetActive(false);
            holdingTeddy = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNear = false;
    }
}
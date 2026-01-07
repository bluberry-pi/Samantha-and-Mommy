using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit && hit.transform == transform)
            {
                offset = transform.position - (Vector3)mouseWorld;
                dragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseWorld + (Vector2)offset;
        }
    }
}
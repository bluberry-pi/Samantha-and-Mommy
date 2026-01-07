using UnityEngine;

public class WindowClose : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.CompareTag("Close"))
            {
                // Destroy the parent window (not the button itself)
                Transform window = hit.collider.transform.parent;

                if (window != null)
                {
                    Destroy(window.gameObject);
                }
            }
        }
    }
}
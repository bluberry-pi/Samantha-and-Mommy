using UnityEngine;

public class WindowRotation : MonoBehaviour
{
    int step = 0; // 0=0°, 1=-90°, 2=-180°, 3=-270°
    [HideInInspector] public bool vertical = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.CompareTag("Rotate"))
            {
                RotateWindow(hit.collider.transform.parent);
            }
        }
    }

    void RotateWindow(Transform window)
    {
        if (window == null)
        {
            return;
        }

        step++;

        if (step > 3)
        {
            step = 0;
            vertical = false;
        }

        float targetZ = 0f;

        if (step == 1)
        {
            targetZ = -90f;
            vertical = true;

        }
        else if (step == 2)
        {
            targetZ = -180f;
            vertical = false;
        }
        else if (step == 3)
        {
            targetZ = -270f;
            vertical = false;
        }

        window.localRotation = Quaternion.Euler(0f, 0f, targetZ);
    }
}
using UnityEngine;

public class WindowFocus : MonoBehaviour
{
    void OnMouseDown()
    {
        WindowLayerManager.Instance.BringToFront(gameObject);
    }
}
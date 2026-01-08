using UnityEngine;

public class WindowLayerManager : MonoBehaviour
{
    public static WindowLayerManager Instance;

    int topOrder = 20;
    GameObject currentTop;

    void Awake()
    {
        Instance = this;
    }

    public void BringToFront(GameObject window)
    {
        // Already on top? Do nothing.
        if (currentTop == window)
            return;

        currentTop = window;

        // Reserve 2 layers per window
        topOrder += 2;

        int windowLayer = topOrder;
        int childLayer  = topOrder + 1;

        // Parent
        SpriteRenderer parent = window.GetComponent<SpriteRenderer>();
        if (parent)
            parent.sortingOrder = windowLayer;

        // Optional Canvas
        Canvas c = window.GetComponentInChildren<Canvas>(true);
        if (c)
        {
            c.overrideSorting = true;
            c.sortingOrder = windowLayer;
        }

        // Children
        SpriteRenderer[] sprites = window.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var r in sprites)
        {
            if (r.gameObject != window)
                r.sortingOrder = childLayer;
        }
    }
}
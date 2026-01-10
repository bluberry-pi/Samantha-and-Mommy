using UnityEngine;

public class WindowPictureSpawner : MonoBehaviour
{
    public Collider2D clickZone;
    public GameObject picturePrefab;

    GameObject currentPicture;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit == clickZone)
            {
                TrySpawn();
            }
        }
    }

    void TrySpawn()
    {
        if (currentPicture == null)
        {
            currentPicture = Instantiate(picturePrefab);
            WindowLayerManager.Instance.BringToFront(currentPicture);
        }
        else
        {
            WindowLayerManager.Instance.BringToFront(currentPicture);
        }
    }
}
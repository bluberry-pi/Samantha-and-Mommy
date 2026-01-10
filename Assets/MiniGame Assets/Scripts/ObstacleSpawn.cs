using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject Obstacle;
    public Transform obstacleParent;   // <-- Parent holder

    public float spawnRate = 2f;
    private float timer = 0f;
    public float widthOffset;

    void Update()
    {
        if (timer <= spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnObstacle();
            timer = 0;
        }
    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.x - widthOffset;
        float highestPoint = transform.position.x + widthOffset;

        Vector3 spawnPos = new Vector3(
            Random.Range(lowestPoint, highestPoint),
            transform.position.y,
            0f
        );

        // Spawn AS CHILD
        Instantiate(Obstacle, spawnPos, transform.rotation, obstacleParent);
    }
}
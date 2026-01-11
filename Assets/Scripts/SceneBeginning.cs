using UnityEngine;

public class SceneBeginning : MonoBehaviour
{
    public static bool CutsceneActive = false;
    public GameObject momGonePrefab;
    public GameObject playGamesPrefab;
    public GameObject leftPrefab;
    public GameObject rightPrefab;
    public GameObject left1;
    public GameObject right1;

    public float Timer = 1.5f;

    float timer = 0f;
    int stage = 0;

    GameObject momGone;
    GameObject playGames;
    GameObject left;
    GameObject right;

    void Start()
    {
        momGone = Instantiate(momGonePrefab, transform);
        stage = 1;
    }

    void Update()
    {
        if (stage == 1 || stage == 2)
            timer += Time.deltaTime;

        if (stage == 1 && timer >= Timer)
        {
            Destroy(momGone);
            playGames = Instantiate(playGamesPrefab, transform);
            timer = 0f;
            stage = 2;
        }

        if (stage == 2 && timer >= Timer)
        {
            Destroy(playGames);
            left = Instantiate(leftPrefab, transform);
            right = Instantiate(rightPrefab, transform);
            stage = 3;
        }

        if (stage == 3)
        {
            if (Input.GetKeyDown(KeyCode.C) && left != null)
            {
                Destroy(left);
                if (left1 != null) Destroy(left1);
            }

            if (Input.GetKeyDown(KeyCode.V) && right != null)
            {
                Destroy(right);
                if (right1 != null) Destroy(right1);
            }

            if (left == null && right == null)
                stage = 4;
        }

        if (stage == 4)
            Destroy(gameObject);
    }
}
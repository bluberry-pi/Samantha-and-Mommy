using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;

    public GameObject gameOverUI;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        gameOverUI.SetActive(false);   // Always hidden on start
    }

    public void TriggerGameOver()
    {
        gameOverUI.SetActive(true);
    }
}
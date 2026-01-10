using UnityEngine;

public class OnMiniGameRestart : MonoBehaviour
{
    [Header("MiniGame")]
    public GameObject miniGamePrefab;
    public Transform miniGameParent;

    [Header("UI")]
    public GameObject gameOverUI;

    bool hasSpawned = false;

    void Start()
    {
        // Only allow initial spawn ONCE per scene load
        if (!hasSpawned)
        {
            hasSpawned = true;
            SpawnNew();
        }
    }

    public void OnRestartPress()
    {
        // Hide Game Over UI
        if (gameOverUI)
            gameOverUI.SetActive(false);

        // Destroy current minigame if one exists
        GameObject old = GameObject.FindGameObjectWithTag("MiniGame");
        if (old)
            Destroy(old);

        // Small delay so Unity fully clears old objects
        Invoke(nameof(SpawnNew), 0.05f);
    }

    void SpawnNew()
    {
        // 🛑 EXTRA SAFETY:
        // Prevents ANY double-spawn if Unity tries something weird
        if (GameObject.FindGameObjectWithTag("MiniGame"))
        {
            Debug.Log("⚠️ MiniGame already exists — spawn blocked");
            return;
        }

        GameObject currentInstance = Instantiate(miniGamePrefab, miniGameParent);
        currentInstance.transform.localPosition = Vector3.zero;
        currentInstance.transform.localRotation = Quaternion.identity;
        currentInstance.transform.localScale = Vector3.one;

        Debug.Log("🎮 New MiniGame spawned safely");
    }
}
using UnityEngine;
using System.Collections;

public class OnMiniGameRestart : MonoBehaviour
{
    [Header("MiniGame")]
    public GameObject miniGamePrefab;
    public Transform miniGameParent;

    [Header("UI")]
    public GameObject gameOverUI;

    private bool isRestarting = false;

    public void OnRestartPress()
    {
        if (isRestarting) return;
        isRestarting = true;

        // IMPORTANT: start coroutine while object is still active
        StartCoroutine(RestartRoutine());
    }

    IEnumerator RestartRoutine()
    {
        // Hide Game Over UI AFTER coroutine has started
        if (gameOverUI)
            gameOverUI.SetActive(false);

        // Destroy ALL existing minigames
        GameObject[] existing = GameObject.FindGameObjectsWithTag("MiniGame");
        foreach (GameObject g in existing)
            Destroy(g);

        // Wait one frame so Unity actually destroys them
        yield return null;

        // Spawn EXACTLY one minigame
        GameObject current = Instantiate(
            miniGamePrefab,
            miniGameParent,
            false
        );

        // Reset local transform
        current.transform.localPosition = Vector3.zero;
        current.transform.localRotation = Quaternion.identity;
        current.transform.localScale = Vector3.one;

        isRestarting = false;
    }
}
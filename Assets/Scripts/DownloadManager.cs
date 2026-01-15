using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DownloadManager : MonoBehaviour
{
    public Slider downloadSlider;
    public TextMeshProUGUI speedText;

    public float firstHalfSpeed = 5f;
    public float secondHalfSpeed = 0.5f;

    [HideInInspector] public float shakeBoost = 0f;

    [Header("Eye Closed Bonus")]
    public float eyeClosedBonus = 5f;     // how much speed eyes give
    [HideInInspector] public float eyeBonus = 0f;

    float currentProgress = 0f;
    bool completed = false;

    public static event Action OnDownloadComplete;
    public static bool DownloadFinished = false;

    // FIX: Only reset on first Start, not every time it's enabled
    void Start()
    {
        // Only reset if not already completed
        if (!DownloadFinished)
        {
            completed = false;
            currentProgress = 0f;

            if (downloadSlider)
                downloadSlider.value = 0f;
        }
        else
        {
            // If already finished, show completed state
            completed = true;
            currentProgress = 1f;
            if (downloadSlider) downloadSlider.value = 1f;
            if (speedText) speedText.text = "Download Complete";
        }
    }

    // FIX: Update UI when re-enabled to show current progress
    void OnEnable()
    {
        if (downloadSlider)
            downloadSlider.value = currentProgress;
        
        if (speedText && completed)
            speedText.text = "Download Complete";
    }

    void Update()
    {
        if (completed) return;

        if (currentProgress >= 1f)
        {
            FinishDownload();
            return;
        }

        float currentSpeed = (currentProgress < 0.10f) ? firstHalfSpeed : secondHalfSpeed;

        // 👇 real final speed (shake + eye bonus)
        float finalSpeed = currentSpeed + shakeBoost + eyeBonus;

        currentProgress += finalSpeed * Time.deltaTime / 100f;

        if (downloadSlider) downloadSlider.value = currentProgress;
        if (speedText) speedText.text = finalSpeed.ToString("F2") + " kb/s";
    }

    void FinishDownload()
    {
        completed = true;
        DownloadFinished = true;
        currentProgress = 1f;

        if (downloadSlider) downloadSlider.value = 1f;
        if (speedText) speedText.text = "Download Complete";

        Debug.Log("🔥 DOWNLOAD COMPLETE");
        OnDownloadComplete?.Invoke();
    }

    // FIX: Add method to manually reset if needed (e.g., new game)
    public void ResetDownload()
    {
        DownloadFinished = false;
        completed = false;
        currentProgress = 0f;

        if (downloadSlider)
            downloadSlider.value = 0f;
        if (speedText)
            speedText.text = "0.00 kb/s";
    }
}
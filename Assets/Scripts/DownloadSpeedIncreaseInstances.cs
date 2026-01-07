using UnityEngine;

public class DownloadSpeedIncreaseInstances : MonoBehaviour
{
    public DownloadManager downloadManager;
    public WindowRotation windowRotation;
    public float minShakeSpeed = 2f;
    public float buildSpeed = 1.4f;
    public float decaySpeed = 0.8f;

    float lastY;
    float boost = 0f;

    void Start()
    {
        lastY = transform.position.y;
    }

    void Update()
    {
        if (windowRotation.vertical)
        {
            HandleShaking();
        }
    }

    void HandleShaking()
    {
        float currentY = transform.position.y;
        float ySpeed = Mathf.Abs(currentY - lastY) / Mathf.Max(Time.deltaTime, 0.0001f);
        lastY = currentY;

        if (ySpeed > minShakeSpeed)
        {
            float finalSpeed = downloadManager.secondHalfSpeed + boost;
            float remaining = 2f - finalSpeed;
            float resistance = Mathf.Clamp01(remaining / 2f);

            boost += (ySpeed * 0.02f) * buildSpeed * resistance;
        }
        else
        {
            boost -= Time.deltaTime * decaySpeed;
        }

        boost = Mathf.Max(0f, boost);
        downloadManager.shakeBoost = boost;
    }
}
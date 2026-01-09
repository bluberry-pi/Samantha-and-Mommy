using UnityEngine;
using TMPro;

public class MiniGameLogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (scoreText == null)
            Debug.LogError("❌ scoreText NOT assigned in inspector!");
        else
            Debug.Log("✅ Score text linked");
    }

    public void addScore(int scoreToAdd)
    {
        Debug.Log("➕ addScore called with " + scoreToAdd);

        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        Debug.Log("🏆 New Score = " + playerScore);
    }
}
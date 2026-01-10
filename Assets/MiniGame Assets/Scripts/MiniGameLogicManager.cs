using UnityEngine;
using TMPro;

public class MiniGameLogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
}
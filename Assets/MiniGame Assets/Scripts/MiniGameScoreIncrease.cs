using UnityEngine;

public class MiniGameScoreIncrease : MonoBehaviour
{
    public MiniGameLogicManager logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("MiniGameLogic").GetComponent<MiniGameLogicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MiniPlayer"))
        {
            logic.addScore(1);
        }
    }
}
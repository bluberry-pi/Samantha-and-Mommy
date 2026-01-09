using UnityEngine;
public class MomRandom : MonoBehaviour
{
    [Header("Mom Random Brain")]
    public bool enabledRandom = true;
    public float minCalmTime = 6f;
    public float maxCalmTime = 14f;
    public float randomFillSpeed = 2f;
    public float randomDrainSpeed = 1f;
    
    public enum MomState { Calm, Filling, Draining }
    public MomState CurrentState { get; private set; } = MomState.Calm;
    
    float timer;
    
    void Start()
    {
        CurrentState = MomState.Calm;
        timer = Random.Range(minCalmTime, maxCalmTime);
        Debug.Log($"[MomRandom] Started in Calm state, timer: {timer}s");
    }
    
    void Update()
    {
        if (!enabledRandom) return;
        
        timer -= Time.deltaTime;
        
        if (timer <= 0f)
        {
            if (CurrentState == MomState.Calm)
            {
                CurrentState = MomState.Filling;
                Debug.Log("[MomRandom] STATE → Filling (going to max)");
            }
            else if (CurrentState == MomState.Draining)
            {
                CurrentState = MomState.Calm;
                timer = Random.Range(minCalmTime, maxCalmTime);
                Debug.Log($"[MomRandom] STATE → Calm, next trigger in {timer}s");
            }
        }
    }
    
    public void NotifyReachedMax()
    {
        if (CurrentState == MomState.Filling)
        {
            CurrentState = MomState.Draining;
            Debug.Log("[MomRandom] STATE → Draining (going back to 0)");
        }
    }
    
    public void NotifyReachedZero()
    {
        if (CurrentState == MomState.Draining)
        {
            CurrentState = MomState.Calm;
            timer = Random.Range(minCalmTime, maxCalmTime);
            Debug.Log($"[MomRandom] STATE → Calm, next trigger in {timer}s");
        }
    }
}
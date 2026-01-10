using UnityEngine;

public class GameOverConditions : MonoBehaviour
{
    public SleepAnimTrig sleep;
    public EyesScript eyes;

    public bool PlayerIsSafe()
    {
        if (TurnPcOn.PcIsOn)
        {
            return false;
        }
        else if (!sleep.sleeping || !eyes.leftEye.activeSelf || !eyes.rightEye.activeSelf)
        {
            Debug.Log("// why are u awake samantha");
            return false;
        }
        return true;
    }
}

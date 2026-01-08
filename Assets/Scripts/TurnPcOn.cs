using UnityEngine;
public class TurnPcOn : MonoBehaviour
{
    public GameObject OnButton;
    public GameObject PcLight;
    public GameObject PcScreen;
    bool enteredOnce = false;
    bool turnedPc = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PcLight.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                if (enteredOnce && turnedPc)
                {
                    PcScreen.SetActive(true);
                }else {
                    OnButton.SetActive(true);
                }
            }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enteredOnce = true;
            OnButton.SetActive(false);
            PcScreen.SetActive(false);
        }
    }

    public void OnButtonPress()
    {
        Debug.Log("pc is on!");
        PcLight.SetActive(true);
        PcScreen.SetActive(true);
        turnedPc = true;
    }
}
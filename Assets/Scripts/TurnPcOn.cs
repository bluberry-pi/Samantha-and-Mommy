using UnityEngine;
public class TurnPcOn : MonoBehaviour
{
    public GameObject OnButton;
    public GameObject PcLight;
    public GameObject PcScreen;

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
            OnButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnButton.SetActive(false);
            PcScreen.SetActive(false);
        }
    }

    public void OnButtonPress()
    {
        Debug.Log("pc is on!");
        PcLight.SetActive(true);
        PcScreen.SetActive(true);
    }
}
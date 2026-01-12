using UnityEngine;

public class TurnPcOn : MonoBehaviour
{
    public GameObject OnButton;
    public GameObject PcLight;
    public GameObject PcScreen;

    // These can still be static if other scripts need to read them
    public static bool pcPowered;
    public static bool PcIsOn;

    bool enteredOnce;
    bool turnedPc;

    // 🔥 This runs even before Start – perfect place to reset statics
    void Awake()
    {
        pcPowered = false;
        PcIsOn = false;
    }

    void Start()
    {
        // Reset internal state every run
        enteredOnce = false;
        turnedPc = false;

        PcLight.SetActive(false);
        PcScreen.SetActive(false);
        OnButton.SetActive(false);
    }

    void Update()
    {
        PcIsOn = PcLight.activeSelf;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // If teddy is blocking the PC
        if (TeddyPickup.teddyOnPc)
        {
            OnButton.SetActive(false);
            PcScreen.SetActive(false);
            return;
        }

        // Show correct UI depending on PC state
        if (turnedPc)
            PcScreen.SetActive(true);
        else
            OnButton.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        enteredOnce = true;
        OnButton.SetActive(false);
        PcScreen.SetActive(false);
    }

    public void OnButtonPress()
    {
        if (TeddyPickup.teddyOnPc) return;

        PcLight.SetActive(true);
        PcScreen.SetActive(true);
        pcPowered = true;
        turnedPc = true;
    }
}
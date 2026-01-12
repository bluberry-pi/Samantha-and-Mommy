using UnityEngine;

public class TeddyPickup : MonoBehaviour
{
    public SpriteRenderer Teddy;
    public GameObject TeddyOnHand;
    public GameObject TeddyOnPc;
    public GameObject pcLight;

    public Collider2D bedZone;
    public Collider2D desktopZone;
    public static bool teddyOnPc;
    public GameObject eToPickup;

    bool playerNearBed;
    bool playerNearDesktop;
    bool holdingTeddy;

    Collider2D playerCol;

    // 🔥 Reset ALL static + internal states on reload
    void Awake()
    {
        teddyOnPc = false;
        holdingTeddy = false;
    }

    void Start()
    {
        playerCol = GetComponent<Collider2D>();

        // Visual hard reset
        Teddy.enabled = true;
        TeddyOnHand.SetActive(false);
        TeddyOnPc.SetActive(false);
    }

    void Update()
    {
        pcLight.SetActive(TurnPcOn.pcPowered && !teddyOnPc);

        playerNearBed = bedZone.IsTouching(playerCol);
        playerNearDesktop = desktopZone.IsTouching(playerCol);

        eToPickup.SetActive(playerNearBed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            // PICK FROM BED
            if (!holdingTeddy && playerNearBed && Teddy.enabled)
            {
                Teddy.enabled = false;
                TeddyOnHand.SetActive(true);
                TeddyOnPc.SetActive(false);
                holdingTeddy = true;
            }
            // DROP ON BED
            else if (holdingTeddy && playerNearBed)
            {
                Teddy.enabled = true;
                TeddyOnHand.SetActive(false);
                TeddyOnPc.SetActive(false);
                holdingTeddy = false;
            }
            // PUT ON PC
            else if (holdingTeddy && playerNearDesktop && !TeddyOnPc.activeSelf)
            {
                Teddy.enabled = false;
                TeddyOnHand.SetActive(false);
                TeddyOnPc.SetActive(true);
                holdingTeddy = false;
                teddyOnPc = true;
            }
            // TAKE FROM PC
            else if (!holdingTeddy && playerNearDesktop && TeddyOnPc.activeSelf)
            {
                Teddy.enabled = false;
                TeddyOnHand.SetActive(true);
                TeddyOnPc.SetActive(false);
                holdingTeddy = true;
                teddyOnPc = false;
            }
        }
    }
}
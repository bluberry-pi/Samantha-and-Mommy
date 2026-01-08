using UnityEngine;
using System.Collections;

public class SleepAnimTrig : MonoBehaviour
{
    public GameObject sleepAnimation;
    public GameObject wakeupAnimation;
    public GameObject player;

    bool nearBed = false;
    bool sleeping = false;
    bool busy = false;

    GameObject sleepAnim;
    GameObject wakeAnim;

    SpriteRenderer playerSprite;
    Collider2D playerCollider;

    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerCollider = player.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F PRESSED | sleeping=" + sleeping + " | nearBed=" + nearBed + " | busy=" + busy);

            if (busy) return;

            if (!sleeping && nearBed)
                StartCoroutine(Sleep());
            else if (sleeping)
                StartCoroutine(WakeUp());
        }
    }

    IEnumerator Sleep()
    {
        busy = true;
        Debug.Log(">>> SLEEP START");

        // Hide player but do NOT deactivate him
        playerSprite.enabled = false;
        playerCollider.enabled = false;

        sleepAnim = Instantiate(sleepAnimation);
        sleeping = true;

        yield return new WaitForSeconds(0.1f);

        Debug.Log(">>> SLEEP COMPLETE");
        busy = false;
    }

    IEnumerator WakeUp()
    {
        busy = true;
        Debug.Log(">>> WAKE START");

        if (sleepAnim) Destroy(sleepAnim);

        wakeAnim = Instantiate(wakeupAnimation);
        Animator anim = wakeAnim.GetComponent<Animator>();

        yield return null; // wait one frame for animator to init

        float length = anim.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("Wake anim length = " + length);

        yield return new WaitForSeconds(length);

        Destroy(wakeAnim);

        // Restore player
        playerSprite.enabled = true;
        playerCollider.enabled = true;

        sleeping = false;
        busy = false;
        Debug.Log(">>> WAKE COMPLETE");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            nearBed = true;
            Debug.Log("Player entered Bed");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            nearBed = false;
            Debug.Log("Player left Bed");
        }
    }

}
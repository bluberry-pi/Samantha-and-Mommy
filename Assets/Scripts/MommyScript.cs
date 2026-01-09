using System.Collections;
using UnityEngine;

public class MommyScript : MonoBehaviour
{
    public Rigidbody2D mommy;
    public float speed = 5f;
    public float speedAfter = 10f;
    public float stopAfter = 1f;
    public MomSlider momSlider;

    Vector2 direction = Vector2.right;
    bool isMoving = false;

    bool lastAngryState = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            StartMove();

        if (momSlider.momAngry && !lastAngryState)
            StartMove();

        lastAngryState = momSlider.momAngry;
    }
    void StartMove()
    {
        mommy.linearVelocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(RushAndStop());
    }

    IEnumerator RushAndStop()
    {
        mommy.linearVelocity = direction * speedAfter;
        yield return new WaitForSeconds(stopAfter);
        mommy.linearVelocity = Vector2.zero;
        isMoving = false;
    }
}
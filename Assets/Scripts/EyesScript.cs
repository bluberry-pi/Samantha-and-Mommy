using UnityEngine;

public class EyesScript : MonoBehaviour
{
    public GameObject leftEye;
    public GameObject rightEye;

    public GameObject blockWhileExists;

    bool leftClosed = false;
    bool rightClosed = false;

    SpriteRenderer leftSR;
    SpriteRenderer rightSR;
    public GameObject peekObject;


    void Start()
    {
        leftEye.SetActive(false);
        rightEye.SetActive(false);

        leftSR = leftEye.GetComponent<SpriteRenderer>();
        rightSR = rightEye.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (blockWhileExists && blockWhileExists.activeInHierarchy)
            return;

        if (Input.GetKeyDown(KeyCode.C))
        {
            leftClosed = !leftClosed;
            leftEye.SetActive(leftClosed);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            rightClosed = !rightClosed;
            rightEye.SetActive(rightClosed);
        }

        Peek();
    }


    void Peek()
    {
        // Only allow peeking when BOTH eyes are closed
        if (!leftClosed || !rightClosed)
        {
            SetEyeOpacity(1f);
            if (peekObject) peekObject.SetActive(false);
            return;
        }

        // Both eyes closed = show peek object
        if (peekObject) peekObject.SetActive(true);

        if (Input.GetKey(KeyCode.P))
        {
            SetEyeOpacity(0.7f);
        }
        else
        {
            SetEyeOpacity(1f);
        }
    }


    void SetEyeOpacity(float alpha)
    {
        if (leftSR)
        {
            Color c = leftSR.color;
            c.a = alpha;
            leftSR.color = c;
        }

        if (rightSR)
        {
            Color c = rightSR.color;
            c.a = alpha;
            rightSR.color = c;
        }
    }
}
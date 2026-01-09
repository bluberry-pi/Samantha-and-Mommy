using UnityEngine;
using UnityEngine.UI;

public class MomSlider : MonoBehaviour
{
    public Slider momSlider;
    public PlayerMovement playerMovement;
    public WindowRotation windowRotation;

    public float increaseRate = 0.5f;
    public float decreaseRate = 1f;
    public float maxSliderValue = 100f;

    public Transform shakyWindow;
    public string shakyWindowTag = "UpdateWindow";
    public float minShakeIntensity = 0.5f;
    public float shakeIncreaseRate = 5f;
    public float shakeDecayRate = 0.2f;

    public MomRandom momRandom;
    public bool momAngry = false;

    float current;
    float lastY;
    float lastVel;
    bool shaking;

    void Start()
    {
        momSlider.maxValue = maxSliderValue;
        momSlider.value = 0f;
    }

    void Update()
    {
        FindWindow();

        if (momRandom && momRandom.CurrentState == MomRandom.MomState.Filling)
        {
            current += momRandom.randomFillSpeed * Time.deltaTime;
            if (current >= maxSliderValue)
            {
                current = maxSliderValue;
                momRandom.NotifyReachedMax();
            }
        }
        else if (momRandom && momRandom.CurrentState == MomRandom.MomState.Draining)
        {
            current -= momRandom.randomDrainSpeed * Time.deltaTime;
            if (current <= 0f)
            {
                current = 0f;
                momRandom.NotifyReachedZero();
            }
        }
        else
        {
            HandleWalk();
            HandleShake();
        }

        current = Mathf.Clamp(current, 0f, maxSliderValue);
        momSlider.value = current;
        momAngry = current >= maxSliderValue;
    }

    void HandleWalk()
    {
        if (playerMovement.GetMovement().magnitude > 0.01f)
            current += increaseRate * Time.deltaTime;
        else if (!shaking)
            current -= decreaseRate * Time.deltaTime;
        else
            current -= shakeDecayRate * Time.deltaTime;
    }

    void HandleShake()
    {
        if (!windowRotation || !windowRotation.vertical || !shakyWindow) return;

        float y = shakyWindow.position.y;
        float vel = (y - lastY) / Time.deltaTime;
        float delta = Mathf.Abs(vel - lastVel);
        lastY = y;
        lastVel = vel;

        shaking = delta > minShakeIntensity;

        if (shaking)
            current += delta * shakeIncreaseRate * Time.deltaTime;
    }

    void FindWindow()
    {
        if (shakyWindow) return;
        GameObject w = GameObject.FindGameObjectWithTag(shakyWindowTag);
        if (w) shakyWindow = w.transform;
    }
}
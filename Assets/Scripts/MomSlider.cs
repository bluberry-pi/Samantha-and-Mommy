using UnityEngine;
using UnityEngine.UI;
public class MomSlider : MonoBehaviour
{
    public Slider momSlider;
    public PlayerMovement playerMovement;
    [Header("Slider Settings")]
    public float increaseRate = 0.5f;
    public float decreaseRate = 1f;
    public float maxSliderValue = 100f;
    [Header("Shake Detection")]
    public Transform shakyWindow;
    public string shakyWindowTag = "UpdateWIndow";
    public float minShakeIntensity = 0.5f;
    public float shakeIncreaseRate = 5f;
    public float shakeDecayRate = 0.2f;
    public bool momAngry = false;
    float currentSliderValue = 0f;
    float lastY;
    float lastVelocity;
    bool isCurrentlyShaking = false;
    public WindowRotation windowRotation;
    void Start()
    {
        momSlider.maxValue = maxSliderValue;
        momSlider.value = 0f;
    }
    void Update()
    {
        // Try to find the window if not assigned
        if (shakyWindow == null)
        {
            GameObject foundWindow = GameObject.FindGameObjectWithTag(shakyWindowTag);
            if (foundWindow != null)
            {
                shakyWindow = foundWindow.transform;
                lastY = shakyWindow.position.y;
                lastVelocity = 0f;
                Debug.Log("Found shaky window: " + shakyWindow.name);
                
                if (windowRotation == null)
                {
                    // Try to find in children first
                    windowRotation = foundWindow.GetComponentInChildren<WindowRotation>();
                    
                    // If not in children, try on the parent object itself
                    if (windowRotation == null)
                    {
                        windowRotation = foundWindow.GetComponent<WindowRotation>();
                    }
                    
                    if (windowRotation != null)
                    {
                        Debug.Log("Found WindowRotation component");
                    }
                    else
                    {
                        Debug.LogWarning("WindowRotation component not found on UpdateWindow!");
                    }
                }
            }
        }
        
        CheckWalkingCondition();
        
        // Check if windowRotation exists before accessing it
        if (windowRotation != null && windowRotation.vertical)
        {
            CheckShakeCondition();
        }
        
        momSlider.value = currentSliderValue;
        if (momSlider.value >= maxSliderValue)
            momAngry = true;
            Debug.Log("Mom is coming...");
    }
    void CheckWalkingCondition()
    {
        bool isPlayerMoving = playerMovement.GetMovement().magnitude > 0.01f;
        
        if (isPlayerMoving)
            currentSliderValue += increaseRate * Time.deltaTime;
        else if (!isCurrentlyShaking)
            currentSliderValue -= decreaseRate * Time.deltaTime;
        else
            currentSliderValue -= shakeDecayRate * Time.deltaTime;
            
        currentSliderValue = Mathf.Clamp(currentSliderValue, 0f, maxSliderValue);
    }
    void CheckShakeCondition()
    {
        if (!shakyWindow) return;
        
        float currentY = shakyWindow.position.y;
        float deltaY = currentY - lastY;
        float currentVelocity = deltaY / Time.deltaTime;
        float velocityChange = Mathf.Abs(currentVelocity - lastVelocity);
        
        lastY = currentY;
        lastVelocity = currentVelocity;
        
        if (velocityChange > minShakeIntensity)
        {
            isCurrentlyShaking = true;
            currentSliderValue += velocityChange * shakeIncreaseRate * Time.deltaTime;
            currentSliderValue = Mathf.Clamp(currentSliderValue, 0f, maxSliderValue);
        }
        else
        {
            isCurrentlyShaking = false;
        }
    }
}
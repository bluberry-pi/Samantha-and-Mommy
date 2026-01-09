using UnityEngine;
using TMPro;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    //public TextMeshProUGUI resultText;

    [Header("Correct Password")]
    public string correctPassword = "hello123";


    public void CheckPassword()
    {
        string typed = inputField.text;

        if (typed == correctPassword)
        {
            Debug.Log("ACCESS GRANTED");
        }
        else
        {
             Debug.Log("ACCESS DENIED");
        }

        inputField.text = "";
    }
}
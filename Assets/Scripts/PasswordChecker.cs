using UnityEngine;
using TMPro;
using System;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField inputField;

    [Header("Correct Password")]
    public string correctPassword = "hello123";

    public static event Action OnPasswordCorrect;

    public void CheckPassword()
    {
        string typed = inputField.text;

        if (typed == correctPassword)
        {
            Debug.Log("ACCESS GRANTED");

            // 🔔 Notify PCActions
            OnPasswordCorrect?.Invoke();

            // Destroy EVERYTHING tagged GameStuff
            GameObject[] stuff = GameObject.FindGameObjectsWithTag("GameStuff");
            foreach (GameObject g in stuff)
                Destroy(g);
        }
        else
        {
            Debug.Log("ACCESS DENIED");
        }

        inputField.text = "";
    }
}
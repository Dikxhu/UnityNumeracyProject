using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    public TextMeshProUGUI appleCounterText;
    public GameObject questionObject;
    public int apples = 0;
    public int winningNumber = 4;

    void Start()
    {
        // Hide the question when the game starts
        questionObject.SetActive(false);
        appleCounterText.text = "Apples: 0";
    }

    public void ShowTheQuestion()
    {
        // This runs when you click the button
        questionObject.SetActive(true);
    }

    public void AddApple()
    {
        // This runs when you pick up an apple
        apples++;
        appleCounterText.text = "Apples: " + apples;

        if (apples == winningNumber)
        {
            appleCounterText.color = Color.green; // Perfect!
        }
        else if (apples > winningNumber)
        {
            appleCounterText.color = Color.red; // Too many!
        }
    }
}
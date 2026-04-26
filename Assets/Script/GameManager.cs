using UnityEngine;
using TMPro; // This stays the same

public class GameManager : MonoBehaviour
{
    // Change this line! Remove the "UGUI" part
    public TextMeshPro additionSignText; 
    
    private int appleCount = 0;

    public void AppleClicked()
    {
        appleCount++; 

        if (appleCount == 4)
        {
            additionSignText.text = "Addition Station: 2 + 2 = 4";
            additionSignText.color = Color.green; 
        }
    }
}
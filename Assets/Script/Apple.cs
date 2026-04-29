using UnityEngine;

public class Apple : MonoBehaviour
{
    // This function runs when you click the apple with your mouse
    void OnMouseDown()
    {
        // 1. Tell the AppleManager to add 1 to the score
        AppleManager manager = FindObjectOfType<AppleManager>();
        
        if (manager != null)
        {
            manager.AddApple();
        }

        // 2. Destroy the apple so it disappears from the park
        Destroy(gameObject);
    }
}
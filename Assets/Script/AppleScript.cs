using UnityEngine;

public class AppleScript : MonoBehaviour
{
    // This works by WALKING into the apple, no clicking needed!
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager gm = Object.FindAnyObjectByType<GameManager>();
            gm.AppleClicked();
            gameObject.SetActive(false);
        }
    }
}
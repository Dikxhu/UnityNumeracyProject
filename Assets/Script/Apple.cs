using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectApple();

            Destroy(gameObject);
        }
    }
}
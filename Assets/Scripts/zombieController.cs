using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform playerTransform;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Move towards the player
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Trigger the game over state
            FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }

    // Call this method when the zombie is killed
    public void Die()
    {
        // Increment zombie count when the zombie is killed
        FindObjectOfType<GameOverManager>().IncrementZombieCount();
        Destroy(gameObject);
    }
}

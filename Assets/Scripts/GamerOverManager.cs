using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // To access the UI Text component

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;  // UI Text element to display the game over message and count
    public int zombieCount = 0; // Count of zombies killed
    private bool isGameOver = false;

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.text = ""; // Initially no game over message
        }
    }

    private void Update()
    {
        // Check if the game is over and the player presses R to reset
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void TriggerGameOver()
    {
        // Display a game over message with the zombie count
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over! You killed " + zombieCount + " zombies.\nPress R to restart";
        }

        // Stop game actions and pause the game
        isGameOver = true;
        Time.timeScale = 0f; // Pauses the game time
    }

    private void ResetGame()
    {
        // Restart the current scene
        Time.timeScale = 1f; // Resumes game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }

    // Call this method to update the zombie count when a zombie is killed
    public void IncrementZombieCount()
    {
        zombieCount++;
    }
}

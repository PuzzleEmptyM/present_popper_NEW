using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void PlayGame()
    {
        // Load Level 1. Replace "Level1" with the name of your first level scene.
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Game is exiting"); // This line is for debugging purposes and will not appear in a built game.
    }
}

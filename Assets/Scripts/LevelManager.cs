using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject endLevelMenu;
    public Bell[] bells;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckLevelCompletion()
    {
        foreach (var bell in bells)
        {
            if (!bell.HasPresent())
                return;
        }
        // All bells have presents
        endLevelMenu.SetActive(true);
    }

    public void ReplayLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadPreviousLevel()
    {
        // Load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // Add methods to load/reload levels triggered by UI buttons
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Add methods to load/reload levels triggered by UI buttons
}

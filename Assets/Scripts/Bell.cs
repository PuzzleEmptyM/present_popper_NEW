using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    private bool hasPresent = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Presents"))
        {
            hasPresent = true;
            LevelManager.Instance.CheckLevelCompletion();
        }
    }

    public bool HasPresent()
    {
        return hasPresent;
    }
}

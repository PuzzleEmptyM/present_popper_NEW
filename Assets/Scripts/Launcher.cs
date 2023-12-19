using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject[] presentPrefabs;
    [SerializeField] private float launchForce = 17f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private SantaMovement santaMovement;

    [SerializeField] private float inputCooldown = 0.5f;
    private float lastInputTime = -1f;

    private void Update()
    {
        LauncherLaunching();
        FlipSantaBasedOnCursor();
    }

    private void LauncherLaunching()
    {
        if (Input.GetMouseButtonUp(0) && Time.time >= lastInputTime + inputCooldown)
        {
            lastInputTime = Time.time;

            if (santaMovement != null)
            {
                santaMovement.PopAnimation();
            }

            Vector2 launchDirection = (crosshair.transform.position - playerTransform.position).normalized;
            int randomIndex = Random.Range(0, presentPrefabs.Length);

            // Calculate spawn position with offset
            Vector3 spawnPosition = CalculateSpawnPosition();

            GameObject presentInst = Instantiate(presentPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            Rigidbody2D rb = presentInst.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
    }

    private Vector3 CalculateSpawnPosition()
    {
        float spawnOffset = 0.5f; // Adjust this value as needed
        if (playerTransform.localScale.x > 0) // Santa facing right
        {
            return playerTransform.position + new Vector3(spawnOffset, 0, 0);
        }
        else // Santa facing left
        {
            return playerTransform.position - new Vector3(spawnOffset, 0, 0);
        }
    }

    private void FlipSantaBasedOnCursor()
    {
        if (crosshair.transform.position.x > playerTransform.position.x)
        {
            playerTransform.localScale = new Vector3(4.38f, 4.38f, 4.38f);
        }
        else
        {
            playerTransform.localScale = new Vector3(-4.38f, 4.38f, 4.38f);
        }
    }
}

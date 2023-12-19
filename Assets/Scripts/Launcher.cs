using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject[] presentPrefabs;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject crosshair; // Reference to the crosshair GameObject
    [SerializeField] private SantaMovement santaMovement;
    private void Update()
    {
        LauncherLaunching();
    }

    private void LauncherLaunching()
    {
        if (Input.GetMouseButtonUp(0)) // Checks if the left mouse button was released
        {
            if (santaMovement != null)
            {
                santaMovement.PopAnimation();
            }

            Vector2 launchDirection = (crosshair.transform.position - playerTransform.position).normalized;

            int randomIndex = Random.Range(0, presentPrefabs.Length);

            GameObject presentInst = Instantiate(presentPrefabs[randomIndex], playerTransform.position, Quaternion.identity);
            Rigidbody2D rb = presentInst.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}

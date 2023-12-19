using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject present;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject crosshair; // Reference to the crosshair GameObject

    private void Update()
    {
        LauncherLaunching();
    }

    private void LauncherLaunching()
    {
        if (Input.GetMouseButtonDown(0)) // Checks if the left mouse button was pressed
        {
            Vector2 launchDirection = (crosshair.transform.position - playerTransform.position).normalized;
            GameObject presentInst = Instantiate(present, playerTransform.position, Quaternion.identity);
            Rigidbody2D rb = presentInst.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}

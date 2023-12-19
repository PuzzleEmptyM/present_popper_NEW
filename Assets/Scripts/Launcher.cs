using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject present;
    [SerializeField] private Transform prsentSpawnPoint;

    private GameObject presentInst;
    private Vector2 worldPosition;

    // Update is called once per frame
    void Update()
    {
        MouseLocation();
        LauncherLaunching();
    }

    private void MouseLocation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)Player.transform.position).normalized;
    }

    private void LauncherLaunching()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            presentInst = Instantiate(present, prsentSpawnPoint);
        }
    }
}

using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    public GameObject target;
    public float rightFollowThreshold = 0.6f;
    public float leftFollowThreshold = 0.4f;
    public float minX, maxX; // Camera boundaries

    private Camera cam;
    public bool canFollow = true;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!canFollow) return;
        
        Vector3 targetViewportPos = cam.WorldToViewportPoint(target.transform.position);

        if (targetViewportPos.x > rightFollowThreshold || targetViewportPos.x < leftFollowThreshold)
        {
            float newXPosition = target.transform.position.x - (cam.ViewportToWorldPoint(new Vector3(targetViewportPos.x > rightFollowThreshold ? rightFollowThreshold : leftFollowThreshold, 0, 0)).x - cam.transform.position.x);
            newXPosition = Mathf.Clamp(newXPosition, minX, maxX); // Clamp the camera's X position within the boundaries
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
    }
    public void SetCameraFollow(bool follow)
    {
        canFollow = follow;
    }
}

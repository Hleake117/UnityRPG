using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Assign Player in Inspector
    public float smoothSpeed = 0.125f;  // Adjust for smoother movement
    public Vector3 offset;  // Adjust in Inspector to position the camera

    void LateUpdate()
    {
        if (player == null) return; // Prevent errors if player is missing

        // Desired camera position
        Vector3 desiredPosition = player.position + offset;
        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}

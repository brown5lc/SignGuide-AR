using UnityEngine;

public class Focus : MonoBehaviour
{
    public Transform head;              // assign CenterEyeAnchor here
    public float distance = 0.6f;
    public float heightOffset = -0.05f;

    void Start()
    {
        if (head == null) return;

        // Flatten forward so content is placed in front of the user horizontally
        Vector3 forward = head.forward;
        forward.y = 0f;
        forward.Normalize();

        transform.position = head.position + forward * distance + Vector3.up * heightOffset;

        // Face the user
        Vector3 lookDir = transform.position - head.position;
        lookDir.y = 0f;
        if (lookDir.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}

using UnityEngine;
using TMPro;

public class PoseMatchChecker : MonoBehaviour
{
    [Header("Transforms")]
    public Transform userHand;
    public Transform targetHand;

    [Header("Thresholds")]
    public float positionThreshold = 0.12f;   // meters
    public float rotationThreshold = 35f;     // degrees

    [Header("UI")]
    public TMP_Text statusText;

    [Header("Debug")]
    public bool isMatched;
    public float currentDistance;
    public float currentAngle;

    void Update()
    {
        if (userHand == null || targetHand == null)
            return;

        currentDistance = Vector3.Distance(userHand.position, targetHand.position);
        currentAngle = Quaternion.Angle(userHand.rotation, targetHand.rotation);

        isMatched = currentDistance <= positionThreshold;

        /*
        if (statusText != null)
        {
            statusText.text = isMatched ? "Matched!" : "\t\tMatch The Symbol! \nSign: Peace";
            statusText.color = isMatched ? Color.green : Color.white;
        }
        */

        if (statusText != null)
        {
            statusText.text = $"Dist: {currentDistance:F2}\nAng: {currentAngle:F1}\n" + (isMatched ? "Matched!" : "Match the sign");
            statusText.color = isMatched ? Color.green : Color.white;
        }
    }
}

using UnityEngine;
using TMPro;

public class FingertipMatchChecker : MonoBehaviour
{
    [Header("Live hand skeleton")]
    public OVRSkeleton liveSkeleton;

    [Header("Target fingertip transforms")]
    public Transform targetThumbTip;
    public Transform targetIndexTip;
    public Transform targetMiddleTip;
    public Transform targetRingTip;
    public Transform targetPinkyTip;

    [Header("Optional root check")]
    public Transform liveHandRoot;
    public Transform targetHandRoot;

    [Header("Thresholds")]
    public float fingertipThreshold = 0.045f;
    public float handRootThreshold = 0.12f;
    public bool requireHandRootMatch = true;

    [Header("UI")]
    public TMP_Text statusText;

    [Header("Debug")]
    public Transform liveThumbTip;
    public Transform liveIndexTip;
    public Transform liveMiddleTip;
    public Transform liveRingTip;
    public Transform livePinkyTip;

    public float thumbDistance;
    public float indexDistance;
    public float middleDistance;
    public float ringDistance;
    public float pinkyDistance;
    public float handRootDistance;

    public bool thumbMatched;
    public bool indexMatched;
    public bool middleMatched;
    public bool ringMatched;
    public bool pinkyMatched;
    public bool handRootMatched;
    public bool isMatched;

    void Update()
    {
        if (liveSkeleton == null ||
            targetThumbTip == null ||
            targetIndexTip == null ||
            targetMiddleTip == null ||
            targetRingTip == null ||
            targetPinkyTip == null)
            return;

        if (liveThumbTip == null || liveIndexTip == null || liveMiddleTip == null || liveRingTip == null || livePinkyTip == null)
        {
            FindTipBones();
        }

        if (liveThumbTip == null || liveIndexTip == null || liveMiddleTip == null || liveRingTip == null || livePinkyTip == null)
        {
            if (statusText != null)
                statusText.text = "Waiting for fingertip bones...";
            return;
        }

        thumbDistance = Vector3.Distance(liveThumbTip.position, targetThumbTip.position);
        indexDistance = Vector3.Distance(liveIndexTip.position, targetIndexTip.position);
        middleDistance = Vector3.Distance(liveMiddleTip.position, targetMiddleTip.position);
        ringDistance = Vector3.Distance(liveRingTip.position, targetRingTip.position);
        pinkyDistance = Vector3.Distance(livePinkyTip.position, targetPinkyTip.position);

        thumbMatched = thumbDistance <= fingertipThreshold;
        indexMatched = indexDistance <= fingertipThreshold;
        middleMatched = middleDistance <= fingertipThreshold;
        ringMatched = ringDistance <= fingertipThreshold;
        pinkyMatched = pinkyDistance <= fingertipThreshold;

        handRootMatched = true;
        handRootDistance = 0f;

        if (requireHandRootMatch && liveHandRoot != null && targetHandRoot != null)
        {
            handRootDistance = Vector3.Distance(liveHandRoot.position, targetHandRoot.position);
            handRootMatched = handRootDistance <= handRootThreshold;
        }

        isMatched = thumbMatched && indexMatched && middleMatched && ringMatched && pinkyMatched && handRootMatched;

        if (statusText != null)
        {
            statusText.text =
                $"Thumb: {thumbDistance:F3}\n" +
                $"Index: {indexDistance:F3}\n" +
                $"Middle: {middleDistance:F3}\n" +
                $"Ring: {ringDistance:F3}\n" +
                $"Pinky: {pinkyDistance:F3}\n" +
                $"Root: {handRootDistance:F3}\n\n" +
                (isMatched ? "Matched!" : "Match the sign");

            statusText.color = isMatched ? Color.green : Color.white;
        }
    }

    void FindTipBones()
    {
        if (liveSkeleton.Bones == null || liveSkeleton.Bones.Count == 0)
            return;

        foreach (var bone in liveSkeleton.Bones)
        {
            if (bone == null || bone.Transform == null)
                continue;

            if (bone.Id == OVRSkeleton.BoneId.XRHand_ThumbTip)
                liveThumbTip = bone.Transform;

            if (bone.Id == OVRSkeleton.BoneId.XRHand_IndexTip)
                liveIndexTip = bone.Transform;

            if (bone.Id == OVRSkeleton.BoneId.XRHand_MiddleTip)
                liveMiddleTip = bone.Transform;

            if (bone.Id == OVRSkeleton.BoneId.XRHand_RingTip)
                liveRingTip = bone.Transform;

            if (bone.Id == OVRSkeleton.BoneId.XRHand_LittleTip)
                livePinkyTip = bone.Transform;
        }
    }
}
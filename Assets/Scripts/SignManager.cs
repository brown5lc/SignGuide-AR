using UnityEngine;
using TMPro;

public class SignManager : MonoBehaviour
{
    public SignPose[] signs;
    public int currentIndex = 0;

    public FingertipMatchChecker matchChecker;
    public TMP_Text signLabelText;

    [Header("Auto Advance")]
    public bool autoAdvanceOnMatch = true;
    public float advanceDelay = 1.0f;

    private bool waitingToAdvance = false;
    private float matchTimer = 0f;

    void Start()
    {
        ShowSign(currentIndex);
    }

    void Update()
    {
        // Optional debug keys if you ever need them
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.N))
        {
            NextSign();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.P))
        {
            PreviousSign();
        }

        if (autoAdvanceOnMatch && matchChecker != null)
        {
            if (matchChecker.isMatched)
            {
                matchTimer += Time.deltaTime;

                if (!waitingToAdvance && matchTimer >= advanceDelay)
                {
                    waitingToAdvance = true;
                    NextSign();
                }
            }
            else
            {
                matchTimer = 0f;
                waitingToAdvance = false;
            }
        }
    }

    public void NextSign()
    {
        currentIndex = (currentIndex + 1) % signs.Length;
        ShowSign(currentIndex);
        ResetAdvanceState();
    }

    public void PreviousSign()
    {
        currentIndex = (currentIndex - 1 + signs.Length) % signs.Length;
        ShowSign(currentIndex);
        ResetAdvanceState();
    }

    void ShowSign(int index)
    {
        for (int i = 0; i < signs.Length; i++)
        {
            signs[i].gameObject.SetActive(i == index);
        }

        SignPose sign = signs[index];

        if (matchChecker != null)
        {
            matchChecker.targetHandRoot = sign.handRoot;
            matchChecker.targetThumbTip = sign.thumbTip;
            matchChecker.targetIndexTip = sign.indexTip;
            matchChecker.targetMiddleTip = sign.middleTip;
            matchChecker.targetRingTip = sign.ringTip;
            matchChecker.targetPinkyTip = sign.pinkyTip;
        }

        if (signLabelText != null)
        {
            signLabelText.text = $"Sign: {sign.signName}";
        }
    }

    void ResetAdvanceState()
    {
        matchTimer = 0f;
        waitingToAdvance = false;
    }
}
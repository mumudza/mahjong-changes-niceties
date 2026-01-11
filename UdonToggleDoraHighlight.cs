using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class UdonToggleDoraHighlight : UdonSharpBehaviour
{
    [Header("Target")]
    public GameObject doraHighlight;

    [Header("UI References")]
    public TextMeshProUGUI buttonText;

    [Header("Button Labels")]
    public string enabledText = "Disable Dora Highlight";
    public string disabledText = "Enable Dora Highlight";

    private bool enabledState = false;

    void Start()
    {
        if (doraHighlight != null)
        {
            doraHighlight.SetActive(enabledState);
        }

        UpdateButtonState();
    }

    public override void Interact()
    {
        enabledState = !enabledState;

        if (doraHighlight != null)
        {
            doraHighlight.SetActive(enabledState);
        }

        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        if (buttonText != null)
        {
            buttonText.text = enabledState ? enabledText : disabledText;
        }
    }
}

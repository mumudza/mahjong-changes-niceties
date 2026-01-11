using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using TMPro;

public class UdonToggleTileMaterials : UdonSharpBehaviour
{
    [Header("Tile Set Roots (Up to 16)")]
    public Transform[] tileSets = new Transform[16];
    public int tileSetCount = 4;  // How many tilesets to actually use

    [Header("Materials (Material Index 1)")]
    public Material enabledMaterial;    // Normal tiles
    public Material disabledMaterial;   // Fisher-Price tiles

    [Header("UI References")]
    public TextMeshProUGUI buttonText;
    public Button button;

    [Header("Button Labels")]
    public string enabledText = "Disable Fisher-Price tiles";
    public string disabledText = "Enable Fisher-Price tiles";

    private bool enabledState = false;

    private MeshRenderer[][] renderers = new MeshRenderer[16][];

    void Start()
    {
        // Populate renderers array based on tileSetCount
        for (int i = 0; i < tileSetCount; i++)
        {
            if (tileSets[i] != null)
            {
                renderers[i] = tileSets[i].GetComponentsInChildren<MeshRenderer>(true);
            }
        }

        ApplyMaterialState();
        UpdateButtonState();
    }

    public override void Interact()
    {
        enabledState = !enabledState;
        ApplyMaterialState();
        UpdateButtonState();
    }

    private void ApplyMaterialState()
    {
        Material targetMaterial = enabledState ? disabledMaterial : enabledMaterial;

        for (int i = 0; i < tileSetCount; i++)
        {
            ApplyToRendererArray(renderers[i], targetMaterial);
        }
    }

    private void ApplyToRendererArray(MeshRenderer[] renderers, Material targetMaterial)
    {
        if (renderers == null) return;

        for (int i = 0; i < renderers.Length; i++)
        {
            MeshRenderer mr = renderers[i];
            if (mr == null) continue;

            Material[] mats = mr.materials;

            if (mats.Length > 1)
            {
                mats[1] = targetMaterial;
                mr.materials = mats;
            }
        }
    }

    private void UpdateButtonState()
    {
        if (buttonText != null)
        {
            buttonText.text = enabledState ? enabledText : disabledText;
        }
    }
}

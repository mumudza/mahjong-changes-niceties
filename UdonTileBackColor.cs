using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class UdonTileBackColor : UdonSharpBehaviour
{
    [Header("Tile Set Roots (Up to 16)")]
    public Transform[] tileSets = new Transform[16];
    public int tileSetCount = 4;  // How many tilesets to actually use

    [Header("Tile Back Color (Material Index 0)")]
    public Color tileBackColor = new Color(0.125f, 0.51f, 0f);

    [Header("UI Button (Image Only)")]
    public Button button;

    private MeshRenderer[][] renderers = new MeshRenderer[16][];

    private MaterialPropertyBlock mpb;
    private Texture2D tileBackTexture; // Reusable 1x1 texture

    void Start()
    {
        mpb = new MaterialPropertyBlock();

        // Populate renderers array based on tileSetCount
        for (int i = 0; i < tileSetCount; i++)
        {
            if (tileSets[i] != null)
            {
                renderers[i] = tileSets[i].GetComponentsInChildren<MeshRenderer>(true);
            }
        }

        // Create the reusable 1x1 texture
        CreateTileBackTexture();

        UpdateButtonColor();
    }

    public override void Interact()
    {
        // Update the texture to match the current color
        UpdateTileBackTexture();

        ApplyColor();
        UpdateButtonColor();
    }

    private void ApplyColor()
    {
        for (int i = 0; i < tileSetCount; i++)
        {
            ApplyToRendererArray(renderers[i]);
        }
    }

    private void ApplyToRendererArray(MeshRenderer[] renderers)
    {
        if (renderers == null || tileBackTexture == null) return;

        for (int i = 0; i < renderers.Length; i++)
        {
            MeshRenderer mr = renderers[i];
            if (mr == null) continue;

            // Apply to material slot 0 (tile back)
            mr.GetPropertyBlock(mpb, 0);
            mpb.SetTexture("_MainTex", tileBackTexture);
            mr.SetPropertyBlock(mpb, 0);
        }
    }

    private void CreateTileBackTexture()
    {
        if (tileBackTexture == null)
        {
            tileBackTexture = new Texture2D(1, 1);
            tileBackTexture.wrapMode = TextureWrapMode.Repeat;
        }
        UpdateTileBackTexture();
    }

    private void UpdateTileBackTexture()
    {
        if (tileBackTexture != null)
        {
            tileBackTexture.SetPixel(0, 0, tileBackColor);
            tileBackTexture.Apply();
        }
    }

    private void UpdateButtonColor()
    {
        if (button == null) return;

        Image img = button.GetComponent<Image>();
        if (img != null)
        {
            img.color = tileBackColor;
        }
    }
}

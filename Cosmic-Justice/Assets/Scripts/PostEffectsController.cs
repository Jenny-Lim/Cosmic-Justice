using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffectsController : MonoBehaviour
{
    public Shader shader;
    Material mat;

    public Color color, colorToChange;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (mat == null) mat = new Material(shader);

        RenderTexture renderTex = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);

        mat.SetColor("_color", color);
        mat.SetColor("_colorToChange", colorToChange);

        // alter
        Graphics.Blit(src, renderTex, mat); // apply shader
        Graphics.Blit(renderTex, dest);

        RenderTexture.ReleaseTemporary(renderTex); // release
    } // OnRenderImage
}

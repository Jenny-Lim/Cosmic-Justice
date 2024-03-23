using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffectsController : MonoBehaviour
{
    public Shader shader;
    Material mat;
    [SerializeField] Color[] colors = new Color[9];

    //public Color[] replacingColors = { Color.white, Color.white, Color.white, Color.white, Color.white, Color.white, Color.white };
    //private string[] replacingColorStrings = { "_replacingRed", "_replacingGreen", "_replacingBlue", "_replacingYellow", "_replacingOrange", "_replacingPurple", "_replacingCyan"};

    //void OnEnable()
    //{
    //    replacingColors = SettingsSaver.instance.replacingColors;
    //}

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (mat == null) mat = new Material(shader);

        RenderTexture renderTex = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);

        //for (int i = 0; i < replacingColors.Length; i++) {
        mat.SetColorArray("_colors", colors);
        mat.SetColorArray("_replacingColors", SettingsSaver.instance.replacingColors);
        //}

        // alter
        Graphics.Blit(src, renderTex, mat); // apply shader
        Graphics.Blit(renderTex, dest);

        RenderTexture.ReleaseTemporary(renderTex); // release
    } // OnRenderImage
}

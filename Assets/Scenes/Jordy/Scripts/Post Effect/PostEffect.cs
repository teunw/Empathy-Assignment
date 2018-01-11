using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://willweissman.wordpress.com/tutorials/shaders/unity-shaderlab-object-outlines/
// https://denizbicer.github.io/2017/02/16/Object-Outlines-at-Steam-VR-with-Unity-5.html
// http://denizbicer.com/2017/02/26/object-outlines-at-steam-vr-with-unity-5/


public class PostEffect : MonoBehaviour {


    Camera AttachedCamera;
    public Shader Post_Outline;
    public Shader DrawSimple;
    public Color glowColor;
    Camera TempCam;
    Material Post_Mat;
    // public RenderTexture TempRT;


    void Start()
    { 
        AttachedCamera = GetComponent<Camera>();
        TempCam = new GameObject().AddComponent<Camera>();
        TempCam.enabled = false;
        Post_Mat = new Material(Post_Outline);
    }

   void OnRenderImage(RenderTexture source, RenderTexture destination)
   {
        //set up a temporary camera
        TempCam.CopyFrom(AttachedCamera);
        TempCam.clearFlags = CameraClearFlags.Color;
        TempCam.backgroundColor = Color.black;

        //cull any layer that isn't the outline
        TempCam.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        //make the temporary rendertexture
        RenderTexture TempRT = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.R8);

        //put it to video memory
        TempRT.Create();

        //set the camera's target texture when rendering
        TempCam.targetTexture = TempRT;

        //render all objects this camera can render, but with our custom shader.
        TempCam.RenderWithShader(DrawSimple, "");

        Post_Mat.SetTexture("_SceneTex", source);
        Post_Mat.SetColor("_Color", glowColor);

        //copy the temporary RT to the final image
        Graphics.Blit(TempRT, destination, Post_Mat);

        //release the temporary RT
        TempRT.Release();
    }
}

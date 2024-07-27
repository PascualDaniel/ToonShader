using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class CustomPostProcessPass : ScriptableRenderPass
{
    private Material m_bloomMaterial;
    private Material m_compositeMaterial;
    private RenderTextureDescriptor m_Descriptor;
    private RTHandle m_CameraColorTarget;
    private RTHandle m_CameraDepthTarget;

    const int k_MaxPyramidSize = 16;
    private int[] _BloomMipUp;
    private int[] _BloomMipDown;
    private RTHandle[] m_BloomMipUp;
    private RTHandle[] m_BloomMipDown;
    private GraphicsFormat hdrFormat;


    public CustomPostProcessPass(Material bloomMaterial, Material compositeMaterial)
    {
        this.m_bloomMaterial = bloomMaterial;
        this.m_compositeMaterial = compositeMaterial;

        renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

        _BloomMipUp = new int[k_MaxPyramidSize];
        _BloomMipDown = new int[k_MaxPyramidSize];
        m_BloomMipUp = new RTHandle[k_MaxPyramidSize];  
        m_BloomMipDown = new RTHandle[k_MaxPyramidSize];

        for (int i = 0; i < k_MaxPyramidSize; i++)
        {
            _BloomMipUp[i] = Shader.PropertyToID("_BloomMipUp" + i);
            _BloomMipDown[i] = Shader.PropertyToID("_BloomMipDown" + i);

            m_BloomMipUp[i] = RTHandles.Alloc(_BloomMipUp[i],name: "_BloomMipUp" + i );
            m_BloomMipDown[i] = RTHandles.Alloc(_BloomMipDown[i],name: "_BloomMipDown" + i );
        }
        


    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
   
    }
    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
    {
        m_Descriptor = renderingData.cameraData.cameraTargetDescriptor;
    }
    public void setTarget(RTHandle cameraColorTargetHandle, RTHandle cameraDepthTargetHandle)
    {
        m_CameraColorTarget = cameraColorTargetHandle;
        m_CameraDepthTarget = cameraDepthTargetHandle;
    }




}

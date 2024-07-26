using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class CustomPostPorcessRenderFeature : ScriptableRendererFeature
{

   [SerializeField]
   private Shader m_bloomShader;
   [SerializeField]
   private Shader m_compositeShader;

   private Material m_bloomMaterial;
   private Material m_compositeMaterial;
   private CustomPostProcessPass m_customPass;

   public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
   {
      renderer.EnqueuePass(m_customPass);
   }

   public override void Create()
   {
      m_bloomMaterial = CoreUtils.CreateEngineMaterial(m_bloomShader);
      m_compositeMaterial = CoreUtils.CreateEngineMaterial(m_compositeShader);

      m_customPass = new CustomPostProcessPass(m_bloomMaterial, m_compositeMaterial);
   }

   protected override void Dispose(bool disposing)
   {
      CoreUtils.Destroy(m_bloomMaterial);
      CoreUtils.Destroy(m_compositeMaterial);
   }


}

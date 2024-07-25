using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[VolumeComponentMenuForRenderPipeline("Custom/Ben Day Bloom",typeof(UniversalRenderPipeline) )]
public class BenDayBloomEffectComponet : VolumeComponent, IPostProcessComponent
{
    // Start is called before the first frame update
    public bool IsActive()
    {
        return true;
    }
    public bool IsTileCompatible()
    {
        return false;
    }
}

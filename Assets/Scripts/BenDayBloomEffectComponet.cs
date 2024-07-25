using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Vector2 = UnityEngine.Vector2;

[VolumeComponentMenuForRenderPipeline("Custom/Ben Day Bloom",typeof(UniversalRenderPipeline) )]
public class BenDayBloomEffectComponet : VolumeComponent, IPostProcessComponent
{
    [Header("Bloom settings")]
    public FloatParameter treshHold = new FloatParameter(0.9f,true);

    public FloatParameter intensity = new FloatParameter(1.0f, true);

    public ClampedFloatParameter scatter = new ClampedFloatParameter(0.7f, 0.0f, 1.0f, true);

    public IntParameter clamp = new IntParameter(65472, true);

    public ClampedIntParameter maxIterations = new ClampedIntParameter(6,0,10);

    public NoInterpColorParameter tint = new NoInterpColorParameter(Color.white);

    [Header("Benday")]
    public IntParameter dotsDensity = new IntParameter(10,true);

    public ClampedFloatParameter dotsCutOff = new ClampedFloatParameter(0.4f,0.0f,1.0f,true);
    public Vector2Parameter scrollDirection = new Vector2Parameter(new Vector2());

    public bool IsActive()
    {
        return true;
    }

    public bool IsTileCompatible()
    {
       return false;
    }
}

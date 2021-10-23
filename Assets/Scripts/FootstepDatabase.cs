using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class encapsulates the data FoostepSurface can use to retrieve information about footsteps.
/// Its intended to be filled in the editor, and then turned into a prefab. It can then be instanced in whatever scene needs it.
/// </summary>
public class FootstepDatabase : MonoBehaviour
{
    [SerializeField] public List<AudioClip> WoodStepClips;
    [SerializeField] public List<AudioClip> ConcreteStepClips;
    [SerializeField] public List<AudioClip> GrassStepClips;
    [SerializeField] public List<AudioClip> WaterStepClips;

    public enum SurfaceType
    {
        Wood,
        Concrete,
        Grass,
        Water,
    }

    private void Awake()
    {
        gameObject.tag = "FootstepDatabase";
    }
}

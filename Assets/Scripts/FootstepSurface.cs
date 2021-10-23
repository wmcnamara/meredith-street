using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a surface that the player can step on, and should play footstep sounds as such.
/// </summary>
public class FootstepSurface : MonoBehaviour
{
    [SerializeField] private FootstepDatabase.SurfaceType SurfaceType;

    //Get a handle to the FootstepDatabase
    private FootstepDatabase db;
    private void Start()
    {
        try
        {
            db = GameObject.FindGameObjectWithTag("FootstepDatabase").GetComponent<FootstepDatabase>();
        }
        catch(Exception)
        {
            Debug.LogError("Please add the footstep database from prefabs");
        }
    }

    //Returns a list of footsteps that correspond to the SurfaceType member.
    public List<AudioClip> GetFootsteps()
    {
        switch (SurfaceType)
        {
            case FootstepDatabase.SurfaceType.Wood:
                return db.WoodStepClips;

            case FootstepDatabase.SurfaceType.Concrete:
                return db.ConcreteStepClips;

            case FootstepDatabase.SurfaceType.Grass:
                return db.GrassStepClips;

            case FootstepDatabase.SurfaceType.Water:
                return db.WaterStepClips;

            default:
                return db.GrassStepClips;
        }
    }
}

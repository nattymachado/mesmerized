﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public abstract class BaseAudioController : MonoBehaviour
{
    //Control Variables
    [Header("General Configurations")]
    [SerializeField] protected float _baseVolume;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioTypeEnum _audioType;

    //Internal Variables
    protected float _desiredVolume;

    // Use this for initialization
    protected virtual void Awake()
    {
        _audioSource.playOnAwake = false;
        _audioSource.Stop();
        _audioSource.spatialBlend = 0f;
        
    }

    //Adjust Volume
    protected virtual void SetDesiredVolume(float newVolume)
    {
       
        
    }
}


﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public Sprite rangeSprite;
    public Sprite checkSprite;
    public Sprite alienHor;
    public Sprite alienVert;

    public SoundAudioClip[] soundAudioClipArray;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
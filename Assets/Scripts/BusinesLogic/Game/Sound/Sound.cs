﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound : MonoBehaviour {
    public AudioClip[] goblinDeath;
    public AudioClip[] goblinSpawn;
    public AudioClip[] jump;
    public AudioClip[] spin;
    public AudioClip[] swordSlice;
    public AudioClip backgroundMusic;
    public AudioClip landingSound;
    public AudioClip startMusicQ;
    public AudioClip startButton;
    public AudioClip fall;
    public AudioClip buttonPush;
    private Dictionary<EnemyType, EnemySoundModel> enemieSounds;
    public static Sound sound;
    // Use this for initialization
    void Awake()
    {
        if (sound == null)
        {
            DontDestroyOnLoad(gameObject);
            sound = this;
        }
        else if (sound != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        initilaizDictionary();
    }

    private void initilaizDictionary()
    {
        enemieSounds = new Dictionary<EnemyType, EnemySoundModel> {
            {EnemyType.General,new EnemySoundModel {deathSound = goblinDeath, enemyType = EnemyType.General, spawnSound = goblinSpawn} }
        };
    }
    public AudioClip playerGetRandomJumpSound()
    {
        int max = jump.Length;
        return jump[UnityEngine.Random.Range(0,max)];
    }
    public AudioClip playerGetRandomSpinSound()
    {
        int max = spin.Length;
        return spin[UnityEngine.Random.Range(0, max)];
    }
    public AudioClip playerGetRandomSliceSound()
    {
        int max = swordSlice.Length;
        return swordSlice[UnityEngine.Random.Range(0, max)];
    }
    public AudioClip playerGetLandingSound()
    {
        return landingSound;
    }
    public AudioClip playerGetFallSound()
    {
        return fall;
    }
    public AudioClip EnemyGetSpawnSound(EnemyType type)
    {
        type = EnemyType.General;
        var spawnSounds = enemieSounds[type].spawnSound;
        int max = spawnSounds.Length;
        return spawnSounds[UnityEngine.Random.Range(0, max)];
    }
    public AudioClip EnemyGetDeathSound(EnemyType type)
    {
        type = EnemyType.General;
        var deathSounds = enemieSounds[type].deathSound;
        int max = deathSounds.Length;
        return deathSounds[UnityEngine.Random.Range(0, max)];
    }
    public AudioClip getStartButtonSound()
    {
        return startButton;
    }
    public AudioClip getBackGroundMusic()
    {
        return backgroundMusic;
    }
    public AudioClip getStartMenuQ()
    {
        return startMusicQ;
    }
    public AudioClip getButtonPushSound()
    {
        return buttonPush;
    }
}

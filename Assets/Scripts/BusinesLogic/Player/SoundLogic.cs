﻿using UnityEngine;
using System.Collections;

public class SoundLogic : MonoBehaviour {

    AudioClip currentlyPlaying;
    AudioSource audioSource1;
    AudioSource audioSource2;
    public float sliceDelay = 0.1f;
    public float fallDelay = 0.3f;
	// Use this for initialization
	void Start () {
        audioSource1 = GameObject.Find("SoundSourcePlayer1").GetComponent<AudioSource>();
        audioSource2 = GameObject.Find("SoundSourcePlayer2").GetComponent<AudioSource>();
	}
    public void playFallSound() 
    {   
        currentlyPlaying = Sound.sound.playerGetFallSound();
        audioSource2.clip = currentlyPlaying;
        audioSource2.PlayDelayed(fallDelay);
    }
    public void playSliceSound()
    {
        Debug.Log("play slicingSound");
        currentlyPlaying = Sound.sound.playerGetRandomSliceSound();
        audioSource1.Stop();
        audioSource2.Stop();
        audioSource2.PlayOneShot(currentlyPlaying);
    }
    public void playSpinningeSound()
    {
        currentlyPlaying = Sound.sound.playerGetRandomSpinSound();
        audioSource1.Stop();
        audioSource1.clip = currentlyPlaying;
        audioSource1.PlayDelayed(sliceDelay);
        //audioSource2.Stop();
    }
    public void playJumpSound()
    {
        currentlyPlaying = Sound.sound.playerGetRandomJumpSound();
        audioSource1.Stop();
        audioSource2.Stop();
        audioSource1.PlayOneShot(currentlyPlaying);
    }
    public void playLandingSound()
    {
        currentlyPlaying = Sound.sound.playerGetLandingSound();
        audioSource1.Stop();
        audioSource2.Stop();
        audioSource1.PlayOneShot(currentlyPlaying);
    }

	
    
}

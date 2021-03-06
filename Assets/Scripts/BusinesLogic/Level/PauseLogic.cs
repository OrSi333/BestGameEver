﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseLogic : MonoBehaviour {
    public float timeToMenuToOpenAndClose = 1f;
    GameObject PauseMenu;
    public Vector3 menuOrigPos;
    public Vector3 menuEndPos;
    bool isMenuOpen = false;
    Sprite imageOpen;
    Sprite imageClose;
    Image buttonImage;
    AudioSource audioSource;
    AudioClip clickSound;
	// Use this for initialization
	void Start () {
        PauseMenu = GameObject.Find("PauseMenu");
        audioSource = GameObject.Find("Camera").GetComponent<AudioSource>();
        menuOrigPos = new Vector3(0, 30, 0);
        menuEndPos = new Vector3(0,6,0);
        imageClose = Resources.Load<Sprite>("pause1");
        imageOpen = Resources.Load<Sprite>("resume1");
        buttonImage = GameObject.Find("Pause").GetComponent<Image>();
        clickSound = Sound.sound.getButtonPushSound();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onPause(){
        if (isMenuOpen)
        {
            closeMenu();
        }
        else
        {
            openMenu();
        }
    }

    private void openMenu()
    {
        Time.timeScale = 0;
        LeanTween.move(PauseMenu, menuEndPos, timeToMenuToOpenAndClose).setIgnoreTimeScale(true);
        isMenuOpen = true;
        buttonImage.sprite = imageOpen;
        audioSource.PlayOneShot(clickSound);
    }

    private void closeMenu()
    {
        Time.timeScale = 1;
        LeanTween.move(PauseMenu, menuOrigPos, timeToMenuToOpenAndClose).setIgnoreTimeScale(true);
        isMenuOpen = false;
        buttonImage.sprite = imageClose;
        audioSource.PlayOneShot(clickSound);
        
    }

}

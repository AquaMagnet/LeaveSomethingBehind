using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class GiftEvent : MonoBehaviour
{

    [SerializeField] int numberGiftLeft = 2;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    bool playerHasAGift = false;
    TimerCountdown timesUp;
    public Sound[] sounds;
    private void Awake()
    {


        Time.timeScale = 1f;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
        
    }

    private void Start()
    {
        FindObjectOfType<GiftUI>().SetInitialGift(numberGiftLeft);
        timesUp = FindObjectOfType<TimerCountdown>();
    }



    void FixedUpdate()
    {
        if (timesUp.TimeOut())
        {
            Play("GameLose");
            loseText.SetActive(true);
            Time.timeScale = 0f;
        }
        if (GetComponentInChildren<PickUp>() is null) { playerHasAGift = false; return; } //If no gift existing
        if(GetComponentInChildren<PickUp>().PlayerHasGift())
        {
            playerHasAGift = true;
        }
        else
        {
            playerHasAGift = false;
        }

    }

    public bool PlayerCarriesGift()
    {
        return playerHasAGift;
    }

    public void ProcessGift()
    {
        --numberGiftLeft;
        Play("GiftDrop");

        //giftDrop.PlayOneShot(giftDrop.clip, 0.4f);
        FindObjectOfType<GiftUI>().GiftNumUpdate(numberGiftLeft);
        if (numberGiftLeft <= 0)
        {
            StartCoroutine(DelayWin());
            
            
        }
    }

    IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(1);
        Play("GameWin");
        winText.SetActive(true);
        Time.timeScale = 0f;
    }
    public int NumGift()
    {
        return numberGiftLeft;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }


}

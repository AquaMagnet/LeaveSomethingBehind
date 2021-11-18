using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftEvent : MonoBehaviour
{

    [SerializeField] int numberGiftLeft = 2;
    bool playerHasAGift = false;
    TimerCountdown timesUp;
    private void Awake()
    {
        FindObjectOfType<GiftUI>().SetInitialGift(numberGiftLeft);
        
    }

    private void Start()
    {
        timesUp = FindObjectOfType<TimerCountdown>();
    }

    void FixedUpdate()
    {
        if (timesUp.TimeOut())
        {
            Debug.Log("Time is Up! Game Over!");
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
        FindObjectOfType<GiftUI>().GiftNumUpdate(numberGiftLeft);
        if (numberGiftLeft <= 0)
        {
            Time.timeScale = 0f; 
            Debug.Log("Player Wins!");
        }
    }

    public int NumGift()
    {
        return numberGiftLeft;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftUI : MonoBehaviour
{
    TextMeshProUGUI giftText;
    int numberOfGift;
    int currentGiftNum;
    private void Awake()
    {
        giftText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
    }

    public void GiftNumUpdate(int latestGift)
    {
        giftText.text = latestGift.ToString() + " / " + currentGiftNum;
    }

    public void SetInitialGift(int currentGift)
    {
        giftText.text = currentGift.ToString() + " / " + currentGift;
        currentGiftNum = currentGift;
    }



}

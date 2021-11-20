using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GiftUI : MonoBehaviour
{
    TextMeshProUGUI giftText;
    int currentGiftNum;
    //private void Awake()
    //{
    //
    //
    //}

    private void Start()
    {
        Time.timeScale = 1f;
        giftText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void GiftNumUpdate(int latestGift)
    {
        giftText.text = latestGift.ToString() + " / " + currentGiftNum;
    }

    public void SetInitialGift(int currentGift)
    {
        currentGiftNum = currentGift;
        Debug.Log(currentGiftNum);
        giftText.text = currentGiftNum.ToString() + " / " + currentGiftNum;

       
  
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }


}

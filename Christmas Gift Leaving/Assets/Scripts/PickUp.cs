using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool playerPickUp = false;
    bool playerHasGift = false;
    bool inArea = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea)
        {
            playerPickUp = true;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inArea = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.GetComponentInChildren<GiftEvent>().PlayerCarriesGift() == false)
            if (other.tag == "Player" && playerPickUp)
            {
                this.transform.position = GameObject.Find("ItemPickUp").transform.position;
                this.transform.parent = GameObject.Find("ItemPickUp").transform;
                playerHasGift = true;
                playerPickUp = false;
                Destroy(this.GetComponent<BoxCollider>());
                Destroy(this.GetComponent<SphereCollider>());
            }
    }

    public bool PlayerHasGift()
    {
        return playerHasGift;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDrop : MonoBehaviour
{
    private bool _playerInArea = false;
    private bool _getGift = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerInArea)
        {
            _getGift = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInArea = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.GetComponentInChildren<PickUp>() is null) { return; }
        if(other.GetComponentInChildren<PickUp>().PlayerHasGift() && _getGift)
        {
            _getGift = false;
            other.GetComponentInChildren<GiftEvent>().ProcessGift();
            GiftDestroy(other);
            CarryAnimStop(other);
        }
    }

    private static void CarryAnimStop(Collider other)
    {
        other.GetComponent<Animator>().SetBool("carrying", false);
    }

    private void GiftDestroy(Collider other)
    {
        Destroy(other.GetComponentInChildren<PickUp>().gameObject);
        Destroy(gameObject);
    }
}

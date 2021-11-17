using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.transform.position = GameObject.Find("ItemPickUp").transform.position;
                this.transform.parent = GameObject.Find("ItemPickUp").transform;
            }
        }
    }


}

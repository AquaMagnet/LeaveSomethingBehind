using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("SoundSystem") is null)
        {
            return;
        }
        else
        {
            Destroy(GameObject.Find("SoundSystem"));
        }

    }
}

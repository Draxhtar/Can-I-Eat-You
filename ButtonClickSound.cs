using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] GameObject clickSound;

    public void SoundClick() 
    {
        Instantiate(clickSound);
    }
}

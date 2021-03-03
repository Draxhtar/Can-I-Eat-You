using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    [SerializeField] private GameObject[] footstepSounds;

    public void Step() 
    {
        Instantiate(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
}

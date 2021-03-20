using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    [SerializeField] private GameObject[] footstepSounds;
    
    public void Step() //Call this function on an Animation Event
    {
        Instantiate(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
}

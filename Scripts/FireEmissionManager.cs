using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEmissionManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireParticle;

    private void Awake()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            var emission = fireParticle.emission;
            emission.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            var emission = fireParticle.emission;
            emission.enabled = false;
        }
    }
}

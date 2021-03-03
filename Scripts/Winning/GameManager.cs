using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TopDownMovement topDownMovement;
    [SerializeField] private RotateTowardsMouse rotateTowardsMouse;
    [SerializeField] private FootstepSounds footstepSounds;
    [SerializeField] private Animator torsoAnimator;

    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private GameObject winSound;

    public void CompleteLevel() 
    {
        torsoAnimator.enabled = false;
        topDownMovement.enabled = false;
        rotateTowardsMouse.enabled = false;
        footstepSounds.enabled = false;
        levelCompleteUI.SetActive(true);
        Instantiate(winSound);
    }
}

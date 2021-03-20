using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script uses the Brackeys tutorial as a base
public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D myRb;
    [SerializeField] private Animator torsoAnimator;
    [SerializeField] private Animator legAnimator;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if (movement.x == 0 && movement.y == 0)
        {
            torsoAnimator.SetFloat("Speed", 0);
            legAnimator.SetFloat("Speed", 0);
        }
        else
        {
            torsoAnimator.SetFloat("Speed", 1);
            legAnimator.SetFloat("Speed", 1);
        }

        #region deadCode
        //anim["Player"].speed
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        #endregion

    }

    private void FixedUpdate()
    {
        myRb.MovePosition(myRb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

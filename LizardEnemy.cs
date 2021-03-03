//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D myRb;
    //[SerializeField] private GameObject bloodParticle;

    private Vector3 moveDir;

    [Header("Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float runDistance;
    [SerializeField] private float runDelay;
    float currentSpeedMultiplier;

    bool isWalkingDirSet = false;
    private enum myStates
    {
        Idle,
        Walking,
        Running,
        Catched,
        Dead,
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //        myState = myStates.Running;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //        myState = myStates.Walking;
    //}

    [SerializeField] private myStates myState = myStates.Walking;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            myState = myStates.Walking;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = myStates.Running;
        }

        int i = (int)myState;
        animator.SetInteger("State", i);

        switch (i)
        {
            case 0: //IDLE
                {

                    break;
                }
            case 1: //Walking
                {
                    WalkAround();
                    break;
                }
            case 2: //RUNNING!!
                {
                    RunawayFromThePlayer();
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    break;
                }
        }


    }

    private void WalkAround()
    {
        if (myState == myStates.Catched || myState == myStates.Dead)
            return;
        if ((player.position - transform.position).magnitude < runDistance) 
        {
            Invoke("StartRunning", runDelay);
            
        }
        //if (isWalkingDirSet == false)
        //{
        //    moveDir = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
        //}
        //isWalkingDirSet = true;
        ////Debug.Log(isWalkingDirSet);
        ////Debug.Log(moveDir);
        //currentSpeedMultiplier = walkSpeed;
        //Debug.Log("Just walking");
    }

    void StartRunning() 
    {
        if (myState == myStates.Catched || myState == myStates.Dead)
            return;
        myState = myStates.Running;
        animator.SetInteger("State", 2);
    }

    private void RunawayFromThePlayer()
    {
        if (myState == myStates.Catched || myState == myStates.Dead)
            return;
        currentSpeedMultiplier = runSpeed;
        isWalkingDirSet = false;

        Vector3 playerPos = player.position;
        moveDir = transform.position - playerPos;
        //Debug.Log(moveDir.normalized);
        Debug.DrawLine(transform.position, transform.position + moveDir, Color.green);
        Debug.DrawLine(transform.position, transform.position + moveDir.normalized, Color.red);
    }

    private void FixedUpdate()
    {
        if (myState == myStates.Catched || myState == myStates.Dead)
            return;

        myRb.velocity = moveDir.normalized * currentSpeedMultiplier * Time.fixedDeltaTime;

        float angle = Mathf.Atan2(moveDir.normalized.y, moveDir.normalized.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
    }

    public void GetEaten(Vector2 playerPos, Vector2 eatStartPos)
    {
        myState = myStates.Catched;
        transform.position = eatStartPos; //TWEEN IT LATER

        //Debug.Log(playerPos);
        //Debug.Log(eatStartPos);

        Vector2 lookDir = playerPos - eatStartPos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        GetComponent<Collider2D>().enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        
        //Instantiate(bloodParticle, transform.position, Quaternion.identity);
        myState = myStates.Dead;

    }

}

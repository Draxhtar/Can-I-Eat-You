using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAccordingToMovement : MonoBehaviour
{
    Vector2 movement;
    float lastAngle;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        //Vector2 lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        if (movement.x == 0 && movement.y == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, lastAngle);
            return;
        }
        else
        {
            lastAngle = angle;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        }
    }

    //private void LateUpdate()
    //{

    //}
}

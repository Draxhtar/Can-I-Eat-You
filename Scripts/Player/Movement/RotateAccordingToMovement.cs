using System.Collections.Generic;
using UnityEngine;

public class RotateAccordingToMovement : MonoBehaviour
{
    Vector2 movement;
    float lastAngle;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        
        if (movement.x == 0 && movement.y == 0) //If there is no input, we set the rotation to the lastAngle
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, lastAngle);
            return;
        }
        
        else //If there is Input atm:
        {
            lastAngle = angle;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        }
    }
}

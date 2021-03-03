using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    //[SerializeField] private Rigidbody2D myRb;
    private Vector2 mousePos;

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
    }
}

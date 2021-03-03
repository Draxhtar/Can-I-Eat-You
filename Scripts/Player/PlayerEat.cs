using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using EZCameraShake;

public class PlayerEat : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float eatRadius;

    [SerializeField] private LayerMask enemyLayers;

    [SerializeField] private Camera mainCam;
    [SerializeField] private Animator animator;
    [SerializeField] private FireEmissionManager fireEmissionManager;
    [SerializeField] private GameObject eatSound;

    [SerializeField] private float ssMagnitude, ssRoughness, ssFadeInTime, ssFadeOutTime;
    private Vector2 mousePos;
    Vector2 eatPoint;
    public MMFeedbacks EatFeedback;

    
    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            EatAttack();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CameraShaker.Instance.ShakeOnce(ssMagnitude, ssRoughness, ssFadeInTime, ssFadeOutTime);
        }
        
    }

    void EatAttack() 
    {
        //Detect the closest most eatable enemy
        Vector2 lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        eatPoint = lookDir.normalized * offset + (Vector2)transform.position;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(eatPoint, eatRadius, enemyLayers);
        Debug.Log(hitEnemies);

        //Play eat animation
        if (hitEnemies.Length < 1)
        {
            return;
        }
        else if (hitEnemies.Length == 1) 
        {
            LizardEnemy enemyToKill = hitEnemies[0].GetComponent<LizardEnemy>();
            enemyToKill.GetEaten(transform.position, eatPoint);
            Instantiate(eatSound);
            EatFeedback.PlayFeedbacks();
            animator.SetTrigger("Eating");
            fireEmissionManager.enabled = true;
            CameraShaker.Instance.ShakeOnce(ssMagnitude, ssRoughness, ssFadeInTime, ssFadeOutTime);
        }
        else if (hitEnemies.Length > 1) 
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }

        //Kill the enemy

        //Get the powerup
        GetFirePowerup();
    }

    private void OnDrawGizmos()
    {
        if (eatPoint == null)
            return;
        Gizmos.DrawWireSphere(eatPoint, eatRadius);
    }

    void GetFirePowerup() 
    {
        Debug.Log("Fireee!!");
    }
}

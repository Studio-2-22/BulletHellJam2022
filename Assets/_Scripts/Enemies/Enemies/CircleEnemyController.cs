using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyController : EnemyController
{

    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isStunned) {
            rb.velocity = Vector2.zero;
            return; 
        }
        float distanceFromPlayer =  Vector2.Distance(transform.position, playerTransform.position);
        if(distanceFromPlayer < detectionRange){
            // slowly rotate at constant speed
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime); 

            if(shootTimer > shootDelay){
                
                shootTimer = 0f;
                Shoot();
            }
            else{
                shootTimer += Time.deltaTime;
            }
        }
    }
}

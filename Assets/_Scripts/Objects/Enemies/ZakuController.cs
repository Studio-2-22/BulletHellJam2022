using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakuController : EnemyController
{
    // Start is called before the first frame update
     public override void Start()
    {
        base.Start(); // calls EnemyController Start()
    }

    // Update is called once per frame
    public virtual void Update()
    {
        FaceTarget(PlayerController.instance.transform.position);
        float distanceFromPlayer =  Vector2.Distance(transform.position, playerTransform.position);
        if(distanceFromPlayer < detectionRange){
            
            if(shootTimer > shootDelay){
                Shoot();
                shootTimer = 0f;
                
            }
            else{
                shootTimer += Time.deltaTime;
            }
           

            if(distanceFromPlayer > hoverRange ){
                rb.velocity = (playerTransform.position - transform.position).normalized * movementSpeed;
            }
            else{
                rb.velocity = Vector2.zero;
                return;
            }
        }
    }
}

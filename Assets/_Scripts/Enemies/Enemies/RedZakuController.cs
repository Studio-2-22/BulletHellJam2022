using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZakuController : ZakuController
{
    // Start is called before the first frame update
     public override void Start()
    {
        base.Start(); // calls ZakuController Start()
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
            FaceTarget(PlayerController.instance.transform.position);
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

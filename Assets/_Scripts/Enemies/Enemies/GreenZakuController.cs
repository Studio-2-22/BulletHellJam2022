using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZakuController : ZakuController
{
    
    // Start is called before the first frame update
     public override void Start()
    {
        base.Start(); // calls ZakuController Start()
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update(); // calls ZakuController Update()
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
        }
    }

    void OnApplicationQuit(){
        Destroy(gameObject);
    }
}

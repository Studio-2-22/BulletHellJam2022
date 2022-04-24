using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashZakuController : EnemyController
{

    public float DashDamage = 3f;
    public float DashSpeed = 5f;

    private bool isDashing = false;
    private Quaternion startRotation;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update(); // calls EnemyController Update()
        float distanceFromPlayer =  Vector2.Distance(transform.position, playerTransform.position);
        if(distanceFromPlayer < detectionRange){
            //slowly face the player
            if(!isDashing){
                SlowLookAt();
            } 

            if(shootTimer > shootDelay){
                
                shootTimer = 0f;
                Dash();
            }
            else{
                shootTimer += Time.deltaTime;
            }
        }
    }

    void SlowLookAt(){
        Vector2 direction = playerTransform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(Vector2.up, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
    }

    void Dash(){
        isDashing = true;
        rb.velocity = (playerTransform.position - transform.position).normalized * movementSpeed * DashSpeed;
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Player"));
        if(playerCollider != null){
            PlayerController.instance.TakeDamage(DashDamage);
        }
        StartCoroutine(DashCo());
    }

    IEnumerator DashCo(){
        yield return new WaitForSeconds(1.5f);
        rb.velocity = Vector2.zero;
        isDashing = false;
        startRotation = transform.rotation;
    }
}

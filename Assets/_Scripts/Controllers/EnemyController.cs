using System.Collections;
using System.Collections.Generic;
using BulletFury.Data;
using BulletFury;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp;
    public float maxHp = 3f;
    public float speed = 10f;
    public float shootDelay = 1f;
    public HealthBarBehaviour healthBar;
    private Rigidbody2D rb;
    private BulletCollider bc;
    public BulletManager bulletManager;
    private float shootTimer = 0f;
    private float detectionRange = 50f;
    private float hoverRange = 15f;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BulletCollider>();
        playerTransform = PlayerController.instance.transform;
        healthBar.setHealth(hp, maxHp);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        float distanceFromPlayer =  Vector2.Distance(transform.position, playerTransform.position);
        if(distanceFromPlayer < detectionRange){
            
            if(shootTimer > shootDelay){
                Shoot( playerTransform.position - transform.position);
                shootTimer = 0f;
                
            }
            else{
                shootTimer += Time.deltaTime;
            }
           

            // if(distanceFromPlayer > hoverRange ){
            //     rb.velocity = (playerTransform.position - transform.position).normalized * speed;
            // }
            // else{
            //     rb.velocity = Vector2.zero;
            //     return;
            // }
        }
    }

    void Shoot(Vector2 direction){
        bulletManager.Spawn(transform.position, direction);
    }

    public void TakeDamage(BulletContainer bullet, BulletCollider bc){
        hp -= bullet.Damage;
        healthBar.setHealth(hp, maxHp);
        if(hp <= 0){
            gameObject.SetActive(false);
        }
    }
}

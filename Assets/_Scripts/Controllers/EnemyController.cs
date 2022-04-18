using System.Collections;
using System.Collections.Generic;
using BulletFury.Data;
using BulletFury;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1;
    public float speed = 10f;
    public float shootDelay = 1f;
    private Rigidbody2D rb;
    private BulletCollider bc;
    public BulletManager bm;
    private float shootTimer = 0f;
    private float detectionRange = 50f;
    private float hoverRange = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BulletCollider>();
        bm= FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
         if(health <= 0){
            Destroy(gameObject);
        }
        float distanceFromPlayer =  Vector2.Distance(transform.position, PlayerController.instance.transform.position);
        if(distanceFromPlayer < detectionRange){
            
            if(shootTimer > shootDelay){
                Shoot();
                shootTimer = 0f;
            }
            else{
                shootTimer += Time.deltaTime;
            }

            if(distanceFromPlayer < hoverRange){
                rb.velocity = -(PlayerController.instance.transform.position - transform.position).normalized * speed;
            }else{
                rb.velocity = (PlayerController.instance.transform.position - transform.position).normalized * speed;
            }
        }
    }

    void Shoot(){
        Vector2 direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        bm.Spawn(transform.position, direction);
    }
}

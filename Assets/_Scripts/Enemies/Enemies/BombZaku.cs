using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombZaku : EnemyController
{
    public float explosionRadius = 5f;
    public float explosionDamage = 5f;
    public float explosionForce = 500f;
    public float explosionDelay = 1f;
    public float explosionTimer = 0f;

    public bool isExploding = false;
    public bool exploded = false;
    public GameObject explosionPrefab;

    

    public void Update()
    {
      if(exploded) {
        return;
      }
      if(!isExploding){

        Vector2 playerPos = PlayerController.instance.transform.position;
        float distanceFromPlayer =  Vector2.Distance(transform.position, playerPos);
        FaceTarget(PlayerController.instance.transform.position);
        rb.velocity = (playerPos - (Vector2)transform.position).normalized * movementSpeed;

        if(distanceFromPlayer < explosionRadius/2){
          isExploding = true;
        }
      }
      else {
        explosionTimer += Time.deltaTime;
        if(explosionTimer > explosionDelay){
          exploded = true;
          Explode();
        }
      }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Enemy"));
        Collider2D playerCheck  = Physics2D.OverlapCircle(transform.position, explosionRadius, LayerMask.GetMask("Player"));
        foreach (Collider2D collider in colliders)
        {
           
            if (collider.tag == "Enemy" && collider.gameObject != gameObject)
            {
                Vector2 direction = collider.transform.position - transform.position;
                collider.GetComponent<Unit>().TakeDamage(explosionDamage);
                collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * explosionForce);
            }
        }

        if(playerCheck != null){
          PlayerController.instance.TakeDamage(explosionDamage);
          Vector2 direction = playerCheck.transform.position - transform.position;
          playerCheck.GetComponent<Rigidbody2D>().AddForce(direction.normalized * explosionForce);
        }


        if(explosionPrefab != null){
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
        }
         gameObject.SetActive(false);
    }

    public override void KillUnit(){
        Explode();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public BulletCollider bc;
    [HideInInspector]
    public Rigidbody2D rb;
    public float maxHp = 3f;
    public float hp = 3f;
    public float movementSpeed = 10f;
    public float maxSpeed = 20f;
    public float friction = 2f;
    public GameObject deathPrefab;
    public int DeathSoundIndex = 0;//index of enemy death sound in AudioManager

    public virtual void Start(){
        hp = maxHp;
        bc = GetComponent<BulletCollider>();
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            KillUnit();           
        }
    }
     public virtual void TakeBulletDamage(BulletContainer bullet, BulletCollider bc){
        TakeDamage(bullet.Damage);
    }


    public virtual void KillUnit(){
        gameObject.SetActive(false);
        AudioManager.instance.PlayEffect(DeathSoundIndex);

        if(deathPrefab != null){
            Instantiate(deathPrefab, transform.position, transform.rotation);
        }
        
    }

    public void FaceTarget(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }

}

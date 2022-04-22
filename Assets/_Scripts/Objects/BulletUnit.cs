using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletUnit : Unit
{
    public BulletManager bm;
    [HideInInspector]
    public BulletCollider bc;
    [HideInInspector]
    public Rigidbody2D rb;
    // Start is called before the first frame update
    public virtual void Start()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BulletCollider>();
    }

    public void TakeBulletDamage(BulletContainer bullet, BulletCollider bc){
        TakeDamage(bullet.Damage);
    }

    public void FireEffects(){
        //play fire effects

    }

    public void Shoot(){
        AudioManager.instance.PlayeEffect(3); // index 3 is the shoot sound
        bm.Spawn(transform.position, -transform.up);
    }


    
}

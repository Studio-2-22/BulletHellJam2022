using System.Collections;
using System.Collections.Generic;
using BulletFury.Data;
using BulletFury;
using UnityEngine;

public class EnemyController : BulletUnit
{
    public HealthBarBehaviour healthBar;
    [HideInInspector]
    public float shootTimer = 0f;
    public float detectionRange = 50f;
    public float hoverRange = 15f;
    public float shootDelay = 1f;
    public bool isStunned = false;
    public AddPlayerStats playerStats;

    [HideInInspector]   
    public Transform playerTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); 
        playerTransform = PlayerController.instance.transform;
        healthBar.setHealth(hp, maxHp);
    }

    public virtual void Update(){
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthBar.setHealth(hp, maxHp);
    }

    public override void TakeBulletDamage(BulletContainer bullet, BulletCollider bc)
    {
        TakeDamage(PlayerController.instance.bulletDamage);
        healthBar.setHealth(hp, maxHp);
    }

    public virtual void OnEnable(){
        hp = maxHp;
        isStunned = false;
    }

    public void StunEnemy()
    {
        isStunned = true;
        StartCoroutine(StunEnemyCo());
        rb.velocity = Vector2.zero; 

    }

    IEnumerator StunEnemyCo()
    {
        yield return new WaitForSeconds(1.5f);
        isStunned = false; 
    }

    public void GivePlayerStats(){
        
        PlayerController.instance.AddStats(playerStats);
    }
    
}

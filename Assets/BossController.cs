using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;


public class BossController : MonoBehaviour
{

    public float speed;

    public float hp = 200f;
    public float maxHp = 200f;
    public PlayerHealthBarBehaviour healthBar;




    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        healthBar.setHealth(hp,maxHp);
        GameStateManager.instance.ChangeState(GameStateManager.GameState.Boss);
    }

    public  void TakeDamage(float damage)
    {
        hp -= damage;
        healthBar.setHealth(hp,maxHp);
        if (hp <= 0)
        {
            GameStateManager.instance.ChangeState(GameStateManager.GameState.Win);
            gameObject.SetActive(false);
            
        }
    }
     public void TakeBulletDamage(BulletContainer bullet, BulletCollider bc){
        TakeDamage(bullet.Damage);
    }


}

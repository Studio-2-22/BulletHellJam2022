using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public float maxHp = 3f;
    public float hp = 3f;
    public float movementSpeed = 10f;
    public float maxSpeed = 20f;
    public float friction = 2f;
    public GameObject deathPrefab;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            KillUnit();           
        }
    }

    public  void KillUnit(){
        gameObject.SetActive(false);
        if(deathPrefab != null){
            Instantiate(deathPrefab, transform.position, transform.rotation);
        }
        
    }

    public void FaceTarget(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-270, Vector3.forward);
    }

}

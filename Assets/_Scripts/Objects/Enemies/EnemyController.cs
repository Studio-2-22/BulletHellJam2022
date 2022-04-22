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
    [HideInInspector]
    public Transform playerTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        playerTransform = PlayerController.instance.transform;
        healthBar.setHealth(hp, maxHp);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }
}
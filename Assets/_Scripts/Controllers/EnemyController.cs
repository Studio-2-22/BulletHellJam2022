using System.Collections;
using System.Collections.Generic;
using BulletFury.Data;
using BulletFury;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1;
    public float speed = 1f;
    public float shootDelay = 1f;
    private Rigidbody2D rb;
    private BulletCollider bc;
    private BulletManager bm;
    private float shootTimer = 0f;
    private float detectionRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BulletCollider>();
        bm = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}

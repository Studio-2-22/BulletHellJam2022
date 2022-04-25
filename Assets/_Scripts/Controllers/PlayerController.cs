using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class PlayerController : BulletUnit
{
    public static PlayerController instance;
    public float dashCD = 0.3f; 
    public float dashSpeed = 5f;
    public float maxDashSpeed = 10f;
    public int buttonCount = 0;
    public float shootSpeed = 0.5f;
    public int numberOfBullets = 100;
    public float bulletDamage = 1f;
    public BulletManager[] bulletManagers;
    private float shootTimer = 0f;
    private float dashTime = 0.2f;
    private bool canDash = true;
    private bool isDashing = false;
    private int bulletManagerIndex = 0;

    private void Awake()
    {
        if(instance == null){
            Destroy(instance);
            instance = this;
        }
        instance = this;
    }


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); // calls BulletUnit Start()
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        FaceTarget(mousePos);

        float horizontal =Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        if(direction.magnitude > 0){
             rb.AddForce(direction * movementSpeed);

        }
        if(!isDashing){
            rb.velocity = Mathf.Min(maxSpeed, rb.velocity.magnitude)  * rb.velocity.normalized;
        }
            
       
        shootTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            Dash();
            canDash = false;
            StartCoroutine(DashCoolDown());
            buttonCount = 0; 
        }

        if (Input.GetMouseButton(0) && shootTimer <= 0)
        {
            numberOfBullets--;
            Shoot();
            shootTimer = shootSpeed;
        }
    }

    void Dash(){
        

        //rb.AddForce(-transform.up * boostFactor * movementSpeed);
        
        isDashing = true;
        rb.velocity = rb.velocity + ((Vector2)transform.up * dashSpeed * movementSpeed);
        GetComponent<TrailRenderer>().enabled = true;


        StartCoroutine(StopPlayer());
    }

    public void AddStats(AddPlayerStats stats){
        
        hp = Mathf.Min(hp + stats.hp, maxHp);
        dashCD -= stats.dashCD;
        dashSpeed += stats.dashSpeed;
        shootSpeed += stats.shootSpeed;
        numberOfBullets += stats.numberOfBullets;
        bulletDamage += stats.bulletDamage;
        Debug.Log(stats.upgradeRadius);
        if(stats.upgradeRadius && bulletManagerIndex+1 < bulletManagers.Length){
            bulletManagerIndex++;
            bm = bulletManagers[bulletManagerIndex];
        }
        
    }

    IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(dashTime);
        rb.velocity = rb.velocity * 0.01f;
        isDashing = false;
        GetComponent<TrailRenderer>().enabled = false;

     
    }
    IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(dashCD);
        canDash = true; 
    }


}

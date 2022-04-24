using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class PlayerController : BulletUnit
{
    public static PlayerController instance;
    public float dashSpeed = 5f;
    public float buttonTimer = 0.2f;
    public int buttonCount = 0;
    public float dashCD = 0.3f; 
    private float dashTime = 0.2f;
    private bool canDash = true;
    private bool isDashing = true; 

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
        if(!isDashing  || rb.velocity.magnitude < maxSpeed){
            rb.velocity = Mathf.Min(maxSpeed, rb.velocity.magnitude)  * rb.velocity.normalized;
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, friction * Time.deltaTime);
        }
            
        buttonTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            buttonCount++;

            if (buttonTimer > 0 && buttonCount == 1)
            {

                Dash();
                canDash = false;
                StartCoroutine(DashCoolDown());
                buttonCount = 0; 
       

            } 
            else {
                buttonTimer = 0.5f;
                buttonCount = 0; 
            }
        }

        if (Input.GetMouseButton(0))
        {   
            Shoot();
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
        
        //bm.
        // dashSpeed += stats.dashSpeed;
        // dashCD += stats.dashCD;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class PlayerController : BulletUnit
{
    public static PlayerController instance;
    public float lineDamage = 1f;
    public float boostFactor = 5f;
    private bool boosting = false; 
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
             if(rb.velocity.magnitude > maxSpeed && !boosting){
                 rb.velocity = rb.velocity.normalized * maxSpeed;
             } 
        }
        if(!boosting ){
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, friction * Time.deltaTime);
        }
            
        

        if(Input.GetKey(KeyCode.Space)){
            Boost();
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            boosting = false;
        }
           
        if (Input.GetMouseButton(0))
        {   
             bm.Spawn(transform.position, -transform.up);
        }
    }

    void Boost(){
        boosting = true;
        rb.AddForce(-transform.up * boostFactor * movementSpeed);
        //StartCoroutine(BoostCooldown());
    }
}

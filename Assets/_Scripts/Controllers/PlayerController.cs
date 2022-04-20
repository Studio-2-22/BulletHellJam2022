using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public BulletManager bm;

    public float speed = 10f;
    public float maxSpeed = 20f;
    public float friction = 2f;
    public float lineDamage = 1f; 
    private Rigidbody2D rb;
    private BulletCollider bc;

    
    
    private void Awake()
    {
        if(instance == null){
            Destroy(instance);
            instance = this;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BulletCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();

        float horizontal =Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        if(direction.magnitude > 0){
             rb.AddForce(direction * speed);
             if(rb.velocity.magnitude > maxSpeed){
                 rb.velocity = rb.velocity.normalized * maxSpeed;
             }
        }else{
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, friction * Time.deltaTime);
        }
           
        if (Input.GetMouseButton(0))
        {   
            bm.Spawn(transform.position, bm.Plane == BulletPlane.XY ? transform.right : transform.forward);
        }
        
        
    }

    void FaceMouse()
    {
        //turn the player to face the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;

        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(z, Vector3.forward);
    }

    void FireEffects(){
        //play fire effects


    }
}

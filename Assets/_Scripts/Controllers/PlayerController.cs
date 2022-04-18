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
        FaceMouse();
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();

        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
           velocity += Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector2.down * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector2.right * speed;
        }
        
        rb.AddForce(velocity);

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

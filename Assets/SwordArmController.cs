using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArmController : MonoBehaviour
{
     public float DashDamage = 3f;
    public float DashSpeed = 5f;

    public float movementSpeed = 25f;

    private bool isDashing = false;
    private float shootTimer;
    public float shootDelay = 2f;
    private Quaternion startRotation;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    public void Start()
    {
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {
        float distanceFromPlayer =  Vector2.Distance(transform.position, PlayerController.instance.transform.position);
            //slowly face the player
        if(!isDashing){
            SlowLookAt();
        } 

        if(shootTimer > shootDelay){
            
            shootTimer = 0f;
            Dash();
        }
        else{
            shootTimer += Time.deltaTime;
        }
        
    }

    void SlowLookAt(){
        Vector2 direction = PlayerController.instance.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(-Vector2.up, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
    }

    void Dash(){
        isDashing = true;
        rb.velocity = (PlayerController.instance.transform.position - transform.position).normalized * movementSpeed * DashSpeed;
        StartCoroutine(DashCo());
    }

    IEnumerator DashCo(){
        yield return new WaitForSeconds(1.5f);
        rb.velocity = Vector2.zero;
        isDashing = false;
        startRotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"   ){
            PlayerController.instance.TakeDamage(DashDamage);
        }
    }
}

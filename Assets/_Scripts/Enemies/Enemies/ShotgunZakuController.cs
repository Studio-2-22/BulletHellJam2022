using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunZakuController : RedZakuController
{
    // Start is called before the first frame update
     public override void Start()
    {
        base.Start(); // calls ZakuController Start()
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isStunned) {
            rb.velocity = Vector2.zero;
            return; 
        }
    }
}

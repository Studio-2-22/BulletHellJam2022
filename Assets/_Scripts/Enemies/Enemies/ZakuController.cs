using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakuController : EnemyController
{
    // Start is called before the first frame update
     public override void Start()
    {
        base.Start(); // calls EnemyController Start()
    }

    // Update is called once per frame
    public virtual void Update()
    {

        if (isStunned) {
            return; 
        }

        
        
    }
}

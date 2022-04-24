using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletUnit : Unit
{
    public BulletManager bm;
    
  
    public int bulletSoundIndex = 3;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
   
    public void FireEffects(){
        //play fire effects

    }

    public virtual void Shoot(){
        bm.Spawn(transform.position, transform.up);
    }

  public void OnBulletSpawned(int x, BulletContainer bc)
  {
    AudioManager.instance.PlayEffect(bulletSoundIndex); // index 3 is the shoot sound
  }
    
}

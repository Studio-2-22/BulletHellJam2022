using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class GunArmController : MonoBehaviour
{
    private BulletManager bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        bm.Spawn(transform.position, -transform.up);
    }

    void FacePlayer(){
        Vector2 direction = PlayerController.instance.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(-Vector2.up, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);

    }
}

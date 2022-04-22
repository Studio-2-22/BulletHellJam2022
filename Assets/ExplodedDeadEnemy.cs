using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedDeadEnemy : MonoBehaviour
{
    public float destroyTime = 10f;
    float timer = 0;
    // Awake is called when the script instance is being loaded
    void Start()
    {
        Rigidbody2D[] children = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D child in children)
        {
            Debug.Log("child: " + child.name);
            Vector2 direction = child.transform.localPosition.normalized;
            child.AddForce(direction * 100f);
        }
        StartCoroutine(WaitAndDestroy());

        
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    public GameObject lineHead;
    public GameObject lineStart;
    public bool loopCompleted = false;

   private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(!loopCompleted){
            
            if(other.tag == "LineHead"){
                
                if(CaptureController.instance.hasLeftStart && !CaptureController.instance.isResetting){
                    CaptureController.instance.CancelLine();
                }
                
            }else if(other.tag == "Enemy"){
                // Debug.Log("Cancelled");
                // Debug.Log(other.tag);
                CaptureController.instance.CancelLine();
            }
           
        }else{
            if(other.tag == "Enemy"){
                CaptureController.instance.containsEnemy = true;
                if(other.gameObject.activeSelf){
                    other.gameObject.GetComponent<EnemyController>().StunEnemy(); 
                    other.gameObject.GetComponent<EnemyController>().TakeDamage(CaptureController.instance.loopCounter+2); 
                }
                
            }
        }

    }
}

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
                    Debug.Log("LineHead cancelled");
                    CaptureController.instance.CancelLine();
                }
                
            }else{
                Debug.Log("Cancelled");
                Debug.Log(other.tag);
                CaptureController.instance.CancelLine();
            }
           
        }else{
            Debug.Log(other.name);
            if(other.tag == "Enemy"){
                Destroy(other.gameObject);
            }
        }
    }
}

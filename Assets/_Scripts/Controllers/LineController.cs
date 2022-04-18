using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    public GameObject lineHead;
    public GameObject lineStart;
    public bool loopCompleted = false;

    void Update(){
        if(CaptureController.instance.currentLine != gameObject){
            Debug.Log("Destroyed self");
            DestroySelf();
        }
    }

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

    void DestroySelf(){
        StartCoroutine(DestroySelfCo());
    }
    
    IEnumerator DestroySelfCo(){
        yield return new WaitForSeconds(0.1f);
        Destroy(lineStart);
        Destroy(lineHead);
        Destroy(gameObject);
        
    }
}

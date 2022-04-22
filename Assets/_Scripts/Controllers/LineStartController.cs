using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStartController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {  
        if(other.tag == "LineHead"){
            if(CaptureController.instance.hasLeftStart && !CaptureController.instance.isResetting){
                CaptureController.instance.ResetLine();
            }
            
        }
        
    }
}

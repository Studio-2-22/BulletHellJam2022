using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    public GameObject lineHead;
    public GameObject lineStart;
    public GameObject giveAtkSpeed;
    public GameObject giveHP;
    public GameObject giveDash;
    public GameObject giveDamage;
    public GameObject giveSpray;

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
                if (other.gameObject.activeSelf) {
                    EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
                    enemy.StunEnemy();

                    if (enemy.hp - (CaptureController.instance.loopCounter + 1) <= 0)
                    {

                        enemy.GivePlayerStats();
                        Debug.Log("stats given");
                        enemy.ShowFloatingText();

                        enemy.gameObject.SetActive(false);

                    } else {
                        enemy.TakeDamage(CaptureController.instance.loopCounter + 1);
                    }
                }
                    
                }
                
            }
        }

    }

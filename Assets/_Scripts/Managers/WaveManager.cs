using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> EnemiesWaves;
    public float waveLength = 61f;
    private int currentWave = 0;
    private float waveTimer = 0f;
    private float waveDelay = 5f;
    private GameObject currentWaveObject;     


    // Start is called before the first frame update
    void Start()
    {
        waveTimer = waveLength;
        EnemiesWaves[currentWave].SetActive(true);
        currentWaveObject = EnemiesWaves[currentWave];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWave != EnemiesWaves.Count-1)
            DisplayTime();
        if (EnemiesWaves.Count > 0)
        {

            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                if(currentWaveObject)
                {
                    //currentWaveObject.SetActive(false);
                    
                }
               
                waveTimer = waveLength;
                currentWave++;

                if (currentWave == EnemiesWaves.Count-1)
                {
                   transform.GetChild(0).gameObject.SetActive(false);
                }
                EnemiesWaves[currentWave].SetActive(true);
                
            }
            
        }  
    }

    void DisplayTime(){
        int minutes = Mathf.FloorToInt(waveTimer / 60F);
        int seconds = Mathf.FloorToInt(waveTimer % 60);

        GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}

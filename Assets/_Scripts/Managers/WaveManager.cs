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
        DisplayTime();
        if (EnemiesWaves.Count > 0)
        {

            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                if(currentWaveObject)
                {
                    currentWaveObject.SetActive(false);
                    for(int i = 0; i < currentWaveObject.transform.childCount; i++)
                    {
                       EnemyController enemy = currentWaveObject.transform.GetChild(i).gameObject.GetComponent<EnemyController>();
                       GreenZakuController gz;
                       enemy.hp = enemy.maxHp;
                       enemy.healthBar.setHealth(enemy.maxHp, enemy.maxHp);
                       enemy.gameObject.SetActive(true);
                    }
                }
                waveTimer = waveLength;
                currentWave++;

                if (currentWave >= EnemiesWaves.Count)
                {
                    currentWave = 0;
                }
                currentWaveObject = EnemiesWaves[currentWave];
                currentWaveObject.SetActive(true);
            }
            
        }  
    }

    void DisplayTime(){
        int minutes = Mathf.FloorToInt(waveTimer / 60F);
        int seconds = Mathf.FloorToInt(waveTimer % 60);

        GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}

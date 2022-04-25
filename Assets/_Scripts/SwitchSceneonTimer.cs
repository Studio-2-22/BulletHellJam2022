using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSceneonTimer : MonoBehaviour
{
    public float delay;
    public int sceneNum;
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay, sceneNum));
    }

    IEnumerator LoadLevelAfterDelay(float delay,int sceneNum)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNum);
    }
}

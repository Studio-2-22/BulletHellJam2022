using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    public string[] dialogues;
    public string fullText;
    private string currentText = "";
    private int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        fullText = dialogues[0];
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText(){
        transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0, i);
            transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        index++;
        yield return new WaitForSeconds(5);
        transform.GetChild(1).gameObject.SetActive(false);
        if (index < dialogues.Length){
            fullText = dialogues[index];
            yield return new WaitForSeconds(60);
            StartCoroutine(ShowText());
        }
    }
}
